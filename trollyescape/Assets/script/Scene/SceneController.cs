using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    // 取得用
    private Fadeout fadeManager;
    [SerializeField]
    private GameObject fadeObject;
    [SerializeField]    // 説明UI表示タイムライン
    private PlayableDirector description;
    [SerializeField]    // 説明UI非表示タイムライン
    private PlayableDirector unDescription;

    // シーン挙動フラグ
    private bool sceneMove = true;
    public bool SceneMove{get {return sceneMove;} set {sceneMove = value;}}
    // 説明UIが出ているか
    private bool descriptionFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        fadeManager = fadeObject.GetComponent<Fadeout>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (SceneMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "GameOverScene")
            {
                SceneMove = false;
                fadeManager.fadeOutStart(0, "StartScene"); //Fadeout.csの中のフェードアウト開始関数呼び出し
            }

            if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "StartScene") 
            {
                SceneMove = false;
                fadeManager.fadeOutStart(0, "GameScene"); //Fadeout.csの中のフェードアウト開始関数呼び出し
            }

            if (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().name == "StartScene") 
            {
                if(!descriptionFlag)
                {
                    description.Play();
                    descriptionFlag = true;
                }
                else
                {
                    unDescription.Play();
                    descriptionFlag = false;
                }
            }
        }
    }
}
