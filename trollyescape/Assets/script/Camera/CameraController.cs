using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 取得用
    //上から見るカメラ
    [SerializeField]
    private GameObject upCamera;    
    public GameObject UpCamera{get {return upCamera;}set {upCamera = value;}}

    // プレイヤーがステージにいるか
    [SerializeField]
    private bool playerStay = false;
    public bool PlayerStay{get {return playerStay;}set {playerStay = value;}} 

    //プレイヤーがスタート地点にいるかどうか
    [SerializeField]
    private bool startArea = false;
    public bool StartArea{get {return startArea;} set {startArea = value;}}
   // プレイヤーカメラとマップカメラ切り替え
    public void CameraChange()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            UpCamera.SetActive(true);
        }
        else
        {
            UpCamera.SetActive(false);
        }
    }
}
