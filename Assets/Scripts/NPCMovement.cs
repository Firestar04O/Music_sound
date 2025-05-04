using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCMovement : MonoBehaviour
{
    public int speedMovement;
    public bool canMove;
    public float distance;
    public float timeToWait;

    public float distanceThreshold;

    public List<Transform> objectives = new List<Transform>();
    public Transform currentObjective;

    private int currentIndex;
    private bool isWaiting;
    void Start()
    {
        currentIndex = 0;
        isWaiting = false;
        if (objectives.Count > 0)
        {
            currentObjective = objectives[0];
        }
    }
    void Update()
    {
        if (canMove || objectives.Count != 0 || !isWaiting)
        {
            MoveToTarget();
        }
    }
    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentObjective.position, speedMovement * Time.deltaTime);
        float distanceToTarget = Vector3.Distance(transform.position, currentObjective.position);
        if (distanceToTarget <= distanceThreshold)
        {
            StartCoroutine(WaitAndMoveNext());
        }
    }
    IEnumerator WaitAndMoveNext()
    {
        isWaiting = true;
        yield return new WaitForSeconds(timeToWait);

        currentIndex = (currentIndex + 1) % objectives.Count;
        currentObjective = objectives[currentIndex];
        isWaiting = false;
    }
}
