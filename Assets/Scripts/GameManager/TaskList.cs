using UnityEngine;

public class TaskList : MonoBehaviour
{
    public bool isOpen;
    public bool isOpened;
    public GameObject notifications;
    public GameObject Icons;
    public GameObject backDrop;

    private Animator anim;
    private AudioManager audioSearch;
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
        audioSearch = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioSearch == null)
        {
            Debug.LogError("AudioManager not found. Please make sure the AudioManager is tagged with 'Audio'.");
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && !isOpened)
        {
            anim.SetTrigger("Open");
            isOpened = true;
            notifications.SetActive(false);
            Icons.SetActive(false);
            backDrop.SetActive(true);
            audioSearch.ApplyLowPassFilter(true, 500f);
        }

        if (!isOpen && isOpened)
        {
            anim.SetTrigger("Close");
            isOpened = false;
            notifications.SetActive(true);
            Icons.SetActive(true);
            backDrop?.SetActive(false);
            audioSearch.ApplyLowPassFilter(false);
        }
    }

    public void ToggleTaskList()
    {
        isOpen = !isOpen;
    }
}
