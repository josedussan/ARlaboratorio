using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelManager : MonoBehaviour
{
    private string escenaAnterior;
    
    // Start is called before the first frame update
    void Start()
    {
        escenaAnterior = PlayerPrefs.GetString("anterior", "none");
        if (escenaAnterior.Equals("circuito") || escenaAnterior.Equals("gravedad") || escenaAnterior.Equals("clima") || escenaAnterior.Equals("Rectilineo") || escenaAnterior.Equals("circular")) {
            irTematica(0);
        } else if (escenaAnterior.Equals("volcan") || escenaAnterior.Equals("transporte") || escenaAnterior.Equals("relieve") || escenaAnterior.Equals("hidrografia") || escenaAnterior.Equals("colombia") || escenaAnterior.Equals("mapaMundi") || escenaAnterior.Equals("maravillas")) {
            irTematica(1);
        } else if (escenaAnterior.Equals("planta")  || escenaAnterior.Equals("animales") || escenaAnterior.Equals("VidaMariposa") || escenaAnterior.Equals("anatomia") || escenaAnterior.Equals("estrellas") || escenaAnterior.Equals("atomo") || escenaAnterior.Equals("sistemaSolar") || escenaAnterior.Equals("celulas")) {
            irTematica(2);
        } else if (escenaAnterior.Equals("materia") || escenaAnterior.Equals("moleculas") || escenaAnterior.Equals("tablaPeriodica") || escenaAnterior.Equals("reaccionesQuimicas") || escenaAnterior.Equals("alcanos")) {
            irTematica(3);
        }else if (escenaAnterior.Equals("pareimpar") || escenaAnterior.Equals("triangulos") || escenaAnterior.Equals("figuras") || escenaAnterior.Equals("poligonos") || escenaAnterior.Equals("fracciones"))
        {
            irTematica(4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void abrirPanel(Transform panel) {
        panel.transform.DOScale(new Vector2(1,1),0.1f);
    }
    public void cerrarPanel(Transform panel)
    {
        panel.transform.DOScale(Vector2.zero, 0.1f);
    }


    public void inicio(){
        GameObject.Find("PanelQuimica").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("PanelFisica").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("PanelGeografia").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("PanelNaturales").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("PanelMatematica").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("botonera").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("PanelTematica").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
    }

    public void irTematica(int i) {
        GameObject.Find("PanelTematica").transform.DOScale(Vector2.zero, 0.1f);
        GameObject.Find("botonera").transform.DOScale(new Vector2(1,1),0.1f).SetDelay(0.1f);
        switch (i) {
            case 0:
                    GameObject.Find("PanelFisica").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
                break;
            case 1:
                GameObject.Find("PanelGeografia").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
                break;
            case 2:
                GameObject.Find("PanelNaturales").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
                break;
            case 3:
                GameObject.Find("PanelQuimica").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
                break;
            case 4:
                GameObject.Find("PanelMatematica").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(0.1f);
                break;

        }
    }
}
