using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class anatomiaManager : MonoBehaviour
{
    private GameObject[] leyendaCirculacion, leyendaOseo, leyendaUrinario, leyendaNervioso, leyendaDigestivo, leyendaRespiratorio,leyendaMuscular;
    [SerializeField]
    private List<GameObject> sistemas;
    [SerializeField]
    private GameObject mitadCuerpo;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<AudioClip> explicaciones;
    [SerializeField]
    private TMP_Text texto;
    [SerializeField]
    private GameObject particulas, contenedor;
    // Start is called before the first frame update
    void Start()
    {
        leyendaCirculacion = GameObject.FindGameObjectsWithTag("circulatorio");
        leyendaOseo = GameObject.FindGameObjectsWithTag("oseo");
        leyendaUrinario = GameObject.FindGameObjectsWithTag("urinario");
        leyendaNervioso= GameObject.FindGameObjectsWithTag("nervioso");
        leyendaDigestivo = GameObject.FindGameObjectsWithTag("digestivo");
        leyendaRespiratorio = GameObject.FindGameObjectsWithTag("respiratorio");
        leyendaMuscular = GameObject.FindGameObjectsWithTag("muscular");

        Invoke("desactivarLeyendas",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void cambiarTexto(string nombre) {
        texto.text = nombre;
    }

    public void quitarPiel() {
        if (mitadCuerpo.activeSelf)
        {
            mitadCuerpo.SetActive(false);
        }
        else {
            mitadCuerpo.SetActive(true);
        }
    }

    public void activarSistema(int num) {
        desactivarTodo();
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        sistemas[num].SetActive(true);
        asource.Stop();
        asource.PlayOneShot(explicaciones[num]);
        switch (num) {
            case 0:
                cambiarTexto("Sistema Circulatorio");
                for (int i = 0; i < leyendaCirculacion.Length; i++)
                {
                    leyendaCirculacion[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 1:
                cambiarTexto("Sistema Oseo");
                for (int i = 0; i < leyendaOseo.Length; i++)
                {
                    leyendaOseo[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 2:
                cambiarTexto("Sistema Urinario");
                for (int i = 0; i < leyendaUrinario.Length; i++)
                {
                    leyendaUrinario[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 3:
                cambiarTexto("Sistema Nervioso");
                for (int i = 0; i < leyendaNervioso.Length; i++)
                {
                    leyendaNervioso[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 4:
                cambiarTexto("Sistema Digestivo");
                for (int i = 0; i < leyendaDigestivo.Length; i++)
                {
                    leyendaDigestivo[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 5:
                cambiarTexto("Sistema Respiratorio");
                for (int i = 0; i < leyendaRespiratorio.Length; i++)
                {
                    leyendaRespiratorio[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 6:
                cambiarTexto("Sistema Muscular");
                for (int i = 0; i < leyendaMuscular.Length; i++)
                {
                    leyendaMuscular[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;




        }
    }

    private void desactivarTodo() {
        for (int i=0;i<sistemas.Count;i++) {
            sistemas[i].SetActive(false);
        }
        for (int i = 0; i < leyendaCirculacion.Length; i++)
        {
            leyendaCirculacion[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaMuscular.Length; i++)
        {
            leyendaMuscular[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaUrinario.Length; i++)
        {
            leyendaUrinario[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaDigestivo.Length; i++)
        {
            leyendaDigestivo[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaRespiratorio.Length; i++)
        {
            leyendaRespiratorio[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaOseo.Length; i++)
        {
            leyendaOseo[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaNervioso.Length; i++)
        {
            leyendaNervioso[i].transform.DOScale(Vector3.zero, 0.1f);
        }

    }


    private void desactivarLeyendas() {
        for (int i = 0; i < leyendaCirculacion.Length; i++)
        {
            leyendaCirculacion[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaMuscular.Length; i++)
        {
            leyendaMuscular[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaUrinario.Length; i++)
        {
            leyendaUrinario[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaDigestivo.Length; i++)
        {
            leyendaDigestivo[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaRespiratorio.Length; i++)
        {
            leyendaRespiratorio[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaOseo.Length; i++)
        {
            leyendaOseo[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < leyendaNervioso.Length; i++)
        {
            leyendaNervioso[i].transform.DOScale(Vector3.zero, 0.1f);
        }
    }
}
