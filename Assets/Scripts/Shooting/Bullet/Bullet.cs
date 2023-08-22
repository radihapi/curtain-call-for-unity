using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Bullet : MonoBehaviour
{
    Vector3 direct;
    float speed;
    private bool isRender = false;
    private string category; // どういった攻撃か。主に見た目に反映
    private string color; // 色がある一部の弾丸でのみ指定する色
    private string motionType; // どういった攻撃か。主に動き方に反映
    private string mode; // 弾によっては使われる、動きを制御する為の変数

    public void Shoot(
            string category, string color,
            string motionType,
            Vector3 pos, Quaternion rot,
            float speed = 300f
        ){
        this.motionType = motionType;

        switch(motionType){
            case "straight":
                direct = rot * Vector3.down;
                transform.SetPositionAndRotation(pos,rot);
                break;
        }
        
        isRender = true;
        gameObject.SetActive(true);
    }

    public void Observe(int index){
        switch(motionType){
            case "straight":
                Vector3 move = direct * 30f * WorldTime.fixedDeltaTime;
                transform.Translate(move, Space.World);
        
                SpriteRenderer rdr = GetComponent<SpriteRenderer>();
                rdr.sortingOrder = index;
                break;
        }

    }
}
