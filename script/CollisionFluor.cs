using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionFluor : MonoBehaviour
{
    [SerializeField]
    private reaccionScriptableObject reacciones;
    [SerializeField]
    private GameObject particulas,hidrogeno, fluorhidrico;
    [SerializeField]
    private Image imagenTipoReaccion;
    [SerializeField]
    private List<AudioClip> sonidos;
    [SerializeField]
    private List<TMP_Text> compuestos;
    [SerializeField]
    private TMP_Text tipoReaccion;
    private int contador = 1;
    [SerializeField]
    private AudioSource asource, asourceExplicacion;
    [SerializeField]
    private GameObject letraFluorhidrico;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hidrogeno.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, hidrogeno.transform.position) > 14)
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraFluorhidrico.SetActive(false);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                hidrogeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                fluorhidrico.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (contador == 1)
        {
            if (other.gameObject.name == hidrogeno.name)
            {
                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[5].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[5].ecuacion, reacciones.reacciones[5].simboloReaccionEcu, reacciones.reacciones[5].tipoReaccion);
                letraFluorhidrico.SetActive(true);
                this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                hidrogeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                efectoParticulas(fluorhidrico);
                fluorhidrico.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f).SetDelay(0.1f);

                contador++;
            }
            else
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
        }
    }
    private void reaccionEnPantalla(string ecuacion, Sprite imgReaccion, string tipo)
    {
        imagenTipoReaccion.sprite = imgReaccion;
        tipoReaccion.text = tipo;
        imagenTipoReaccion.gameObject.SetActive(true);
        tipoReaccion.gameObject.SetActive(true);
        string[] palabras = ecuacion.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            compuestos[i].gameObject.SetActive(true);
            compuestos[i].text = palabras[i];
        }

    }

    //ocultar los textmeshpro de la ecuacion
    private void ResetearReaccionEnPantalla()
    {
        imagenTipoReaccion.gameObject.SetActive(false);
        tipoReaccion.gameObject.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            compuestos[i].gameObject.SetActive(false);
        }
    }

    //activar audio de no hay reaccion
    private void accionNoReaccion()
    {
        asource.Stop();
        asourceExplicacion.Stop();
        asource.PlayOneShot(sonidos[5]);
        asourceExplicacion.PlayOneShot(sonidos[4]);
        contador = 1;

    }

    private void efectoParticulas(GameObject contenedor)
    {
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
    }
}
