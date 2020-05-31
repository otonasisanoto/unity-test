using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;

    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        float x = joystick.Horizontal * speed;
        float y = joystick.Vertical * speed;
        // 現在のpotionに値を加算してオグジェクトを移動
        this.gameObject.transform.position = new Vector3(pos.x + x, pos.y + y, pos.z);
    }
}
