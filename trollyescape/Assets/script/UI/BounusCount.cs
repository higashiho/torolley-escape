using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounusCount : MonoBehaviour
{
    // 砂時計を取った個数
    private int countBounus = 0;
    public int CountBounus{get {return countBounus;}set {countBounus = value;}}
    // ボーナスフラグ
    private bool drawBounus;
    public bool DrawBounus{get{return drawBounus;} set{drawBounus = value;}}
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "HourGlass")
        {

            CountBounus++;
            DrawBounus = true;
        }
    }
}