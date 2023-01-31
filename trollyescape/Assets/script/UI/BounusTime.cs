using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BounusTime : MonoBehaviour
{
    [SerializeField] private Text bounusTimeText;
    [SerializeField] private Timer timer;
    [SerializeField] private BounusCount bounusCount;

    // 時間管理用
    private float time;

    // カラー変更用
    private Color getAlphaColor(Color color)
    {
        time += Time.deltaTime * Const.SPEED;
        color.a = Mathf.Sin(time);

        return color;
    }

    // 追加されるBounusTimeを点滅表示
    public void DrawBonusTime()    
    {
        bounusTimeText.color = getAlphaColor(bounusTimeText.color);
        bounusTimeText.text = String.Format("+ {0:00.00}", Const.BOUNUS_TIME * bounusCount.CountBounus);
    }
}