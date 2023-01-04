using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    const float FastSpeed = 4.0f;
    const float SlowSpeed = 2.0f;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = FastSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);

        // 上下左右操作
        if (Input.GetKey (KeyCode.UpArrow)) {
          transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.DownArrow)) {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        // 低速移動切り替え
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = SlowSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = FastSpeed;
        }
    }
}
