using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Spaceキーが入力された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // StartSceneに切り替える
            SceneManager.LoadScene("StartScene");
        }
        //ESCキーが入力された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ゲーム終了
            Application.Quit();
        }
    }
}
