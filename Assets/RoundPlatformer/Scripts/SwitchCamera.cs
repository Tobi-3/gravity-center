using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera.enabled = true;
        PlayerCamera.enabled = !MainCamera.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MainCamera.enabled = !MainCamera.enabled;
            PlayerCamera.enabled = !PlayerCamera.enabled;
        }
    }
}
