using UnityEngine;

public class myMove : MonoBehaviour
{
    [Tooltip("Speed at which the object moves.")]
    [SerializeField] float speed = 20f; // The speed at which the GameObject moves

    // Update is called once per frame
    void Update()
    {
        // Check for left arrow key input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the GameObject to the left
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        // Check for right arrow key input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move the GameObject to the right
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        // Check for up arrow key input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move the GameObject upwards
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        // Check for down arrow key input
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move the GameObject downwards
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
