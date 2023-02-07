using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalFlag : MonoBehaviour
{
    // 取得用
    [SerializeField]
    private TrollyController trolly;
    [SerializeField]
    private RandStage randStage;
    [SerializeField] private Timer timer;
    [SerializeField]
    private SpeedController speedController;
    [SerializeField]
    private BounusCount bounusCount;
    [SerializeField]
    private MapCamera mapCamera;


    //Goalエリアに触って何秒経ったか
    private float moveCount = 0;   
    //迷路を一回だけ生成
    private bool mazeOne = true;    
    // スコア
    public static int score{get;private set;} = 0;    


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            //mapCamera.GameStart = false;
            moveCount += Time.deltaTime;
            if (moveCount >= Const.MOVE_STOP)
            {
                trolly.MoveStart = false;
                // ゴールフラグがオフの場合オンにする
                if(!timer.GoalFlag)
                {
                    mapCamera.GoalFlag = true;
                    timer.GoalFlag = true;
                }
                if (mazeOne)
                {
                    mazeOne = false;
                    // 2.5秒後にステージ移動
                    Invoke(nameof(moveNewArea), Const.WAIT_TIME[0]);
                    score++;
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            // 初期化処理
            speedController.Gage = Const.MAX_GAGE;
            mazeOne = true;
            moveCount = 0;
            mapCamera.GoalFlag = false;
            timer.GoalFlag = false;
            bounusCount.CountBounus = 0;
        }
    }

    // エリア移動
    private void moveNewArea()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        randStage.AreaCreate();
        mapCamera.FindCallback.Invoke();
    }
}