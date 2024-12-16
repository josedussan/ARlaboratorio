using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class detectarToque : MonoBehaviour
{
    private string nombreObjeto;
    private Touch toque;
    managerMapa manMapa;
    public UnityEvent funcion;
    // Start is called before the first frame update
    void Start()
    {
        nombreObjeto = GetComponent<Transform>().name;
        Debug.Log(nombreObjeto);
    }

    public void OnMouseDown()
    {
        funcion?.Invoke();
        //manMapa.MostrarInfo(nombreObjeto);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            toque = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(toque.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider != null && hit.transform.name.Equals(nombreObjeto))
                {
                    //manMapa.MostrarInfo(nombreObjeto);
                    funcion?.Invoke();
                }

            }

        }
    }
}
