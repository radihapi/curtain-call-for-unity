using System.Collections;
using System.Collections.Generic;

static public class WorldTime
{
    static public bool despairKaleidoScope = false;

    // シューティングゲームでの全時間に関わる
    static public float fixedDeltaTime{
        set;
        get;
    } = 0.00166667f;

    static public void startDespairKaleidoScope(){
        fixedDeltaTime = 0.000833334f;
    }

    static public void endDespairKaleidoScope(){
        fixedDeltaTime = 0.00166667f;
    }
}
