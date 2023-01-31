using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Enterキーが入力された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // SampleSceneに切り替える
            SceneManager.LoadScene("GameScene");
        }
        //Qが入力された場合
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // GuideSceneに切り替える
            SceneManager.LoadScene("GuideScene");
        }
        //ESCキーが入力された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ゲーム終了
            Application.Quit();
        }
    }
}