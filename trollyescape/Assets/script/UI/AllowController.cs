using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowController : MonoBehaviour
{
    [SerializeField]
    private GameObject leftAllowParent;
    [SerializeField]
    private GameObject rightAllowParent;
    public RawImage LeftAllow{get; private set;}
    public RawImage RightAllow{get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        LeftAllow = leftAllowParent.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        RightAllow = rightAllowParent.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        AllowReset();
    }

    // 初期化
    public void AllowReset()
    {
        LeftAllow.enabled = false;
        RightAllow.enabled = false;
    }

}
