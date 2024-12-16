using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DetectarObjetoCercao : MonoBehaviour
{
    public reaccionScriptableObject reacciones;
    public Image imagenTipoReaccion;
    public GameObject particulas,cloruroDeHierro,cloro,fluor,fluorhidrico,cloruroDeSodio,acidoClorhidrico,HidroxidoDeSodio,hidrogeno, carbono,oxigeno,oxigenosumado,metano,dioxido,agua,hidrogenosumado,dossumado,hierro,oxidoFerroso;
    public List< AudioClip> sonidos;
    public List<TMP_Text> compuestos;
    public TMP_Text tipoReaccion;
    private int contador=1;
    public AudioSource asource,asourceExplicacion;

    public GameObject letraCloruro,letraFluorhidrico,letraCloruroDeSodio,letraOxidoFerroso,letrasAgua, letraDioxido,letrasMetano, esferaagua,humocarbono,humometano,fuego,aguaMetano,dioxidoMetano;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    //mostrar en pantalla la ecuacion de la reaccion
    private void reaccionEnPantalla(string ecuacion,Sprite imgReaccion, string tipo) {
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
    private void ResetearReaccionEnPantalla() {
        imagenTipoReaccion.gameObject.SetActive(false);
        tipoReaccion.gameObject.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            compuestos[i].gameObject.SetActive(false);
        }
    }

    public void reaccionAgua()
    {
        Debug.Log("entra");
        
    }
    //activar audio de no hay reaccion
    private void accionNoReaccion() {
        asource.Stop();
        asourceExplicacion.Stop();
        asource.PlayOneShot(sonidos[5]);
        asourceExplicacion.PlayOneShot(sonidos[4]);
    }
    //efecto de chispas cuando se encuentra una reaccion
    private void efectoParticulas(GameObject contenedor) {
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //espacio de no reacciones
        if (carbono.activeSelf && (metano.activeSelf||hidrogeno.activeSelf||hierro.activeSelf||fluor.activeSelf||cloro.activeSelf||HidroxidoDeSodio.activeSelf||acidoClorhidrico.activeSelf))
        {
            if (Vector3.Distance(carbono.transform.position, metano.transform.position) < 10 ||
                Vector3.Distance(carbono.transform.position, hierro.transform.position) < 10 ||
                Vector3.Distance(carbono.transform.position, hidrogeno.transform.position) < 10 ||
                Vector3.Distance(carbono.transform.position, fluor.transform.position) < 10||
                Vector3.Distance(carbono.transform.position, HidroxidoDeSodio.transform.position) < 10||
                Vector3.Distance(carbono.transform.position, cloro.transform.position) < 10 ||
                Vector3.Distance(carbono.transform.position, acidoClorhidrico.transform.position) < 10)
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }

        if (metano.activeSelf &&  (hidrogeno.activeSelf || hierro.activeSelf || fluor.activeSelf || cloro.activeSelf || HidroxidoDeSodio.activeSelf||acidoClorhidrico.activeSelf))
        {
            if (Vector3.Distance(metano.transform.position, hidrogeno.transform.position) < 10 ||
                Vector3.Distance(metano.transform.position, hierro.transform.position) < 10 || 
                Vector3.Distance(metano.transform.position, fluor.transform.position) < 10 ||
                Vector3.Distance(metano.transform.position, cloro.transform.position) < 10 ||
                Vector3.Distance(metano.transform.position, HidroxidoDeSodio.transform.position) < 10 ||
                Vector3.Distance(metano.transform.position, HidroxidoDeSodio.transform.position) < 10
                )
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }

        if (hierro.activeSelf && (HidroxidoDeSodio.activeSelf || fluor.activeSelf || metano.activeSelf || carbono.activeSelf || hidrogeno.activeSelf||acidoClorhidrico.activeSelf)) {
            if (Vector3.Distance(hierro.transform.position, hidrogeno.transform.position) < 10 ||
                Vector3.Distance(hierro.transform.position, carbono.transform.position) < 10 || 
                Vector3.Distance(hierro.transform.position, fluor.transform.position) < 10 ||
                Vector3.Distance(hierro.transform.position, metano.transform.position) < 10 ||
                Vector3.Distance(hierro.transform.position, HidroxidoDeSodio.transform.position) < 10 ||
                Vector3.Distance(hierro.transform.position, acidoClorhidrico.transform.position) < 10
                )
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        
        }

        if (oxigeno.activeSelf &&(HidroxidoDeSodio.activeSelf||fluor.activeSelf||cloro.activeSelf||acidoClorhidrico.activeSelf)) {
            if (Vector3.Distance(oxigeno.transform.position, acidoClorhidrico.transform.position) < 10 ||
                Vector3.Distance(oxigeno.transform.position, fluor.transform.position) < 10 ||
                Vector3.Distance(oxigeno.transform.position, cloro.transform.position) < 10 ||
                Vector3.Distance(oxigeno.transform.position, HidroxidoDeSodio.transform.position) < 10
                )
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }

        if (hidrogeno.activeSelf && (HidroxidoDeSodio.activeSelf||cloro.activeSelf||acidoClorhidrico.activeSelf))
        {
            if (Vector3.Distance(hidrogeno.transform.position, acidoClorhidrico.transform.position) < 10 ||
                Vector3.Distance(hidrogeno.transform.position, cloro.transform.position) < 10 ||
                Vector3.Distance(hidrogeno.transform.position, HidroxidoDeSodio.transform.position) < 10
                )
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }

        if (cloro.activeSelf && (HidroxidoDeSodio.activeSelf||fluor.activeSelf||acidoClorhidrico.activeSelf)) {
            if (Vector3.Distance(cloro.transform.position, acidoClorhidrico.transform.position) < 10 ||
                Vector3.Distance(cloro.transform.position, fluor.transform.position) < 10 ||
                Vector3.Distance(cloro.transform.position, HidroxidoDeSodio.transform.position) < 10
                )
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }

        if (fluor.activeSelf && (HidroxidoDeSodio||acidoClorhidrico.activeSelf)) {
            if (Vector3.Distance(fluor.transform.position, HidroxidoDeSodio.transform.position) < 10||
                Vector3.Distance(fluor.transform.position, acidoClorhidrico.transform.position) < 10)   
            {
                if (contador == 1)
                {
                    accionNoReaccion();

                }
                contador++;
            }
            else
            {
                contador = 1;
            }
        }
        //fin espacio de no reacciones

        
        //espacio de reacciones

        if (carbono.activeSelf && oxigeno.activeSelf)
        {
            if (Vector3.Distance(oxigeno.transform.position, carbono.transform.position) < 10)
            {
                /*if (contador == 1)
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
                    oxigeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                    dioxido.transform.DOScale(new Vector3(2, 2, 2), 0.2f).SetDelay(0.1f);
                }
                contador++;*/
            }
            else
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraDioxido.SetActive(false);
                ResetearReaccionEnPantalla();
                carbono.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxigeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                dioxido.transform.DOScale(Vector3.zero, 0.1f);
                humocarbono.SetActive(false);
            }
        }
        else if (hidrogeno.activeSelf && oxigeno.activeSelf)
        {
            /*Sequence animAgua = DOTween.Sequence();
            Sequence animHidrogeno = DOTween.Sequence();
            Sequence animOxigeno = DOTween.Sequence();*/
            if (Vector3.Distance(hidrogeno.transform.position, oxigeno.transform.position) < 10)
            {

              /*  if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[1].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[1].ecuacion, reacciones.reacciones[1].simboloReaccionEcu, reacciones.reacciones[1].tipoReaccion);
                    efectoParticulas(agua);
                    animHidrogeno.Append(hidrogenosumado.transform.DOScale(new Vector3(2, 2, 2), 0.1f).SetEase(Ease.InOutBounce).SetDelay(1)).
                        Append(dossumado.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetDelay(1)).
                        Append(hidrogeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(7.5f)).
                        Append(hidrogenosumado.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(7.5f));
                    animOxigeno.Append(oxigeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(10));
                    esferaagua.SetActive(true);
                    animAgua.Append(agua.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(10)).
                        Join(letrasAgua.transform.DOScale(new Vector3(0.53f, 0.53f, 0.53f), 0.1f)).
                        Join(esferaagua.transform.DOScale(new Vector3(5, 5, 5), 0.2f).SetDelay(2));
                    
                }

                contador++;*/
            }
            else
            {
                asourceExplicacion.Stop();
                contador = 1;
                DOTween.KillAll();
                letrasAgua.transform.DOScale(Vector3.zero, 0.1f);
                hidrogenosumado.transform.DOScale(Vector3.zero, 0.1f);
                hidrogeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxigeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                agua.transform.DOScale(Vector3.zero, 0.1f);
                dossumado.transform.DOScale(Vector3.zero, 0.1f);
                esferaagua.SetActive(false);
                desactivarObjetos();
                ResetearReaccionEnPantalla();

            }
        }
        else if (metano.activeSelf && oxigeno.activeSelf)
        {
            /*Sequence animdioxido = DOTween.Sequence();
            Sequence animAgua = DOTween.Sequence();
            Sequence animOxigeno = DOTween.Sequence();
            Sequence animMetano = DOTween.Sequence();*/
            if (Vector3.Distance(metano.transform.position, oxigeno.transform.position) < 10)
            {
              /*  if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    asourceExplicacion.PlayOneShot(sonidos[2]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[2].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[2].ecuacion, reacciones.reacciones[2].simboloReaccionEcu, reacciones.reacciones[2].tipoReaccion);
                    efectoParticulas(dioxidoMetano);
                    animOxigeno.Append(oxigenosumado.transform.DOScale(new Vector3(2, 2, 2), 0.1f).SetDelay(2)).
                    Append(oxigeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(9));
                    animMetano.Append(metano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(11));
                    animdioxido.Append(dioxidoMetano.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).SetEase(Ease.InOutBounce).SetDelay(11)).
                        Join(letrasMetano.transform.DOScale(new Vector3(0.53f, 0.53f, 0.53f), 0.1f).SetEase(Ease.InOutBounce));
                    humometano.SetActive(true);
                    fuego.SetActive(true);
                    animAgua.Append(aguaMetano.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).SetEase(Ease.InOutBounce).SetDelay(11)).
                        Join(humometano.transform.DOScale(new Vector3(0.8001819f, 0.8001819f, 1.170266f), 0.1f)).
                        Join(fuego.transform.DOScale(new Vector3(1, 1, 1.0875f), 0.1f));
                }
                contador++;*/
            }
            else
            {
                DOTween.KillAll();
                asourceExplicacion.Stop();
                contador = 1;
                letrasMetano.transform.DOScale(Vector3.zero, 0.1f);
                oxigenosumado.transform.DOScale(Vector3.zero, 0.1f);
                metano.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxigeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                aguaMetano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                dioxidoMetano.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                humometano.transform.DOScale(Vector3.zero, 0.1f);
                fuego.transform.DOScale(Vector3.zero, 0.1f);
                humometano.SetActive(false);
                fuego.SetActive(false);
                ResetearReaccionEnPantalla();
            }
        }
        else if (hierro.activeSelf && oxigeno.activeSelf) {
            Debug.Log("entra a la reaccion");
            if (Vector3.Distance(hierro.transform.position, oxigeno.transform.position) < 10)
            {
               /* Debug.Log("entra a la deteccion de la distancia");
                if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[3].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[3].ecuacion, reacciones.reacciones[3].simboloReaccionEcu, reacciones.reacciones[3].tipoReaccion);
                    letraOxidoFerroso.transform.DOScale(new Vector3(0.5297956f, 0.5297956f, 0.5297956f), 0.2f).SetDelay(3.1f);
                    hierro.transform.GetChild(1).gameObject.SetActive(true);
                    hierro.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                    oxigeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                    oxidoFerroso.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(3.1f);
                }
                contador++;*/
            }
            else
            {
                contador = 1;
                asourceExplicacion.Stop();
                hierro.transform.GetChild(1).gameObject.SetActive(false);
                hierro.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxigeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                oxidoFerroso.transform.DOScale(Vector3.zero, 0.1f);
                letraOxidoFerroso.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
        else if (acidoClorhidrico.activeSelf && HidroxidoDeSodio.activeSelf) {
            if (Vector3.Distance(acidoClorhidrico.transform.position, HidroxidoDeSodio.transform.position) < 10)
            {
               /* if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    //asourceExplicacion.PlayOneShot(sonidos[3]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[4].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[4].ecuacion, reacciones.reacciones[4].simboloReaccionEcu, reacciones.reacciones[4].tipoReaccion);
                    letraCloruroDeSodio.SetActive(true);
                    acidoClorhidrico.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                    HidroxidoDeSodio.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                    efectoParticulas(cloruroDeSodio);
                    cloruroDeSodio.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(0.1f);
                }
                contador++;*/
            }
            else
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraOxidoFerroso.SetActive(false);
                acidoClorhidrico.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                HidroxidoDeSodio.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                cloruroDeSodio.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
        else if (fluor.activeSelf && hidrogeno.activeSelf) {
            if (Vector3.Distance(fluor.transform.position, hidrogeno.transform.position) < 10)
            {
                /*if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    //asourceExplicacion.PlayOneShot(sonidos[3]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[5].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[5].ecuacion, reacciones.reacciones[5].simboloReaccionEcu, reacciones.reacciones[5].tipoReaccion);
                    letraFluorhidrico.SetActive(true);
                    fluor.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                    hidrogeno.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce);
                    efectoParticulas(fluorhidrico);
                    fluorhidrico.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(0.1f);
                }
                contador++;*/
            }
            else
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraFluorhidrico.SetActive(false);
                fluor.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                hidrogeno.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                fluorhidrico.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
        else if (cloro.activeSelf && hierro.activeSelf) {
            if (Vector3.Distance(cloro.transform.position, hierro.transform.position) < 10)
            {
                /*Debug.Log("detecta la distancia");
                if (contador == 1)
                {
                    asource.Stop();
                    asourceExplicacion.Stop();
                    asource.PlayOneShot(sonidos[0]);
                    //asourceExplicacion.PlayOneShot(sonidos[3]);
                    asourceExplicacion.PlayOneShot(reacciones.reacciones[6].explicacionReaccion);
                    reaccionEnPantalla(reacciones.reacciones[6].ecuacion, reacciones.reacciones[6].simboloReaccionEcu, reacciones.reacciones[6].tipoReaccion);
                    letraCloruro.SetActive(true);
                    cloro.transform.GetChild(1).gameObject.SetActive(true);
                    cloro.transform.GetChild(2).gameObject.SetActive(true);
                    cloro.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                    hierro.transform.GetChild(1).gameObject.SetActive(true);
                    hierro.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InOutBounce).SetDelay(3f);
                    efectoParticulas(cloruroDeHierro);
                    cloruroDeHierro.transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(3.1f);
                }
                contador++;*/
            }
            else
            {
                contador = 1;
                asourceExplicacion.Stop();
                letraCloruro.SetActive(false);
                cloro.transform.GetChild(1).gameObject.SetActive(false);
                cloro.transform.GetChild(2).gameObject.SetActive(false);
                hierro.transform.GetChild(1).gameObject.SetActive(false);
                cloro.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                hierro.transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.InOutBounce);
                cloruroDeHierro.transform.DOScale(Vector3.zero, 0.1f);
                ResetearReaccionEnPantalla();
            }
        }
    }

    public void desactivarObjetos() {
        esferaagua.transform.DOScale(Vector3.zero, 0.1f);

        esferaagua.SetActive(false);
        
    }

    

}

[System.Serializable]
public class reaccionObject
{

    public string idReaccion,ecuacion,tipoReaccion;
    public AudioClip explicacionReaccion;
    public Sprite simboloReaccionEcu;

}