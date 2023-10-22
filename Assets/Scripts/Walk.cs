using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của nhân vật
    public float stopTimeInSeconds = 2f; // Thời gian dừng lại (số giây)

    private bool shouldMove = true;

    void Start()
    {
        Invoke("StopMovement", stopTimeInSeconds);
    }

    void Update()
    {
        if (shouldMove)
        {
            // Di chuyển nhân vật về phía trước
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void StopMovement()
    {
        shouldMove = false; // Dừng di chuyển
        Debug.Log("Nhân vật đã dừng lại.");
    }
}
