using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionOxigeno : MonoBehaviour
{
    [SerializeField]
    private reaccionScriptableObject reacciones;
    [SerializeField]
    private GameObject particulas,dioxido,carbono,hidrogeno,agua,hidrogenosumado,dossumado,oxigenosumado,metano,hierro, oxidoFerroso;
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
    public GameObject letraCloruro, letraFluorhidrico, letraCloruroDeSodio, letraOxidoFerroso, letrasAgua, letraDioxido, letrasMetano, esferaagua, humocarbono, humometano, fuego, aguaMetano, dioxidoMetano;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (carbono.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, carbono.transform.position) > 14)
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraDioxido.SetActive(false);
                ResetearReaccionEnPantalla();
                carbono.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                dioxido.transform.DOScale(Vector3.zero, 0.1f);
                humocarbono.SetActive(false);
            }
        }
        
        if (hidrogeno.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, hidrogeno.transform.position) > 14)
            {
                asourceExplicacion.Stop();
                contador = 1;
                DOTween.KillAll();
                letrasAgua.transform.DOScale(Vector3.zero, 0.1f);
                hidrogenosumado.transform.DOScale(Vector3.zero, 0.1f);
                hidrogeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                agua.transform.DOScale(Vector3.zero, 0.1f);
                dossumado.transform.DOScale(Vector3.zero, 0.1f);
                esferaagua.SetActive(false);
                desactivarObjetos();
                ResetearReaccionEnPantalla();
            }
        }

        if (metano.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, metano.transform.position) > 14)
            {
                DOTween.KillAll();
                asourceExplicacion.Stop();
                contador = 1;
                letrasMetano.transform.DOScale(Vector3.zero, 0.1f);
                oxigenosumado.transform.DOScale(Vector3.zero, 0.1f);
                metano.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                aguaMetano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                dioxidoMetano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                humometano.transform.DOScale(Vector3.zero, 0.1f);
                fuego.transform.DOScale(Vector3.zero, 0.1f);
                humometano.SetActive(false);
                fuego.SetActive(false);
                ResetearReaccionEnPantalla();
            }
        }
        if (hierro.activeSelf && this.gameObject.activeSelf)
        {
            if (Vector3.Distance(this.transform.position, hierro.transform.position) > 14)
            {
                contador = 1;
                asourceExplicacion.Stop();
                hierro.transform.GetChild(1).gameObject.SetActive(false);
                hierro.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                this.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxidoFerroso.transform.DOScale(Vector3.zero, 0.1f);
                letraOxidoFerroso.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
    }
    public void desactivarObjetos()
    {
        esferaagua.transform.DOScale(Vector3.zero, 0.1f);

        esferaagua.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (contador == 1)
        {

            if (other.gameObject.name == carbono.name)
            {

                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                //asourceExplicacion.PlayOneShot(sonidos[3]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[0].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[0].ecuacion, reacciones.reacciones[0].simboloReaccionEcu, reacciones.reacciones[0].tipoReaccion);
                efectoParticulas(dioxido);
                letraDioxido.SetActive(true);
                humocarbono.SetActive(true);
                carbono.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                dioxido.transform.DOScale(new Vector3(2, 2, 2), 0.2f).SetDelay(0.1f);
                contador++;
            }
            else if (other.gameObject.name == hidrogeno.name)
            {
                Sequence animAgua = DOTween.Sequence();
                Sequence animHidrogeno = DOTween.Sequence();
                Sequence animOxigeno = DOTween.Sequence();
                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[1].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[1].ecuacion, reacciones.reacciones[1].simboloReaccionEcu, reacciones.reacciones[1].tipoReaccion);
                efectoParticulas(agua);
                animHidrogeno.Append(hidrogenosumado.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).SetEase(Ease.InOutBounce).SetDelay(1)).
                    Append(dossumado.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetDelay(1)).
                    Append(hidrogeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(7.5f)).
                    Append(hidrogenosumado.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(7.5f));
                animOxigeno.Append(this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(10));
                esferaagua.SetActive(true);
                animAgua.Append(agua.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f).SetDelay(10)).
                    Join(letrasAgua.transform.DOScale(new Vector3(0.53f, 0.53f, 0.53f), 0.1f)).
                    Join(esferaagua.transform.DOScale(new Vector3(4, 4, 4), 0.2f).SetDelay(2));
                contador++;
            }
            else if (other.gameObject.name == metano.name)
            {

                Sequence animdioxido = DOTween.Sequence();
                Sequence animAgua = DOTween.Sequence();
                Sequence animOxigeno = DOTween.Sequence();
                Sequence animMetano = DOTween.Sequence();
                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                asourceExplicacion.PlayOneShot(sonidos[2]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[2].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[2].ecuacion, reacciones.reacciones[2].simboloReaccionEcu, reacciones.reacciones[2].tipoReaccion);
                efectoParticulas(dioxidoMetano);
                animOxigeno.Append(oxigenosumado.transform.DOScale(new Vector3(2, 2, 2), 0.1f).SetDelay(2)).
                Append(this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(9));
                animMetano.Append(metano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(11));
                animdioxido.Append(dioxidoMetano.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f).SetEase(Ease.InOutBounce).SetDelay(11)).
                    Join(letrasMetano.transform.DOScale(new Vector3(0.53f, 0.53f, 0.53f), 0.1f).SetEase(Ease.InOutBounce));
                humometano.SetActive(true);
                fuego.SetActive(true);
                animAgua.Append(aguaMetano.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f).SetEase(Ease.InOutBounce).SetDelay(11)).
                    Join(humometano.transform.DOScale(new Vector3(0.8001819f, 0.8001819f, 1.170266f), 0.1f)).
                    Join(fuego.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f));
                contador++;
            }
            else if (other.gameObject.name == hierro.name)
            {
                asource.Stop();
                asourceExplicacion.Stop();
                asource.PlayOneShot(sonidos[0]);
                asourceExplicacion.PlayOneShot(reacciones.reacciones[3].explicacionReaccion);
                reaccionEnPantalla(reacciones.reacciones[3].ecuacion, reacciones.reacciones[3].simboloReaccionEcu, reacciones.reacciones[3].tipoReaccion);
                letraOxidoFerroso.transform.DOScale(new Vector3(0.5297956f, 0.5297956f, 0.5297956f), 0.2f).SetDelay(3.1f);
                hierro.transform.GetChild(1).gameObject.SetActive(true);
                hierro.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                this.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                oxidoFerroso.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(3.1f);
                contador++;
            }
            else {
                Debug.Log("entra al else");
                if (contador == 1)
                {
                    Debug.Log("evalua el if con: "+contador);
                    accionNoReaccion();

                }
            }
            
        }
        
       
    }
    

    //mostrar en pantalla la ecuacion de la reaccion
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
