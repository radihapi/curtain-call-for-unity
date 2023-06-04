using System.Collections;
using System.Collections.Generic;

// 静的クラスとして呼ばれる時間クラス　時が遅くなったような処理落ちを狙う
static public class WorldTime
{
    static private float fixedDeltaTimeValue = 0.00166667f;
    static private float timeScaleValue = 1;
    static public bool despairKaleidoScope = false;

    // シューティングゲームでの全時間に関わる
    static public float fixedDeltaTime{
        set{
            fixedDeltaTimeValue = value;
        }
        get{
            return fixedDeltaTimeValue;
        }
    }

    static public float timeScale{
        set{
            fixedDeltaTimeValue = 0.00166667f * value;
            timeScaleValue = value;
        }
        get{
            return timeScaleValue;
        }
    }

    static public void startDespairKaleidoScope(){
        timeScale = 0.5f;
    }

    static public void endDespairKaleidoScope(){
        timeScale = 1f;
    }
}
