using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageDown : MonoBehaviour
{
    // 取得用
    private GameObject Trolly;
    private SpeedController speedController;

    

    // Start is called before the first frame update
    void Start()
    {
        Trolly = GameObject.Find("trolly");
        speedController = Trolly.gameObject.GetComponent<SpeedController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trolly")
        {
            speedController.Gage -= Const.GAGE_DISAPPEAR;
        }
    }
}
