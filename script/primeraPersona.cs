using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primeraPersona : MonoBehaviour
{
    public bool gyroEnable;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;
    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnable = EnableGyro();
    }

    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        else {
            joystick.SetActive(true);
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnable) {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
