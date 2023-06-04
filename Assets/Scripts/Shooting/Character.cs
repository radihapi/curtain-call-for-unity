using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public long lifePoint = 1000L;
    float shotWaitTime = 1f;
    Curtain curtain;

    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Curtain").GetComponent<Curtain>();
    }

    // Update is called once per frame
    // 位置の移動を自律的に行う
    void Update()
    {
        if(lifePoint < 0){
            gameObject.SetActive(false);
        }
        
        shotWaitTime -= 10;
        if(shotWaitTime < 0f){
            for(int i = 0; i < 2; i++){
                Bullet bl;
                if(curtain.reserveList.Count != 0) {
                    bl = curtain.reserveList.First.Value;
                    curtain.activeList.AddLast(bl);
                    curtain.reserveList.RemoveFirst();
                }
                else{
                    bl = curtain.activeList.First.Value;
                    curtain.activeList.RemoveFirst();
                    curtain.activeList.AddLast(bl);
                }

                Vector3 pos = transform.position;
                pos.x -= 0.2f;
                pos.x += 0.4f * i;
                pos.y += 0.4f;
                Quaternion rot = Quaternion.identity;
                bl.Shoot(pos,Quaternion.identity,"straight",2);
            }

            shotWaitTime += 1f;
        }
    }
}
