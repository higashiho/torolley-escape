using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    Fadeout fadeManager;
    public GameObject FadeObject;
    // Start is called before the first frame update
    void Start()
    {
        fadeManager = FadeObject.GetComponent<Fadeout>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Invoke(nameof(LoadScene), Const.WAIT_TIME[1]);
        }
    }

    void LoadScene()
    {
        fadeManager.fadeOutStart(0, "GameOverScene");
    }
}
