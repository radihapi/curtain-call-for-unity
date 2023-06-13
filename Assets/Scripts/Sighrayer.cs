using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sighrayer : MonoBehaviour
{
    // 常に、MonoBehaivorとして定期的に呼ばれるゲーム全てを通した管理クラス

    // デバッグ起動オプション
    public bool debug = false; 

    // 状態 [game // 通常ゲーム, monogatari // 物語単体のプレイ , null]
    public string mode = "monogatari"; 


    void Start()
    {
    }
    void Update()
    {
        switch(mode)
        {
            case "monogatari":
                UpdateMonogatari();
                break;
        }
    }

    void UpdateMonogatari()
    {

    }
}
