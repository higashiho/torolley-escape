using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedController : MonoBehaviour
{
    // 取得用
    private Fadeout fadeManager;            //フェイドアウト用
    [SerializeField]
    private GameObject FadeObject;          //フェイドアウト用
    [SerializeField]
    private Slider SpeedGage;               //移動できる距離ゲージ
    [SerializeField] 
    private TrollyController trolly;
    [SerializeField]
    private RectTransform TextPosition;     //テキストの位置
    [SerializeField]
    private GameObject gageObject = null;

    //フェードアウト一回処理用
    private bool FadeOne = true;    
    //今のゲージ量
    private float gage = 100.0f;
    public float Gage{get {return gage;} set {gage = value;}}    
    //ゲージが減る量
    private float gageDownSpeed = 4.0f;
    public float GageDownSpeed{get {return gageDownSpeed;} set {gageDownSpeed = value;}}      
    // プレイヤーのスピード
    private float speedControl;
    public float SpeedControl{get {return speedControl;} set {speedControl = value;}}                    
    //ゲームオーバーになるまでの時
    [SerializeField]
    private float gameOverTime = 2.0f;                      
    // Start is called before the first frame update
    void Start()
    {
        SpeedGage.maxValue = Const.MAX_GAGE;
        SpeedGage.value = Const.MAX_GAGE;
        fadeManager = FadeObject.GetComponent<Fadeout>();
    }

    // Update is called once per frame
    void Update()
    {
        printGage();

        if (trolly.MoveStart)
            Speed();
    }

    // ゲージ表示
    private void printGage()
    {
        Text m_gageText = gageObject.GetComponent<Text>();
        m_gageText.text = "ゲージ残り\n" + Gage.ToString("f0");

        SpeedGage.value = Gage;
    }
    // ゴールしたとき
    public void Goal()
    {
        Gage = 100.0f;
        SpeedGage.value = Gage;
    }

    // ゲームオーバー後の演出用
    private void moveText()
    {
        TextPosition.position += new Vector3(Const.POS_X, 0, 0);
        Text m_gageText = gageObject.GetComponent<Text>();
        m_gageText.text = "ゲージ残り\n" + Gage.ToString("f0");
        m_gageText.fontSize += Const.UP_FONT_SIZE;
    }
    
    // スピード割合管理用
    private void Speed()
    {
        if (Gage >= Const.MAX_GAGE)
            Gage =Const. MAX_GAGE;
        if (Gage <= 0)
            Gage = 0;
        Gage -= GageDownSpeed * Time.deltaTime;
        

        // ゲージがどれだけあるか
        switch (Gage)
        {
            case float i when i <= 0:
                // ゲージ割合が０になったらスピードをなくして一定時間後にフェイドアウトを実施
                SpeedControl = 0;
                gameOverTime -= Time.deltaTime;
                if (gameOverTime <= 0)
                {
                    // フェイドアウトを一回のみ実施
                    if (FadeOne)
                    {
                        FadeOne = false;
                        fadeManager.fadeOutStart(0, "GameOverScene");
                    }
                }
                else
                {
                    moveText();
                }
                break;
            // ゲージ残りが３３以下の場合スピードダウン
            case float i when i <= Const.GAGE_RATIO[0]:
                SpeedControl = Const.SPEED_STATE[0];
                break;
            // ゲージ残りが６６以下の場合スピードダウン
            case float i when i <= Const.GAGE_RATIO[1]:
                SpeedControl = Const.SPEED_STATE[1];
                break;
            // ゲージ残りが６７以上の場合スピード最大値
            case float i when i <= Const.GAGE_RATIO[2]:
                SpeedControl = Const.SPEED_STATE[2];
                break;
            default:
                break;
        }
    }

}
