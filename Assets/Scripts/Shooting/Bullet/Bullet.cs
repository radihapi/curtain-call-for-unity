using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Bullet : MonoBehaviour
{
    Vector3 direct;
    float speed;
    private bool isRender = false;

    public void Shoot(Vector3 pos, Quaternion rot, string mode, float speed = 300f){
        switch(mode){
            case "straight":
            direct = rot * Vector3.down;
            transform.SetPositionAndRotation(pos,rot);
            break;
        }
        
        isRender = true;
        gameObject.SetActive(true);
    }

    public void Observe(int index){
        Vector3 move = direct * 30f * WorldTime.fixedDeltaTime;
        transform.Translate(move, Space.World);

        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        rdr.sortingOrder = index;
    }
}
