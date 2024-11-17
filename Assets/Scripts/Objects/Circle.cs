using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public bool Activation = false;
    public float Count = 0;
    public float maxCount = 100; // Threshold to activate
    public float decreaseRate = 20f; // Rate at which Count decreases
    public Slider energyBar; // UI Slider for tracking Count
    public Vector3 newSize = new Vector3(1, 1, 1);

    private void Start()
    {
        energyBar.maxValue = maxCount;
        energyBar.value = Count;
    }

    private void Update()
    {
        if (!Activation)
        {
            // Decrease Count over time, ensuring it doesn't drop below 0
            Count = Mathf.Max(0, Count - decreaseRate * Time.deltaTime);
            energyBar.value = Count;
            // Check if Count reaches or exceeds maxCount and activate the Circle
             if (Count >= 99)
            {
                transform.localScale = newSize;
                Activation = true;
                Debug.Log("Activated");
                FindObjectOfType<GameManager>().UpdateActivationCount();
            }
        }

       /*if (Count >= 99)
            {
                transform.localScale = newSize;
                Activation = true;
                Debug.Log("Activated");
                FindObjectOfType<GameManager>().UpdateActivationCount();
            }*/
    }

    public void IncreaseCount()
    {
        if (!Activation)
        {
            Count += 10; // Amount increased per Space press
            Count = Mathf.Min(Count, maxCount);
            energyBar.value = Count;
            Debug.Log("Count:" + Count);

        }
    }
}
