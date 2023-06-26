using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Everything is a story.
public class Monogatari : MonoBehaviour
{
    float shotWaitTime = 1f;
    Curtain curtain;
    Sighrayer sighrayer;

    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Curtain").GetComponent<Curtain>();
        sighrayer = GameObject.Find("Sighrayer").GetComponent<Sighrayer>();

        sighrayer.monogatariName = "じゃんけん";
        sighrayer.monogatariNameTop = "じゃん";
        sighrayer.monogatariNameBottom = "けん";
        sighrayer.monogatariNameSub = "じゃんけん";
        sighrayer.monogatariNameCenter = ""; // 文字が入ると中央文字の演出になる
        sighrayer.monogatariNameDisplayingPhase = 1;

        sighrayer.monogatariLifePoint = 1000;
        sighrayer.monogatariMaxLifePoint = 1000;

         // 秒数で指定
        sighrayer.monogatariTimeLimit = 90;
        sighrayer.monogatariMaxTimeLimit = 90;
    }

    // Update is called once per frame
    void Update()
    {
        sighrayer.monogatariTimeLimit -= WorldTime.fixedDeltaTime;
    }
}
