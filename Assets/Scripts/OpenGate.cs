using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public float moveSpeed = 1f; // Tốc độ di chuyển của cửa
    public float moveDistance = 6f; // Khoảng cách di chuyển của cửa

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isDoorOpen;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + Vector3.up * moveDistance;
        isDoorOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!isDoorOpen)
                OpenDoor();
            else
                CloseDoor();
        }
    }

    private void OpenDoor()
    {
        isDoorOpen = true;
        // Di chuyển cửa lên trên
        StartCoroutine(MoveDoor(targetPosition));
    }

    private void CloseDoor()
    {
        isDoorOpen = false;
        // Di chuyển cửa trở lại vị trí ban đầu
        StartCoroutine(MoveDoor(originalPosition));
    }

    private System.Collections.IEnumerator MoveDoor(Vector3 target)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, target);
        
        while (transform.position != target)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);
            yield return null;
        }
    }
}
