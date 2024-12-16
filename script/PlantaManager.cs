using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlantaManager : MonoBehaviour
{

    public void activarPlanta() {
        GameObject.Find("hierva").transform.DOScale(new Vector3( 0.5409659f, 0.5409659f, 0.5409659f), 0.4f).SetEase(Ease.InOutBounce);
        GameObject.Find("tierra").transform.DOScale(new Vector3(0.5409659f, 0.5409659f, 0.5409659f), 0.4f).SetEase(Ease.InOutBounce);
        GameObject.Find("planta").transform.DOScale(new Vector3(2, 2, 2), 0.5f).SetEase(Ease.InOutBounce);
        
    }

    public void activarRegadera() {
        GameObject.Find("regadera").transform.DOScale(new Vector3(20, 20, 20), 0.3f);
        GameObject.Find("tronco").transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetDelay(1.8f);
        GameObject.Find("raices").transform.DOScale(new Vector3(1, 1, 1), 0.2f).SetDelay(1.3f);
        GameObject.Find("regadera").transform.DOScale(new Vector3(0, 0, 0), 0.3f).SetDelay(1.5f);
    }

    public void resetear() {
        GameObject.Find("planta").transform.DOScale(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.InOutBounce);
        GameObject.Find("regadera").transform.DOScale(new Vector3(0, 0, 0), 0.1f);

    }


}
