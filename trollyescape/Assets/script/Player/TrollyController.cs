using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrollyController : MonoBehaviour
{
    //　取得用
    [SerializeField] private CameraController cameraController;   //カメラcontroller
    [SerializeField] private SpeedController speedController;
    [SerializeField]
    private PlayerTurn playerTurn;
    [SerializeField]
    private AllowController allowController;
    [SerializeField]
    private Fadeout fadeManager;




    //処理待ち時間
    private const float WAIT_TIME = 0.15f; 
    // トロッコのスピード
    public float PlayerSpeed;
    // 挙動開始フラグ
    public bool MoveStart = false;
    //ターンするかしないか
    private bool TurnStart = false; 
    // 右に曲がるフラグ
    [SerializeField]
    private bool right = false;
    public bool Right{get {return right;} private set{right = value;}}
    // 左に曲がるフラグ
    [SerializeField]
    private bool left = false;
    public bool Left{get {return left;} private set {left = value;}}
    //壁に当たったか
    private bool wallHit = false;   
    //ターンを一回のみ処理する用
    [SerializeField] private bool turnOne = true;    
    // 旋回ポイントにいるか
    [SerializeField] private bool turnPoint = false;
    // 旋回したか
    public bool TurnFlag {get ;private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputKey();

        if (MoveStart)
            move();
        if (TurnStart) 
            Invoke(nameof(turnPlayer), WAIT_TIME);
    }

    // キー入力管理関数
    private void inputKey()
    {
        // 左に曲がるフラグ管理
        judgeFlag(KeyCode.D, ref right,  ref left, allowController.RightAllow, allowController.LeftAllow);
        
        // 右に曲がるフラグ管理
        judgeFlag(KeyCode.A, ref left, ref right, allowController.LeftAllow, allowController.RightAllow);
        
        // 挙動開始
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MoveStart = true;
        }
    }

    // フラグオン管理関数
    // 第一引数：キー入力コード　第二引数：オンにしたいフラグ　第三引数：オフにしたいフラグ
    // 第四引数：表示させたい矢印オブジェクト　第五引数：非表示にしたい矢印オブジェクト
    private void judgeFlag(KeyCode keyCode, ref bool flag, ref bool unFlag, RawImage allow, RawImage unAllow)
    {
        if (Input.GetKeyDown(keyCode) && !playerTurn.TurnNow)
        {
            unFlag = false;
            unAllow.enabled = false;
            Debug.Log("in");

            if (flag)
            {
                Debug.Log("false");
                flag = false;
                allow.enabled = false;
            }
            else
            {
                Debug.Log("true");
                flag = true;
                allow.enabled = true;
            }
        }
    }

    // 挙動
    private void move()
    {
        // 壁に当たった時の処理
        if (wallHit)
        {
            PlayerSpeed = 0.0f;
            //Invoke(nameof(loadScene), Const.WAIT_TIME[1]);
        }
        // 旋回場所以外の場合
        else if (!turnPoint)
        {
            PlayerSpeed = speedController.SpeedControl;
        }
        this.transform.position += transform.forward * PlayerSpeed * Time.deltaTime;
    }

    // シーン転移時使用
    private void loadScene()
    {
        fadeManager.fadeOutStart(0, "GameOverScene"); //Fadeout.csの中のフェードアウト開始関数呼び出し
        
    }

    //プレイヤーターンのTurn関数を使用
    private void turnPlayer()
    {
        playerTurn.Turn();
        TurnFlag = true;
    }

    //ターン後の変数リセット
    public void Reset()
    {
        Left = false; Right = false;
        TurnStart = false;
        turnPoint = false;
        allowController.AllowReset();
    }

    // 当たり判定
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TurnPoint")
        {
            // 右に曲がるフラグか左に曲がるフラグがたっているとき旋回するフラグを立てる
            if (Right || Left)
                if (turnOne)
                {
                    turnPoint = true;
                    PlayerSpeed = Const.TURN_PLAYER_SPEED;
                }

        }
        if (col.gameObject.tag == "Turn")
        {
            if(turnPoint)
            {
                TurnStart = true;
            }
        }
        if (col.gameObject.tag == "wall")
        {
            wallHit = true;
        }
        
        if (col.gameObject.tag == "StartArea")
        {
            cameraController.StartArea = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StartArea")
        {
            cameraController.StartArea = false;
        }
        if (other.gameObject.tag == "TurnPoint")
        {
            turnOne = true;
            TurnFlag = false;
        }
    }
}
