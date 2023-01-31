using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraController : MonoBehaviour
{
    //カメラcontroller
    [SerializeField] private CameraController cameraController;   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "trolly")
        {
            cameraController.StartArea = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "trolly")
        {
            cameraController.StartArea = false;
        }
    }
}
