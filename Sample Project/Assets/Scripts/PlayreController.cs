using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update()はフレーム毎の処理
    // FixedUpadete()は一定時間毎の処理
    // 物理挙動を使用する場合はFixedUpadete()を使用
    void FixedUpdate()
    {
        // Playerを物理挙動を使用して動かす
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    // オブジェクト衝突時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
