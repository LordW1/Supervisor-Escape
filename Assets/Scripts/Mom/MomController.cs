using UnityEngine;
using System.Collections;

public class MomController : MonoBehaviour
{
    [SerializeField] private PathNode targetNode;

    [Space]
    [SerializeField] private float moveSpeed;

    [Space]
    [Tooltip("Minimum time that the mom will wait at a node before moving to a new node")]
    [SerializeField] private float minIdleDuration;
    [Tooltip("Maximum time that the mom will wait at a node before moving to a new node")]
    [SerializeField] private float maxIdleDuration;

    private IEnumerator behaviorRoutine;

    private void Start()
    {
        if (targetNode == null)
        {
            Debug.LogError("Target Node has not yet been assigned.");
            return;
        }

        transform.position = targetNode.transform.position;

        StartCoroutine(BehaviorRoutine());
    }

    private IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            float idleDuration = Random.Range(minIdleDuration, maxIdleDuration);
            yield return new WaitForSeconds(idleDuration);

            targetNode = targetNode.GetRandomAdjacent();
            Vector3 prevPos = transform.position;
            Vector3 nextPos = targetNode.transform.position;

            float dist = Vector3.Distance(prevPos, nextPos);
            float travelDuration = dist / moveSpeed;

            for (float t = 0f; t < travelDuration; t += Time.deltaTime)
            {
                float ratio = Mathf.InverseLerp(0f, travelDuration, t);

                transform.position = Vector3.Lerp(prevPos, nextPos, ratio);

                yield return new WaitForEndOfFrame();
            }

            transform.position = nextPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // do something when the mom catches the player!
            // btw the plyer object needs to have the tag "Player"
        }
    }
}
