using UnityEngine;
using UnityEngine.InputSystem;

public class MyClickSpawner : MonoBehaviour
{
    [Tooltip("Input action for spawning objects.")]
    [SerializeField] InputAction spawnAction = new InputAction(type: InputActionType.Button);

    [Tooltip("Prefab of the object to spawn.")]
    [SerializeField] GameObject prefabToSpawn;

    [Tooltip("Velocity to be applied to spawned objects.")]
    [SerializeField] Vector3 velocityOfSpawnedObject;

    private bool ultraLaser; // Flag to control if ultra laser mode is active
    private float minRange = -0.5f; // Minimum range for spawning variation
    private float maxRange = 0.5f; // Maximum range for spawning variation

    // Sets the ultra laser flag
    public void SetFlag(bool flag)
    {
        ultraLaser = flag;
    }

    // Returns the state of the ultra laser flag
    public bool GetFlag()
    {
        return ultraLaser;
    }

    // Enable the spawn action when the object is enabled
    void OnEnable()
    {
        spawnAction.Enable();
    }

    // Disable the spawn action when the object is disabled
    void OnDisable()
    {
        spawnAction.Disable();
    }

    // Spawns a single object at the position of the GameObject this script is attached to
    protected GameObject spawnObject()
    {
        Debug.Log("Spawning a new object");

        Vector3 positionOfSpawnedObject = transform.position; // Spawn at this object's position
        Quaternion rotationOfSpawnedObject = Quaternion.identity; // Default rotation
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Set the velocity of the spawned object if it has a Mover component
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    // Spawns objects at varied positions based on the input index
    protected GameObject spawnObjects(int index)
    {
        Vector3 positionOfSpawnedObject = transform.position; // Base position
        // Adjust position based on index
        if (index == 1)
        {
            positionOfSpawnedObject += new Vector3(minRange, maxRange, 0);
        }
        else if (index == 2)
        {
            positionOfSpawnedObject += new Vector3(maxRange, maxRange, 0);
        }
        else if (index == 3)
        {
            positionOfSpawnedObject += new Vector3(minRange, minRange, 0);
        }
        else
        {
            positionOfSpawnedObject += new Vector3(maxRange, minRange, 0);
        }

        Quaternion rotationOfSpawnedObject = Quaternion.identity; // Default rotation
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Set the velocity of the spawned object if it has a Mover component
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the spawn action was triggered this frame
        if (spawnAction.WasPressedThisFrame())
        {
            if (!ultraLaser)
            {
                // Spawn a single object if ultra laser is not active
                spawnObject();
            }
            else
            {
                // Spawn multiple objects at varied positions if ultra laser is active
                for (int i = 4; i > 0; i--)
                {
                    spawnObjects(i);
                }
            }
        }
    }
}
