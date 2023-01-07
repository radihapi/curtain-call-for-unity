using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMain : MonoBehaviour
{
    Vector3 direct = Vector3.forward;
    float speed = 300f;
    private bool isRender = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 大きな座標に到達したら削除
        if(Mathf.Abs(transform.position.x) > 10f || Mathf.Abs(transform.position.y) > 10f){
            isRender = false;
        }
    }

    public bool Run(int index, float time){
        Vector3 move = direct * 30f * WorldTime.fixedDeltaTime;
        transform.Translate(move, Space.World);

        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        rdr.sortingOrder = index;

        bool ret = isRender;
        // isRender = false; 理由不明、バグるので外している
        return ret;
    }

    public void Shoot(Vector3 pos, Quaternion rot,float spd){
        direct = rot * Vector3.up;
        speed = spd;
        transform.SetPositionAndRotation(pos,rot);

        isRender = true;
        gameObject.SetActive(true);
    }

    public void Vanish(){
        isRender = false;
        gameObject.SetActive(false);
    }
}
