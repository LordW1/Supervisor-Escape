using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    public Outline remote;  // Reference to the Outline component
    public Outline lamp;  // Reference to the Outline component
    public Outline trash;  // Reference to the Outline component
    public Outline money;  // Reference to the Outline component
    public Outline firePlace;
    public Outline sharpFurniture;
    private bool isFadedOut = true;  // Track if the outline is currently faded out (initially true)

    void Start()
    {
        // Start with a basic solid white outline, no fade
        remote.AnimateOutline(5f, new Color(1f, 1f, 1f, 0f), 0.1f);  // Start with transparent white and fade in
        lamp.AnimateOutline(5f, new Color(1f, 1f, 1f, 0f), 0.1f);  // Start with transparent white and fade in
    }

    void Update()
    {
        // Toggle fade in and out on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFadedOut)
            {
                // Fade in (alpha = 1, visible white)
                remote.AnimateOutline(5f, new Color(1f, 1f, 1f, 1f), 0.1f);
                // Fade in (alpha = 1, visible white)
                lamp.AnimateOutline(5f, new Color(1f, 1f, 1f, 1f), 0.1f);
            }
            else
            {
                // Fade out (alpha = 0, transparent white)
                remote.AnimateOutline(5f, new Color(1f, 1f, 1f, 0f), 0.1f);

                // Fade out (alpha = 0, transparent white)
                lamp.AnimateOutline(5f, new Color(1f, 1f, 1f, 0f), 0.1f);
            }

            ScreenShake.instance.TriggerShake(0.2f, 0.4f);
            // Toggle the faded state
            isFadedOut = !isFadedOut;
        }
    }
}
