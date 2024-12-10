using UnityEngine;

public class TaskList : MonoBehaviour
{
    public bool isOpen;
    public bool isOpened;
    public GameObject notifications;
    public GameObject Icons;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
        //notifications.SetActive(true);
        //Icons.SetActive(true);
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
        }

        if (!isOpen && isOpened)
        {
            anim.SetTrigger("Close");
            isOpened = false;
            notifications.SetActive(true);
            Icons.SetActive(true);

        }
    }

    public void ToggleTaskList()
    {
        isOpen = !isOpen;
    }
}
