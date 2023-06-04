using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMain : MonoBehaviour
{
    Vector3 direct;
    float speed = 300f;
    private bool isRender = false;

    Character chara;

    public bool Run(int index, float time){
        Vector3 move = direct * 30f * WorldTime.fixedDeltaTime;
        transform.Translate(move, Space.World);

        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        rdr.sortingOrder = index;

        bool ret = isRender;

        // 攻撃判定
        if(chara != null){
            if(chara.transform.position.x <= transform.position.x + 1 &&
                chara.transform.position.x >= transform.position.x - 1 &&
                chara.transform.position.y <= transform.position.y + 1 &&
                chara.transform.position.y >= transform.position.y - 1
            ){
                chara.lifePoint -= 1;
                isRender = false;
            }
        }

        // 大きな座標に到達したら削除
        if(Mathf.Abs(transform.position.x) > 10f || Mathf.Abs(transform.position.y) > 10f){
            isRender = false;
        }

        return ret;
    }

    public void Shoot(Vector3 pos, Quaternion rot,float spd){
        direct = rot * Vector3.up;
        speed = spd;
        transform.SetPositionAndRotation(pos,rot);
        
        try{
            chara = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
        }catch{
            chara = null;
        }

        isRender = true;
        gameObject.SetActive(true);
    }

    public void Vanish(){
        isRender = false;
        gameObject.SetActive(false);
    }
}
