using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của nhân vật
    public float stopTimeInSeconds = 60f; // Thời gian dừng lại (số giây)

    private bool shouldMove = true;

    void Start()
    {
        Invoke("StopMovement", stopTimeInSeconds);
    }

    void Update()
    {
        if (shouldMove)
        {
            // Di chuyển nhân vật về phía bên phải với góc nghiêng 8 độ
            float angle = 5f;
            Vector3 dir = Quaternion.Euler(0, angle, 0) * transform.right;
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    void StopMovement()
    {
        shouldMove = false; // Dừng di chuyển
        Debug.Log("Nhân vật đã dừng lại.");
    }
}