using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera.enabled = true;
        MainCamera.enabled = !PlayerCamera.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerCamera.enabled = !PlayerCamera.enabled;
            MainCamera.enabled = !MainCamera.enabled;
        }
    }
}
