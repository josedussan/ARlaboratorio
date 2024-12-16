using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class acciones : MonoBehaviour
{
    private GameObject[] marquillas;
    [SerializeField]
    private GameObject objeto;
    [SerializeField]
    private AudioSource asource;
    private bool banderamarquillas = false;
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

    public void buscarMarquillas() {
        marquillas = GameObject.FindGameObjectsWithTag("marquilla");
    }

    public void activarMarquilla(float tamano) {
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

    public void activarAudio(bool banderaAudio) {
        Sequence btnAudio = DOTween.Sequence();
        if (banderaAudio)
        {
            asource.Stop();
            asource.Play();
            
            GameObject.Find("btnSonido").transform.DOScale(Vector2.zero, 0.01f);
            GameObject.Find("btnQuitarSonido").transform.DOScale(new Vector2(1, 1), 0.01f);
            btnAudio.Insert(1,GameObject.Find("btnSonido").transform.DOScale(new Vector2(1, 1), 0.01f).SetDelay(asource.clip.length));
            btnAudio.Insert(1,GameObject.Find("btnQuitarSonido").transform.DOScale(new Vector2(0, 0), 0.01f).SetDelay(asource.clip.length));
        }
        else {
            asource.Stop();
            DOTween.KillAll();
            GameObject.Find("btnQuitarSonido").transform.DOScale(Vector2.zero, 0.01f);
            GameObject.Find("btnSonido").transform.DOScale(new Vector2(1, 1), 0.01f);
        }
        
    }

    public void activarAnimacion() {
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
