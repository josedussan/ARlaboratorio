using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class acciones : MonoBehaviour
{
    private GameObject[] marquillas;
    [SerializeField]
    private GameObject objeto;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<Sprite> imgsBtnSonido, imgsBtnAnimacion;
    [SerializeField]
    private GameObject btnAudio;    
    private bool banderamarquillas = false;
    private bool banderaAudio = true;
    //private bool banderaAudio = false;

    public UnityEvent evento;
    // Start is called before the first frame update
    void Start()
    {
        marquillas = GameObject.FindGameObjectsWithTag("marquilla");
        evento.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuscarMarquillas() {
        marquillas = GameObject.FindGameObjectsWithTag("marquilla");
    }

    public void ActivarMarquilla(float tamano) {
        if (objeto != null) {
            desactivarAnimacion();
        }
        if (!banderamarquillas) { 

            banderamarquillas = true;
            for (int i = 0; i < marquillas.Length; i++)
            {
                marquillas[i].transform.DOScale(new Vector3(tamano, tamano,tamano), 0.1f);
            }
        }else {
            banderamarquillas = false;
            for (int i = 0; i < marquillas.Length; i++)
            {
                marquillas[i].transform.DOScale(Vector3.zero, 0.1f);
            }
        }

    }

    public void ActivarAudio() {
        Debug.Log(banderaAudio);
        if (banderaAudio)
        {
            banderaAudio = false;
            asource.Stop();
            asource.Play();
            btnAudio.transform.GetComponent<Image>().sprite = imgsBtnSonido[1];
            StartCoroutine(esperarAudio());
           // banderaAudio = false;
        }
        else {

            asource.Stop();
            StopCoroutine(esperarAudio());
            StopAllCoroutines();
            btnAudio.transform.GetComponent<Image>().sprite = imgsBtnSonido[0];
            banderaAudio = true;
        }
        
    }
    IEnumerator esperarAudio() {
        yield return new WaitForSeconds(asource.clip.length);
        btnAudio.transform.GetComponent<Image>().sprite = imgsBtnSonido[0];
    }

    public void ActivarAnimacion() {
        objeto.GetComponent<Animation>().Play();
        GameObject.Find("btnPlay").transform.DOScale(Vector2.zero, 0.01f);
        GameObject.Find("btnStop").transform.DOScale(new Vector2(1, 1), 0.01f);
        if (banderamarquillas) {
            banderamarquillas = false;
            for (int i = 0; i < marquillas.Length; i++)
            {
                marquillas[i].transform.DOScale(Vector3.zero, 0.1f);
            }
        }
    }

    public void desactivarAnimacion() {
        objeto.GetComponent<Animation>().Stop();
        GameObject.Find("btnStop").transform.DOScale(Vector2.zero, 0.01f);
        GameObject.Find("btnPlay").transform.DOScale(new Vector2(1, 1), 0.01f);
    }

    public void pararAudio()
    {
        asource.Stop();

    }

    public void panelAyuda(bool act) {
        if (act)
        {
            GameObject.Find("PanelAyuda").transform.DOScale(new Vector3(1, 1,1), 0.01f);
        }
        else {
            GameObject.Find("PanelAyuda").transform.DOScale(Vector3.zero, 0.01f);
        }
    }
}
