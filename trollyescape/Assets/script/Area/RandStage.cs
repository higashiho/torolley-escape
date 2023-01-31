using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandStage : MonoBehaviour
{

    private int number; //ランダムステージ

    [SerializeField]
    private GameObject trolly;

    //ランダムなエリア移動
    public void AreaCreate()
    {
        Debug.Log(Const.AREA_NUM.Length);
        number = Random.Range(0, Const.AREA_NUM.Length);
        trolly.transform.position = new Vector3(Const.AREA_NUM[number], Const.POS[0], Const.POS[1]);
    }

}
