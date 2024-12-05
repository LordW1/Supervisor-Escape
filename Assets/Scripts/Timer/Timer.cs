using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Ensure you have TextMeshPro in your project.

public class TimerScript : MonoBehaviour
{
    public bool Timesup = false; // Boolean to track if time is up
    public float countdown = 10f; // 10-second countdown
    public TextMeshProUGUI messageText; // Reference to the TextMeshPro UI text
    public GameObject GameOverScreen;
    public GameObject ItemsRemaining;
    public GameObject Timer;

    private void Start()
    {
        // Find the TextMeshPro UI component in the scene
        messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        UpdateCountdownText(); // Initialize the countdown text
        GameOverScreen.SetActive(false);
        ItemsRemaining.SetActive(true);
        Timer.SetActive(true);
    }

    private void Update()
    {
        if (!Timesup)
        {
            // Count down
            countdown -= Time.deltaTime;

            if (countdown <= 0f)
            {
                Timesup = true;
                countdown = 0f;
                FreezeScene();
            }
            else
            {
                UpdateCountdownText(); // Update the countdown display
            }
        }
        else
        {
            // Allow the player to press space to reload the scene
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReloadScene();
            }
        }
    }

    private void UpdateCountdownText()
    {
        // Update the text to show the remaining time rounded to the nearest whole number
        messageText.text = $"{Mathf.CeilToInt(countdown):00}";
    }

    private void FreezeScene()
    {
        Time.timeScale = 0f; // Freeze the game
        messageText.text = ""; // Display the message
        GameOverScreen.SetActive(true);
        ItemsRemaining.SetActive(false);
        Timer.SetActive(false);
    }

    private void ReloadScene()
    {
        Time.timeScale = 1f; // Reset the game time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
    }
}
