using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelManager : MonoBehaviour
{
    private string previousScene;
    
    // Start is called before the first frame update
    void Start()
    {
        previousScene = PlayerPrefs.GetString("anterior", "none");
        if (previousScene.Equals("circuito") || previousScene.Equals("gravedad")  || previousScene.Equals("Rectilineo") || previousScene.Equals("circular")) {
            goThematic(0);
        } else if (previousScene.Equals("volcan") || previousScene.Equals("transporte") || previousScene.Equals("relieve") || previousScene.Equals("hidrografia") || previousScene.Equals("colombia") || previousScene.Equals("mapaMundi") || previousScene.Equals("maravillas")) {
            goThematic(1);
        } else if (previousScene.Equals("planta") || previousScene.Equals("clima") || previousScene.Equals("animales") || previousScene.Equals("VidaMariposa") || previousScene.Equals("anatomia") || previousScene.Equals("estrellas") || previousScene.Equals("atomo") || previousScene.Equals("sistemaSolar") || previousScene.Equals("celulas")) {
            goThematic(2);
        } else if (previousScene.Equals("materia") || previousScene.Equals("moleculas") || previousScene.Equals("tablaPeriodica") || previousScene.Equals("reaccionesQuimicas") || previousScene.Equals("alcanos")) {
            goThematic(3);
        }else if (previousScene.Equals("pareimpar") || previousScene.Equals("triangulos") || previousScene.Equals("figuras") || previousScene.Equals("poligonos") || previousScene.Equals("fracciones"))
        {
            goThematic(4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPanel(Transform panel) {
        panel.transform.DOScale(new Vector2(1,1),0.1f);
    }
    public void ClosePanel(Transform panel)
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

    public void goThematic(int i) {
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
