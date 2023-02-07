using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapCamera : MonoBehaviour
{
    // 取得用
    //上から見るカメラ
    [SerializeField]
    private GameObject upCamera;  
    private SpeedController speedController;
    [SerializeField]
    private CameraController cameraController;
    private GameObject trolly = null;
    //上の壁
    [SerializeField]
    private GameObject upWall = null;  
    [SerializeField]
    private List<GameObject> upwalls = new List<GameObject>(5);
    [SerializeField]
    private List<GameObject> upCameras = new List<GameObject>(5);
    // ゴールフラグ
    private bool goalFlag = false;
    public bool GoalFlag{get{return goalFlag;} set{goalFlag = value;}}
    
    // イベント
    public UnityAction FindCallback{get;private set;} = null;


    private void Awake() 
    {
        // イベント追加
        FindCallback += findWall;
        FindCallback += findCamera;
    }
    // Start is called before the first frame update
    void Start()
    {
        trolly = GameObject.FindWithTag("trolly");
        speedController = trolly.gameObject.GetComponent<SpeedController>();
        FindCallback.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraController.PlayerStay && !GoalFlag)
            look();

    }

    //新しい上の壁を探す
    private void findWall()
    {
        upWall = serchTag(trolly, upwalls);
    }

    // 新しい上のカメラを探す
    private void findCamera()
    {
        upCamera = serchTag(trolly, upCameras);
        cameraController.UpCamera = serchTag(trolly, upCameras);
    }

    // マップ確認
    private void look()
    {
        // スタートエリアじゃない場合のマップ確認動作
        if (Input.GetKey(KeyCode.Tab) && !cameraController.StartArea)
        {
            upCamera?.SetActive(true);
            upWall?.SetActive(true);
            speedController.SpeedControl = 0;
            speedController.GageDownSpeed = 0;
        }
        else if(Input.GetKey(KeyCode.Tab))
        {
            cameraController.CameraChange();
        }
        // 通常挙動時
        else
        {
            upCamera?.SetActive(false);
            upWall?.SetActive(false);
            speedController.GageDownSpeed = 4.0f;
        }
    }

    // 一番近いオブジェクト参照用
    private GameObject serchTag(GameObject nowObj, List<GameObject> tmpObj)
    {
        float tmpDis = 0;               //距離用一次変数
        float nearDis = 0;              //最も近いオブジェクトの距離
        GameObject targetObj = null;    //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in tmpObj)
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、0であればオブジェクトを取得
            //一次変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }
}
