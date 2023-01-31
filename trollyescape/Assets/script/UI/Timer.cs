using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // 取得用
    [SerializeField]
    private BounusCount bounusCount;
    [SerializeField] private Text timerText;
    [SerializeField] private Text timeUpObj = null;
    [SerializeField] private Text plusTimeObj = null;
    [SerializeField] private Text bounusTimeObj = null;
    [SerializeField] private PlusTime plusTime;
    [SerializeField] private BounusTime bounusTime;



    // タイマー管理フラグ
    [SerializeField] private bool countStop = true;
    //ゴールしたときに増える時間   
    public float PlusTime{get;private set;} = 0;         
    //ゴールしたかどうか   
    private bool goalFlag = false;  
    public bool GoalFlag{get{return goalFlag;} set{goalFlag = value;}}                          
    // Display表示フラグ
    [SerializeField] 
    private bool drawPlusTime = false; 
    //カウントダウンタイム
    [SerializeField]
    private float countDownTime = 40.0f;  
    private void Start() 
    {
        PlusTime = 15.0f;
    }
    // Update is called once per frame
    void Update()
    {
        timerControll();
        
        timeEnd();
        timerColor();
        printPlasTimer();
    }

    // タイマー管理用
    private void timerControll()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            countStop = false;
            Debug.Log("EnterKey");
        }
        if (!countStop)
        {
            //経過時間を引く
            countDownTime -= Time.deltaTime;    

            //ゴールについたら以下の処理をする
            if (GoalFlag && !drawPlusTime)  
            {
                drawPlusTime = true;
                //2.5秒後にタイム追加
                Invoke(nameof(timePlus), Const.WAIT_TIME[0]); 
                 //2.5秒後に追加時間を非表示
                Invoke(nameof(plusTimeOff), Const.WAIT_TIME[0]);
                // カウント停止フラグオン
                countStop = true;
                Debug.Log("on");
            }
        }

        //カウントダウンタイムを整形して表示
        timerText.text = String.Format("{0:00.00}", countDownTime);
    }

    // ゲームオーバー判定
    private void timeEnd()
    {

        //0.0秒以下は固定
        if (countDownTime <= 0.0f)
        {
            countDownTime = 0.0f;
            timeUpObj.enabled = true;
            Invoke(nameof(loadScene), Const.WAIT_TIME[1]);
        }
    }
    // タイマーの色設定
    private void timerColor()
    {
        if (countDownTime >= Const.SAFE_TIMER)
        {
            // 10秒以上の時の文字色白
            timerText.color = new Color(1, 1, 1, 1);    
        }
        else
        {
            // 10秒以下の時の文字色赤
            timerText.color = new Color(1, 0, 0, 1);    
        }
    }

    // +Time表示
    private void printPlasTimer()
    {
        if (drawPlusTime)
        {
            plusTimeOn();
            plusTime.DrawPlusTime();

            // 砂時計を取っている場合
            if (bounusCount.DrawBounus)
            {
                bounusTime.DrawBonusTime();
            }
        }
    }


    // シーン転移時使用
    private void loadScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    // タイマーカウント増加時使用
    private void timePlus()
    {
        countDownTime += PlusTime;
        countDownTime += Const.BOUNUS_TIME * bounusCount.CountBounus;
        bounusCount.DrawBounus = false;

    }

    // テキスト非表示
    private void plusTimeOff()
    {
        drawPlusTime = false;
        timeUpObj.enabled = false;
        bounusTimeObj.enabled = false;
    }

    // テキスト表示
    private void plusTimeOn()
    {
        plusTimeObj.enabled = true;
        bounusTimeObj.enabled = true;
    }
}