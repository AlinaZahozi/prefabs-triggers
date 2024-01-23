using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AssetClick : MonoBehaviour
{
    public string sceneToLoad;
    public float animationDuration = 0.5f; // Duration of the scaling animation

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                // Start the scaling coroutine
                StartCoroutine(AnimateAndChangeScene());
            }
        }
    }

    IEnumerator AnimateAndChangeScene()
    {
        Vector3 originalScale = transform.localScale; // Store the original scale
        Vector3 targetScale = originalScale * 0.9f; // Decrease to 90%

        // Scale down
        float timer = 0;
        while (timer <= animationDuration / 2)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / (animationDuration / 2));
            timer += Time.deltaTime;
            yield return null;
        }

        // Scale up
        timer = 0;
        while (timer <= animationDuration / 2)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / (animationDuration / 2));
            timer += Time.deltaTime;
            yield return null;
        }

        // Load the scene after the animation
        SceneManager.LoadScene(sceneToLoad);
    }
}
