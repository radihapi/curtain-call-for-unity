using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sighrayer : MonoBehaviour
{
    // 常に、MonoBehaivorとして定期的に呼ばれるゲーム全てを通した管理クラス

    // デバッグ起動オプション
    public bool debug = false; 

    // 状態 [game // 通常ゲーム, monogatari // 物語単体のプレイ , null]
    public string mode = "monogatari"; 

    public long t = 0;

    public long playerLifePoint;
    public long playerHeroPoint;

    // 画面上部UI
    public string monogatariName;
    private GameObject monogatariNameObject;
    private TextMeshPro monogatariNameText;
    public long monogatariLifePoint;
    public long monogatariMaxLifePoint;
    private GameObject monogatariLifePointObject;
    private LineRenderer monogatariLifePointLine;
    public float monogatariTimeLimit;
    public float monogatariMaxTimeLimit;
    private GameObject monogatariTimeLimitObject;
    private LineRenderer monogatariTimeLimitLine;
    private GameObject monogatariTimeLimitSecondObject;
    private LineRenderer monogatariTimeLimitSecondLine;

    // 物語宣言演出用
    public long monogatariNameDisplayingPhase = 0;
    public long monogatariNameDisplayngStartT = 0L;
    public string monogatariNameTop = "";
    public string monogatariNameBottom = "";
    public string monogatariNameCenter = "";
    public string monogatariNameSub = "";
    private GameObject monogatariNameTopObject;
    private TextMeshPro monogatariNameTopText;
    private GameObject monogatariNameBottomObject;
    private TextMeshPro monogatariNameBottomText;
    private GameObject monogatariNameCenterObject;
    private TextMeshPro monogatariNameCenterText;
    private GameObject monogatariNameSubObject;
    private TextMeshPro monogatariNameSubText;


    void Start()
    {
        // 画面上部UI初期化
        monogatariNameObject = new GameObject("monogatariName");
        monogatariNameText = monogatariNameObject.AddComponent<TextMeshPro>();
        monogatariNameText.fontSize = 2;
        monogatariNameText.faceColor = new Color32(255, 255, 255, 255);
        monogatariNameText.characterSpacing = -10;
        monogatariNameText.enableWordWrapping = false;
        monogatariNameObject.SetActive(false);

        monogatariLifePointObject = new GameObject("monogatariLifePoint");
        monogatariLifePointLine = monogatariLifePointObject.AddComponent<LineRenderer>();
        monogatariLifePointLine.positionCount = 4;
        monogatariLifePointLine.startWidth = 0.02f;
        monogatariLifePointLine.endWidth = 0.02f;
        monogatariLifePointLine.material = new Material(Shader.Find("Sprites/Default"));
        monogatariLifePointLine.startColor = Color.gray;
        monogatariLifePointLine.endColor = Color.gray;
        monogatariLifePointObject.SetActive(false);

        monogatariTimeLimitSecondObject = new GameObject("monogatariTimeLimitSecond");
        monogatariTimeLimitSecondLine = monogatariTimeLimitSecondObject.AddComponent<LineRenderer>();
        monogatariTimeLimitSecondLine.positionCount = 4;
        monogatariTimeLimitSecondLine.startWidth = 0.02f;
        monogatariTimeLimitSecondLine.endWidth = 0.02f;
        monogatariTimeLimitSecondLine.material = new Material(Shader.Find("Sprites/Default"));
        monogatariTimeLimitSecondLine.startColor = Color.black;
        monogatariTimeLimitSecondLine.endColor = Color.black;
        monogatariLifePointObject.SetActive(false);

        monogatariTimeLimitObject = new GameObject("monogatariTimeLimit");
        monogatariTimeLimitLine = monogatariTimeLimitObject.AddComponent<LineRenderer>();
        monogatariTimeLimitLine.positionCount = 4;
        monogatariTimeLimitLine.startWidth = 0.02f;
        monogatariTimeLimitLine.endWidth = 0.02f;
        monogatariTimeLimitLine.material = new Material(Shader.Find("Sprites/Default"));
        monogatariLifePointLine.startColor = Color.gray;
        monogatariLifePointLine.endColor = Color.gray;
        monogatariLifePointObject.SetActive(false);


        // 物語宣言演出初期化
        monogatariNameTopObject = new GameObject("monogatariNameTop");
        monogatariNameBottomObject = new GameObject("monogatariNameBottom");
        monogatariNameCenterObject = new GameObject("monogatariNameCenter");
        monogatariNameSubObject = new GameObject("monogatariNameSub");
        monogatariNameTopText = monogatariNameTopObject.AddComponent<TextMeshPro>();
        monogatariNameTopText.fontSize = 50;
        monogatariNameTopText.faceColor = new Color32(255, 255, 255, 100);
        monogatariNameTopText.characterSpacing = -20;
        monogatariNameTopText.enableWordWrapping = false;
        monogatariNameBottomText = monogatariNameBottomObject.AddComponent<TextMeshPro>();
        monogatariNameBottomText.fontSize = 50;
        monogatariNameBottomText.faceColor = new Color32(255, 255, 255, 100);
        monogatariNameBottomText.characterSpacing = -20;
        monogatariNameBottomText.enableWordWrapping = false;
        monogatariNameSubText = monogatariNameSubObject.AddComponent<TextMeshPro>();
        monogatariNameSubText.fontSize = 4;
        monogatariNameSubText.faceColor = new Color32(255, 255, 255, 150);
        monogatariNameSubText.enableWordWrapping = false;
        monogatariNameCenterText = monogatariNameCenterObject.AddComponent<TextMeshPro>();
        monogatariNameCenterText.fontSize = 10;
        monogatariNameCenterText.faceColor = new Color32(255, 255, 255, 100);
        monogatariNameCenterText.enableWordWrapping = false;

        monogatariNameTopObject.SetActive(false);
        monogatariNameBottomObject.SetActive(false);
        monogatariNameCenterObject.SetActive(false);
        monogatariNameSubObject.SetActive(false);
    }
    void Update()
    {
        switch(mode)
        {
            case "monogatari":
                UpdateMonogatari();
                break;
        }

        if(monogatariNameDisplayingPhase >= 1) UpdateMonogatariDisplay();

        if(t > 1500) UpdateMonogatariUI();

        t++;
    }

    void UpdateMonogatari()
    {

    }

    void UpdateMonogatariUI()
    {
        // 物語の名前
        monogatariNameText.text = monogatariName;
        monogatariNameText.rectTransform.sizeDelta = new Vector2(monogatariNameText.preferredWidth,monogatariNameText.preferredHeight);
        monogatariNameObject.transform.position = Libra.PixelVectorToWorldVector(385, 20);
        monogatariNameObject.SetActive(true);

        // 物語のLP
        monogatariLifePointObject.SetActive(true);
        monogatariLifePointLine.SetPosition(0, Libra.PixelVectorToWorldVector(10, 5));
        monogatariLifePointLine.SetPosition(1, Libra.PixelVectorToWorldVector(760 * monogatariLifePoint / monogatariMaxLifePoint, 5));
        monogatariLifePointLine.SetPosition(2, Libra.PixelVectorToWorldVector(760 * monogatariLifePoint / monogatariMaxLifePoint, 7));
        monogatariLifePointLine.SetPosition(3, Libra.PixelVectorToWorldVector(10, 7));

        // 物語の時間制限
        monogatariTimeLimitObject.SetActive(true);
        monogatariTimeLimitLine.SetPosition(0, Libra.PixelVectorToWorldVector(10 + (long)monogatariTimeLimit / (long)monogatariMaxTimeLimit, 36));
        monogatariTimeLimitLine.SetPosition(1, Libra.PixelVectorToWorldVector(760, 36));
        monogatariTimeLimitLine.SetPosition(2, Libra.PixelVectorToWorldVector(760, 38));
        monogatariTimeLimitLine.SetPosition(3, Libra.PixelVectorToWorldVector(10 + (long)monogatariTimeLimit / (long)monogatariMaxTimeLimit, 38));
        
        monogatariTimeLimitSecondObject.SetActive(true);
        monogatariTimeLimitSecondLine.SetPosition(0, Libra.PixelVectorToWorldVector(10, 36));
        monogatariTimeLimitSecondLine.SetPosition(1, Libra.PixelVectorToWorldVector(10 + 750 * ((long)monogatariMaxTimeLimit - (long)monogatariTimeLimit) / (long)monogatariMaxTimeLimit, 36));
        monogatariTimeLimitSecondLine.SetPosition(2, Libra.PixelVectorToWorldVector(10 + 750 * ((long)monogatariMaxTimeLimit - (long)monogatariTimeLimit) / (long)monogatariMaxTimeLimit, 38));
        monogatariTimeLimitSecondLine.SetPosition(3, Libra.PixelVectorToWorldVector(10, 38));
    }

    void UpdateMonogatariDisplay()
    {
        if(monogatariNameCenter == ""){
            if(monogatariNameDisplayingPhase == 1) {
                monogatariNameDisplayngStartT = t;
    
                monogatariNameTopObject.SetActive(true);
                monogatariNameBottomObject.SetActive(true);
                monogatariNameSubObject.SetActive(true);
    
                monogatariNameTopText.text = monogatariNameTop;
                monogatariNameBottomText.text = monogatariNameBottom;
                monogatariNameSubText.text = monogatariNameSub;
    
                monogatariNameTopText.rectTransform.sizeDelta = new Vector2(monogatariNameTopText.preferredWidth,monogatariNameTopText.preferredHeight);
                monogatariNameBottomText.rectTransform.sizeDelta = new Vector2(monogatariNameBottomText.preferredWidth,monogatariNameBottomText.preferredHeight);
                monogatariNameSubText.rectTransform.sizeDelta = new Vector2(monogatariNameSubText.preferredWidth,monogatariNameSubText.preferredHeight);
    
                monogatariNameDisplayingPhase = 2;
            }
    
            if(monogatariNameDisplayingPhase == 2){
                monogatariNameTopObject.transform.position =  Libra.EasingInOut(Libra.PixelVectorToWorldVector(- (long)monogatariNameTopText.preferredWidth * 100 / 2, 200), Libra.PixelVectorToWorldVector((long)monogatariNameTopText.preferredWidth * 100 / 2, 200), t, monogatariNameDisplayngStartT + 1500);
                monogatariNameBottomObject.transform.position =  Libra.EasingInOut(Libra.PixelVectorToWorldVector((long)monogatariNameBottomText.preferredWidth * 100 + 700, 620), Libra.PixelVectorToWorldVector(700 - (long)monogatariNameBottomText.preferredWidth * 100 / 2, 620), t, monogatariNameDisplayngStartT + 1500);
                monogatariNameSubObject.transform.position =  Libra.EasingInOut(Libra.PixelVectorToWorldVector(300, 610), Libra.PixelVectorToWorldVector(400, 610), t, monogatariNameDisplayngStartT + 1500);
            }
    
            
            if(t - monogatariNameDisplayngStartT > 1500) {
                monogatariNameDisplayingPhase = 0;
                monogatariNameTopObject.SetActive(false);
                monogatariNameBottomObject.SetActive(false);
                monogatariNameSubObject.SetActive(false);
            }
        }else{
            if(monogatariNameDisplayingPhase == 1) {
                monogatariNameCenterText.text = monogatariNameCenter;
                monogatariNameCenterText.rectTransform.sizeDelta = new Vector2(monogatariNameCenterText.preferredWidth,monogatariNameCenterText.preferredHeight);
                monogatariNameCenterObject.transform.position = Libra.PixelVectorToWorldVector(385, 400);
                monogatariNameCenterObject.SetActive(true);
                monogatariNameDisplayingPhase = 2;
            }
    
            if(monogatariNameDisplayingPhase == 2){
                if(t % 30 == 0) monogatariNameCenterObject.transform.position = Libra.Quake(Libra.PixelVectorToWorldVector(385, 400));
            }
            
            if(t - monogatariNameDisplayngStartT > 2000) {
                monogatariNameDisplayingPhase = 0;
                monogatariNameCenterObject.SetActive(false);
            }
        }

    }
}
