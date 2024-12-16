using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SolarManager : MonoBehaviour
{
    [SerializeField]
    private Text titulo, descripcion;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private PlanetaScriptableObject planetas;
    // Start is called before the first frame update
    public void audioExplicacion(bool bandera) {
        Sequence seqAudio = DOTween.Sequence();
        if (bandera)
        {

            seqAudio.Insert(1, GameObject.Find("btnAudioCerrarExplicacion").transform.DOScale(new Vector2(1, 1), 0.1f));
            seqAudio.Insert(1, GameObject.Find("btnAudioExplicacion").transform.DOScale(Vector2.zero, 0.1f));

            asource.Play();
        }
        else {
            DOTween.KillAll();
            GameObject.Find("btnAudioExplicacion").transform.DOScale(new Vector2(1, 1), 0.1f);
            GameObject.Find("btnAudioCerrarExplicacion").transform.DOScale(Vector2.zero, 0.1f);
            asource.Stop();
        }
        
    }
    public void CerrarExplicacion() {
        asource.Stop();
        GameObject.Find("explicacionPlaneta").transform.DOScale(Vector2.zero, 0.1f).SetEase(Ease.OutElastic);
    }

    public void activarDescripcion(int num) {
        GameObject.Find("explicacionPlaneta").transform.DOScale(new Vector2(1,1),0.2f).SetEase(Ease.InElastic);
        asource.Stop();
        asource.clip = planetas.planetas[num].explicacion;
        GameObject.Find("btnAudioExplicacion").transform.DOScale(new Vector2(1, 1), 0.1f).SetDelay(planetas.planetas[num].explicacion.length);
        GameObject.Find("btnAudioCerrarExplicacion").transform.DOScale(Vector2.zero, 0.1f).SetDelay(planetas.planetas[num].explicacion.length);
        titulo.text = planetas.planetas[num].titulo;
        descripcion.text = planetas.planetas[num].descripcion;
    }
}
[System.Serializable]
public class planetaObject{
    public string titulo,descripcion;
    public AudioClip explicacion;
    }
