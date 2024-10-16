using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private string nextSceneName;  // Store the scene name as a string
    private GameObject player;

    // Reference to the UI Image used for the fade effect
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;  // Duration of fade effect

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Make the player persistent across scene loads
            DontDestroyOnLoad(player);
            

            // Start fading to black and then load the next scene
            StartCoroutine(FadeAndSwitchScene());
        }
    }

    // Coroutine to handle the fade-to-black effect and scene loading
    private IEnumerator FadeAndSwitchScene()
    {
        // Make the image visible before starting the fade
        SetImageAlpha(0f);

        // Start fading to black
        yield return StartCoroutine(FadeToBlack());

        // Load the next scene
        SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to sceneLoaded event
        SceneManager.LoadScene(nextSceneName);
    }

    // Coroutine to fade the image to black
    private IEnumerator FadeToBlack()
    {
        float timer = 0f;

        // Get the original color (black with alpha 0)
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0f;  // Start fully transparent

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);  // Lerp alpha value from 0 to 1
            fadeImage.color = fadeColor;  // Apply the new color
            yield return null;  // Wait for the next frame
        }

        // Ensure it's fully black at the end
        fadeColor.a = 1f;
        fadeImage.color = fadeColor;
    }

    // Utility function to set the image alpha
    private void SetImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }

    // This method is called when the scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player object (if needed)
        player = GameObject.FindGameObjectWithTag("Player");

        // Find the spawn point in the new scene
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");  // Use the "SpawnPoint" tag

        if (spawnPoint != null && player != null)
        {
            // Set the player's position to the spawn point's position
            player.transform.position = spawnPoint.transform.position;
        }

        // Unsubscribe from the event (important to prevent memory leaks)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Ensure the fadeImage is fully transparent at the start
        SetImageAlpha(0f);  // Make it invisible at the start
    }

    // Update is called once per frame
    void Update()
    {

    }
}
