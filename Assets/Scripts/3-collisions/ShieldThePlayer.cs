using System.Collections;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<Destroy_3_life_trigger>();
            if (destroyComponent)
            {
                Debug.Log("Found Destroy_3_life_trigger component, starting shield coroutine.");
                StartCoroutine(ShieldTemporarily(destroyComponent));
                Destroy(gameObject); // Destroy the shield itself
            }
            else
            {
                Debug.Log("Destroy_3_life_trigger component not found!");
            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }

    private IEnumerator ShieldTemporarily(Destroy_3_life_trigger destroyComponent)
    {
        destroyComponent.enabled = false;
        Debug.Log("Shield activated.");

        for (float i = duration; i > 0; i--)
        {
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Shield expired, re-enabling Destroy_3_life_trigger.");
        destroyComponent.enabled = true;
    }
}
