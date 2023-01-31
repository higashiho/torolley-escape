using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    //Scoreテキスト
    public GameObject Score_Object = null;  

    // Update is called once per frame
    void Update()
    {
        Text m_scoreText = Score_Object.GetComponent<Text>();

        m_scoreText.text = GoalFlag.score + "pt";
    }
}
