using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassController : MonoBehaviour
{
    [SerializeField]
    private GameObject HourGlass;   //砂時計




    private void OnTriggerEnter(Collider col)
    {
        //　トロッコと当たったら表示削除
        if (col.gameObject.tag == "trolly")
        {
            Debug.Log("Hit");
            HourGlass.SetActive(false);
        }
    }
}
