using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_3_life_trigger : MonoBehaviour
{
    [Tooltip("Tag that triggers life loss or power-up activation.")]
    [SerializeField] private string triggeringTag;

    [Tooltip("Array of GameObjects representing the player's lives.")]
    [SerializeField] private GameObject[] lifeHearts;

    [Tooltip("Duration for which the shield remains active.")]
    [SerializeField] private float shieldDuration = 5f;

    [Tooltip("Duration for which the extra laser remains active.")]
    [SerializeField] private float extraLaserDuration = 5f;

    private int currentLives; // Number of lives currently remaining
    private float shieldEndTime = 0f; // Time when the shield will deactivate
    private float extraLaserEndTime = 0f; // Time when the extra laser will deactivate
    private bool isShielded = false; // Flag to determine if the shield is active

    private void Start()
    {
        // Initialize current lives based on the number of hearts
        currentLives = lifeHearts.Length;
    }

    private void Update()
    {
        // Check if the shield has expired
        if (isShielded && Time.time > shieldEndTime)
        {
            isShielded = false;
        }

        // Check if the extra laser duration has expired
        if (Time.time > extraLaserEndTime)
        {
            DisableExtraLaser();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collisions with different tags and handle accordingly
        if (other.tag == triggeringTag && enabled && !isShielded)
        {
            LoseLife();
            Destroy(other.gameObject); // Destroy the colliding object (enemy)
        }
        else if (other.tag == "sheild")
        {
            ActivateShield();
            Destroy(other.gameObject); // Destroy the shield power-up
        }
        else if (other.tag == "extraLaser")
        {
            ActivateExtraLaser();
            Destroy(other.gameObject); // Destroy the extra laser power-up
        }
        else if (other.tag == "Finish")
        {
            // Load winning scene
            SceneManager.LoadScene("win");
        }
    }

    private void LoseLife()
    {
        // Handle life loss
        if (currentLives > 0)
        {
            currentLives--;
            lifeHearts[currentLives].SetActive(false); // Disable one heart

            // Check if all lives are lost
            if (currentLives <= 0)
            {
                Destroy(this.gameObject); // Destroy the spaceship
                SceneManager.LoadScene("try again"); // Load the try again scene
            }
        }
    }

    private void ActivateShield()
    {
        isShielded = true;
        shieldEndTime = Time.time + shieldDuration; // Set time when shield will deactivate
    }

    private void ActivateExtraLaser()
    {
        EnableExtraLaser();
        extraLaserEndTime = Time.time + extraLaserDuration; // Set time when extra laser will deactivate
    }

    private void EnableExtraLaser()
    {
        // Enable extra laser feature
        var clickSpawner = GetComponent<MyClickSpawner>();
        if (clickSpawner != null)
        {
            clickSpawner.SetFlag(true);
        }
    }

    private void DisableExtraLaser()
    {
        // Disable extra laser feature
        var clickSpawner = GetComponent<MyClickSpawner>();
        if (clickSpawner != null)
        {
            clickSpawner.SetFlag(false);
        }
    }
}
