using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalCircles = 6;
    public int activatedCircles = 0;

    public GameObject winScreen;
    public GameObject otherRemainingUI;

    private AudioManager audioSearch;
    public bool won;

 
    // public TextMeshProUGUI inactivatedCirclesText; 

    private void Start()
    {
        winScreen.SetActive(false);
        audioSearch = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Initialize inactivatedCirclesText if used
        // UpdateInactivatedCirclesText();
    }

    private void Update()
    {
        if (activatedCircles == totalCircles && !won)
        {
            WinGame();
        }


        // UpdateInactivatedCirclesText();
    }

    public void UpdateActivationCount()
    {

        if (activatedCircles < totalCircles)
        {
            activatedCircles++;
            
            // UpdateInactivatedCirclesText();
        }
    }

    public void WinGame()
    {
        won = true;
        winScreen.SetActive(true);
        otherRemainingUI.SetActive(false);
        Debug.Log("You win!");
        Time.timeScale = 0f;
        audioSearch.PauseMusic();  // Replaced AudioManager.instance with audioSearch
        audioSearch.PlaySFX(audioSearch.winSFX);
    }

    // Uncomment if you want to display the number of inactivated circles
    // private void UpdateInactivatedCirclesText()
    // {
    //     inactivatedCirclesText.text = "Remaining Circles: " + (totalCircles - activatedCircles);
    // }
}

