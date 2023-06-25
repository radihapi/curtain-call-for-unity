using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Libra
{
    // イージング関数
    // 当初Lerp()の使用を想定していたが、オーバーシュートの表現ができない為Vector3を返す関数となった
    public static Vector3 EasingInOut(Vector3 startVector, Vector3 goalVector, float t, float goalT)
    {
        goalVector -= startVector;
        t /= goalT / 2;
        if (t < 1) return goalVector / 2 * t * t + startVector;
        
        t -= 1;
        return -goalVector / 2 * ( t * (t - 2) - 1) + startVector;
    }

    // 予備動作と反動つき
    public static Vector3 EasingInOutPlus(Vector3 startVector, Vector3 goalVector, float t, float goalT, float plusAlpha = 4.4f)
    {
        goalVector -= startVector;
        t /= goalT / 2;
        if(t < 1) return goalVector / 2 * ( t * t * ((plusAlpha + 1) * t - plusAlpha)) + startVector;

        t -= 2;
        return goalVector / 2 * ( t * t * ((plusAlpha + 1) * t + plusAlpha) + 2) + startVector;
    }

    // 震えるオブジェクト
    public static Vector3 Quake(Vector3 vector, float d = 0.1f)
    {
        return new Vector3(vector.x + Random.Range(-d, d), vector.y + Random.Range(-d, d), 0);
    }


    // シューティングモードの左上を0,0としたxy座標からVector3に変換する処理
    // タイトルモードで使っても良いが、基本UIで足りるはずなのでシューティングモード優先
    
    // 画面の左上と右下のワールド座標
    private static float topLeftX = -7.08f;
    private static float topLeftY = 5.5f;
    private static float bottomRightX = 0.62f;
    private static float bottomRightY = -3.5f;

    // カスタム座標系のサイズ
    private static float customWidth = 770.0f;
    private static float customHeight = 900.0f;
    
    private static float worldWidth = bottomRightX - topLeftX;
    private static float worldHeight = topLeftY - bottomRightY;

    public static Vector3 PixelVectorToWorldVector(long x, long y, float z = 0)
    {
        // ワールド座標系でのwidthとheightを計算
        float worldWidth = bottomRightX - topLeftX;
        float worldHeight = topLeftY - bottomRightY;

        // カスタム座標系からワールド座標系への変換
        float worldX = topLeftX + (x / customWidth) * worldWidth;
        float worldY = topLeftY - (y / customHeight) * worldHeight;

        return new Vector3(worldX, worldY, z);
    }
}
