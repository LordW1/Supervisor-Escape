using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI inactivatedCirclesText; // TextMeshPro component
    public int totalCircles = 2;
    private int activatedCircles = 0;

    private void Start()
    {
        UpdateInactivatedCircles();
    }

    public void UpdateActivationCount()
    {
        activatedCircles++;
        UpdateInactivatedCircles();

        if (activatedCircles == totalCircles)
        {
            WinGame();
        }
    }

    private void UpdateInactivatedCircles()
    {
        int inactivatedCircles = totalCircles - activatedCircles;
        inactivatedCirclesText.text = $"Items Remained: {inactivatedCircles}";
    }

    private void WinGame()
    {
        inactivatedCirclesText.text = $"You Win";
        Debug.Log("You win!");

        // Destroy the Timer GameObject
        GameObject timer = GameObject.Find("Timer");
        if (timer != null)
        {
            Destroy(timer);
        }
        else
        {
            Debug.LogWarning("Timer GameObject not found.");
        }

        // Additional win condition logic
    }
}
