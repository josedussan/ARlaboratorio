using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionCloro : MonoBehaviour
{
    [SerializeField]
    private reaccionScriptableObject reacciones;
    [SerializeField]
    private GameObject particulas, hierro, cloruroDeHierro;
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
    private GameObject letraCloruro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hierro.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, hierro.transform.position) > 14)
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraCloruro.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                hierro.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                hierro.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                cloruroDeHierro.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (contador == 1)
        {
            if (other.gameObject.name == hierro.name)
            {
                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                //asourceExplicacion.PlayOneShot(sonidos[3]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[6].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[6].ecuacion, reacciones.reacciones[6].simboloReaccionEcu, reacciones.reacciones[6].tipoReaccion);
                letraCloruro.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                hierro.transform.GetChild(1).gameObject.SetActive(true);
                hierro.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                efectoParticulas(cloruroDeHierro);
                cloruroDeHierro.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(3.1f);

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
