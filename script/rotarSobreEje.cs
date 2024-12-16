using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarSobreEje : MonoBehaviour
{
    public float velocidad = -50;
    [SerializeField]
    private ejes eje= ejes.z;

    // Update is called once per frame
    void Update()
    {
        switch (eje) {
            case ejes.x:
                transform.Rotate(new Vector3(velocidad,0,0) * Time.deltaTime);
                break;
            case ejes.y:
                transform.Rotate(new Vector3(0,velocidad, 0) * Time.deltaTime);
                break;
            case ejes.z:
                transform.Rotate(new Vector3( 0, 0,velocidad) * Time.deltaTime);
                break;
        }
        
    }
}
