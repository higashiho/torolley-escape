using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassRotate : MonoBehaviour
{

    [SerializeField] private float RotateX;
    [SerializeField] private float RotateZ;
    [SerializeField] private float RotateY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(RotateX, RotateY, RotateZ));
    }
}
