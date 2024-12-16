using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroParabolico : MonoBehaviour
{
    public GameObject ballGo;
    public Transform objTrans;
    public float h = 10;
    private float gravity = -9.8f;
    private Touch toque;
    private string nombreObjeto;
    [Range(1,10)]
    public float numPuntos;
    // Start is called before the first frame update
    void Start()
    {
        nombreObjeto = GetComponent<Transform>().name;
    }

    public void OnMouseDown()
    {
        lanzar();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            toque = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(toque.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider != null)
                {
                    lanzar();
                }
                
            }

        }

        
    }

    public void lanzar() {
        Rigidbody ballRB = ballGo.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * gravity;
        ballRB.useGravity = true;
        ballRB.velocity = calcularVelocidadInicial();
    }

    public Vector3 calcularVelocidadInicial() {
        Vector3 desplazamientoP = objTrans.position - ballGo.transform.position;
        float velocidadY, velocidadX, velocidadZ;
        velocidadZ = Mathf.Sqrt(-2 * gravity * h);
        velocidadX = desplazamientoP.x / ((-velocidadZ / gravity) + Mathf.Sqrt(2 * (desplazamientoP.z - h) / gravity));
        velocidadY = desplazamientoP.z / ((-velocidadZ / gravity) + Mathf.Sqrt(2 * (desplazamientoP.z - h) / gravity));
        return new Vector3(velocidadX,velocidadZ,velocidadY);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        DibujarLineas();
    }

    void DibujarLineas() {
        Vector3 desde, hacia;
        Vector3 velInicial = calcularVelocidadInicial();
        float tiempoTotal = calcularTiempoTotal(velInicial.y);
        float tiempoActual = 0;
        float paso = tiempoTotal/numPuntos;

        hacia = ballGo.transform.position;
        while (tiempoActual<=tiempoTotal) {
            desde = hacia;
            hacia = calcularDesplazamiento(velInicial, tiempoActual);
            Gizmos.DrawLine(desde,hacia);
            tiempoActual += paso;
        }

    }

    float calcularTiempoTotal(float velInicialY) => -velInicialY / gravity + Mathf.Sqrt(2*(objTrans.position.z-h)/gravity);

    Vector3 calcularDesplazamiento(Vector3 velInicial, float tiempoActual) {
        float desplazamientoY, desplazamientoX, desplazamientoZ;
        desplazamientoY = velInicial.y * tiempoActual + gravity * tiempoActual * tiempoActual / 2;
        desplazamientoX = velInicial.x * tiempoActual;
        desplazamientoZ = velInicial.z * tiempoActual;
        return new Vector3(desplazamientoX,desplazamientoY,desplazamientoZ);
    }
}
