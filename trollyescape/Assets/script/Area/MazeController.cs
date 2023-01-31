using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    // 取得用
    [SerializeField]
    private MapCamera mapCamera;
    [SerializeField]
    private RandamItem[] randamItem;
    [SerializeField]
    private CameraController cameraController;


    // 以下当たり判定
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "trolly")
        {
            // プレイヤーが判定内に来たらアイテムを出現させるか判断
            for (int i = 0; i < randamItem.Length; ++i)
            {
                randamItem[i].RandGanerator();
            }
            cameraController.PlayerStay = true;
            Debug.Log("playerStayNow");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "trolly")
        {
            cameraController.PlayerStay = false;
        }
    }

}
