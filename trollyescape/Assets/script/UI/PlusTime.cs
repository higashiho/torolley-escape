using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlusTime : MonoBehaviour
{
    // 取得用
    [SerializeField] private Text plusTimeText;
    [SerializeField] private Timer timer;

    // 時間管理用
    private float time;

    // カラー取得用
    private Color getAlphaColor(Color color)
    {
        time += Time.deltaTime * Const.SPEED;
        color.a = Mathf.Sin(time);

        return color;
    }

    // 追加されるPlusTimeを点滅表示
    public void DrawPlusTime() 
    {
        plusTimeText.color = getAlphaColor(plusTimeText.color);
        plusTimeText.text = String.Format("+ {0:00.00}", timer.PlusTime);
    }
}
