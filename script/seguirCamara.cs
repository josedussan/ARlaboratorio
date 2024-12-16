using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirCamara : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    public Vector3 mirar;
    private float ypos;
    
    // Start is called before the first frame update
    void Start()
    {
        ypos = 0.75f;
    }

    public void FixedUpdate()

    {
        //transform.position = cam.position+mirar;
        mirar = cam.transform.position;
        mirar.y = ypos;
        transform.rotation = Quaternion.LookRotation(cam.position);
        //transform.LookAt(new Vector3(0,cam.position.y,0));

        transform.LookAt(mirar);

    }

}
