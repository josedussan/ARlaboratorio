using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirCamara : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;  // C�mara de Vuforia (normalmente es la ARCamera en tu escena)
    public float rotationSpeed = 2f;  // Velocidad de rotaci�n (ajustable)
    public float smoothingFactor = 0.1f;  // Factor de suavizado para la rotaci�n

    private Vector3 previousCameraRotation;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        previousCameraRotation = arCamera.transform.eulerAngles;
    }

    public void Update()

    {
        // Obtenemos la rotaci�n actual de la c�mara.
        Vector3 currentCameraRotation = arCamera.transform.eulerAngles;

        // Calculamos la diferencia entre la rotaci�n actual y la anterior.
        Vector3 rotationDelta = currentCameraRotation - previousCameraRotation;

        // Aplicamos el suavizado utilizando un factor de interpolaci�n.
        targetRotation = Quaternion.Euler(
            transform.eulerAngles.x + rotationDelta.x * smoothingFactor,
            transform.eulerAngles.y + rotationDelta.y * smoothingFactor,
            transform.eulerAngles.z + rotationDelta.z * smoothingFactor
        );

        // Rotamos el objeto suavemente hacia la rotaci�n objetivo.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Actualizamos la rotaci�n anterior de la c�mara para la pr�xima iteraci�n.
        previousCameraRotation = currentCameraRotation;

    }

}
