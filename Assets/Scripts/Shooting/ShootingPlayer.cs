using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
