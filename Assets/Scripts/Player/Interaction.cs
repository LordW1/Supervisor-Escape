using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Circle currentCircle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Circle"))
        {
            currentCircle = other.GetComponent<Circle>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Circle"))
        {
            currentCircle = null;
        }
    }

    private void Update()
    {
        if (currentCircle != null && Input.GetKeyDown(KeyCode.Space))
        {
            currentCircle.IncreaseCount();
        }
    }
}
