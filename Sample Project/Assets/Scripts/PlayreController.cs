using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayreController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;
    private Rigidbody rb;

    public Text pointCountText;
    private int pointCount;

    public Text gameoverText;
    public Text gameclearText;

    private int pointMax;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        pointCount = 0;
        SetPointCountText();

        gameoverText.gameObject.SetActive(false);

        gameclearText.gameObject.SetActive(false);

        pointMax = GameObject.Find("Points").transform.childCount; // アイテム数を取得
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
        // ポイント獲得時
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            pointCount++;
            SetPointCountText();

            // ゲームクリア時
            if(pointCount >= pointMax)
            {
                gameclearText.gameObject.SetActive(true);
                Time.timeScale = 0; // ゲームの停止(Update関数内など止まらないところもある)
            }
        }

        // ゲームオーバー時
        if(other.gameObject.CompareTag("Gameover"))
        {
            gameoverText.gameObject.SetActive(true);
            Time.timeScale = 0; // ゲームの停止(Update関数内など止まらないところもある)
        }
    }

    void SetPointCountText()
    {
        pointCountText.text = "PointCount : " + pointCount.ToString();
    }
}
