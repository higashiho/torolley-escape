using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const : MonoBehaviour
{
    // ゲージ消失量
    public const float GAGE_DISAPPEAR = 10.0f;
    // ゲージ回復量
    public const float GAGE_HEEL = 30.0f; 
    // ゲージ最大値
    public const float MAX_GAGE = 100.0f;  
    //止まる時間
    public const float MOVE_STOP = 0.3f;   
    // ランダム値最大値
    public const int MAX_RAND_NUM = 10;
    // Turn回数
    public const int TURN_NUM_MAX = 36;
    // 1フレームごとの回転速度
    public const float TURN_SPEED = 2.5f;
    // コルーチン遅延時間
    public const float WAIT_CORUTINE = 0.01f;
    // テキストのｘ座標固定
    public const float POS_X = 5.0f;   
    // 旋回時の挙動スピード
    public const float TURN_PLAYER_SPEED = 9.0f;
    // 透明度最大値
    public const float MAX_ALPHA = 1.0f;
    // 色変化スピード
    public const float SPEED = 5.0f;
    // 砂時計１つの増加時間
    public const float BOUNUS_TIME = 7.0f;     
    // タイマー白時間
    public const float SAFE_TIMER = 10.0f;
    // フォントサイズ大きくなるスピード
    public const int UP_FONT_SIZE = 2;
    // 遅延時間
    public static readonly float[] WAIT_TIME = {2.5f, 1.0f};   
    //ステージ座標
    public static readonly float[] AREA_NUM = { -45.0f, 172.7f, 351.3f, 550.5f, 786.5f, 989f }; 
    // ゲージ割合定数
    public static readonly int[] GAGE_RATIO = {33, 66, 100};   
    // ゲージごとのスピード   
    public static readonly float[] SPEED_STATE = {10, 15, 20};    
    // 生成範囲固定値
    public static readonly int[] POP_NUM = {4, 9};
    // 生成座標
    public static readonly float[] POS = {1.5f, -45.0f};


}
