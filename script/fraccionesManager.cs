using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class fraccionesManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objetos,opciones;
    [SerializeField]
    private Sprite correcto, incorrecto;
    [SerializeField]
    private Image imagen;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<AudioClip> sonidos;
    private bool banderaPanel = true;
    [SerializeField]
    private GameObject particulas;
    private int numero, opcionAnterior=2;

    // Start is called before the first frame update
    void Start()
    {
        ocultarObjetos();
        numero = Random.Range(1, objetos.Count);
        LlenarOpciones();
        opcionVerdadera(numero);
        LlenarTorta(numero);

    }

    void LlenarOpciones() {
        for (int i=0;i<opciones.Count;i++) {
            opciones[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text= Random.Range(1, objetos.Count).ToString();
            opciones[i].transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = Random.Range(5, objetos.Count).ToString();
        }
    }
    public void CerrarPanel(RectTransform panel)
    {
        if (banderaPanel)
        {
            panel.DOScale(Vector3.zero, 0.1f);
            banderaPanel = false;
        }
        else
        {
            panel.DOScale(new Vector3(1, 1, 1), 0.1f);
            banderaPanel = true;
        }

    }

    public void click(Button btn)
    {
       double numerador = int.Parse(btn.transform.GetChild(0).GetComponent<TMP_Text>().text);
        double denominador = int.Parse(btn.transform.GetChild(2).GetComponent<TMP_Text>().text);
        double resultado = numerador / denominador;
        double resultadoCorrecto = (double)numero / 8;
        if(resultado==resultadoCorrecto)
        {
            var numer = Random.Range(1, objetos.Count);
            numero = numer;
            LlenarTorta(numero);
            LlenarOpciones();
            opcionVerdadera(numero);
            MostrarMensajeRespuesta(correcto);
            asource.PlayOneShot(sonidos[0]);
        }
        else
        {
            Debug.Log("incorrecto");
            MostrarMensajeRespuesta(incorrecto);
            asource.PlayOneShot(sonidos[1]);
        }
    }

    private void LlenarTorta(int num)
    {
        ocultarObjetos();
        for (int i = 0; i < num; i++)
        {
            GameObject efecto = Instantiate(particulas, objetos[i].transform);
            Destroy(efecto, 1);
            objetos[i].SetActive(true);
        }
    }

    void opcionVerdadera(int num)
    {
        int numOpcion = Random.Range(0,3);
        Debug.Log(numOpcion+" opcion anterior "+opcionAnterior);
        if (numOpcion == opcionAnterior)
        {
            Debug.Log("entra al si");
            opcionVerdadera(num);
        }
        else {
            Debug.Log("entra al sino");
            opciones[numOpcion].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = num.ToString();
            opciones[numOpcion].transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "8";
            opcionAnterior = numOpcion;
        }
        
    }

    private void ocultarObjetos()
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            objetos[i].SetActive(false);

        }
    }

    private void MostrarMensajeRespuesta(Sprite img) {
        imagen.sprite = img;
        imagen.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        imagen.transform.DOScale(Vector3.zero, 0.1f).SetDelay(0.7f);
    }
}
