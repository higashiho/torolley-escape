using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamItem : MonoBehaviour
{
    // 取得用
    [SerializeField]
    private GameObject HourGlass;   //砂時計
    [SerializeField]
    private HourGlassController hourGlassController;

    // ランダム値代入用
    [SerializeField]
    private int randValue = 0; 

    // 1/2でのアイテム生成
    public void RandGanerator()
    {
        randValue = Random.Range(0, Const.MAX_RAND_NUM);
        switch (randValue)
        {
            // ０以上４以下の場合非生成
            case int i when i <= Const.POP_NUM[0]:
                HourGlass.SetActive(false);
                break;
            // ５以上９以下の場合生成
            case int i when i <= Const.POP_NUM[1]:
                HourGlass.SetActive(true);
                break;
            default:
                break;
        }
    }
}
