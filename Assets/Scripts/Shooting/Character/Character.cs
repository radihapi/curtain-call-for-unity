using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public long lifePoint = 1000L;
    Curtain curtain;
    GameObject monogatariObject;
    Monogatari monogatari;
    Sighrayer sighrayer;
    public long t = 1; // 時間管理、update最後で++
    public string mode = "monogatari"; // 物語モードなど
    public string phase = "ready"; // 状態遷移全般

    
    float shotWaitTime = 1f;

    // 手動で設定するコンストラクタ
    void Setup()
    {

    }

    void Start()
    {
        curtain = GameObject.Find("Curtain").GetComponent<Curtain>();
        sighrayer = GameObject.Find("Sighrayer").GetComponent<Sighrayer>();
        transform.position = Libra.PixelVectorToWorldVector(-100, -100);

        sighrayer.playerLifePoint = 2;
        sighrayer.playerHeroPoint = 3;
    }

    void Update()
    {
        if(lifePoint < 0){
            gameObject.SetActive(false);
        }else{
            sighrayer.monogatariLifePoint = lifePoint;
        }

        if(phase == "ready"){
            transform.position = Libra.EasingInOut(Libra.PixelVectorToWorldVector(-100, -100), Libra.PixelVectorToWorldVector(385, 150), t, 1000);

            if(transform.position == Libra.PixelVectorToWorldVector(385, 150)){
                monogatariObject = new GameObject("monogatari");
                monogatari = monogatariObject.AddComponent<Monogatari>();
                phase = "monogatari";
            }
        }

        if(phase == "monogatari"){
            // monogatari.update();
            // transform.position = monogatari.updatePosition(transform.position);
        
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

                shotWaitTime += 1000f;
            }
        }

        t++;
    }
}
