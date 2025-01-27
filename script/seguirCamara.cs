using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirCamara : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;  // Cámara de Vuforia (normalmente es la ARCamera en tu escena)
    public float rotationSpeed = 2f;  // Velocidad de rotación (ajustable)
    public float smoothingFactor = 0.1f;  // Factor de suavizado para la rotación

    private Vector3 previousCameraRotation;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        previousCameraRotation = arCamera.transform.eulerAngles;
    }

    public void Update()

    {
        // Obtenemos la rotación actual de la cámara.
        Vector3 currentCameraRotation = arCamera.transform.eulerAngles;

        // Calculamos la diferencia entre la rotación actual y la anterior.
        Vector3 rotationDelta = currentCameraRotation - previousCameraRotation;

        // Aplicamos el suavizado utilizando un factor de interpolación.
        targetRotation = Quaternion.Euler(
            transform.eulerAngles.x + rotationDelta.x * smoothingFactor,
            transform.eulerAngles.y + rotationDelta.y * smoothingFactor,
            transform.eulerAngles.z + rotationDelta.z * smoothingFactor
        );

        // Rotamos el objeto suavemente hacia la rotación objetivo.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Actualizamos la rotación anterior de la cámara para la próxima iteración.
        previousCameraRotation = currentCameraRotation;

    }

}
