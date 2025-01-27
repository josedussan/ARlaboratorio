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
    [SerializeField]
    private List<Sprite> imgsBtnSound;
    [SerializeField]
    private GameObject btnSound;
    private bool flatAudio = false,flatExplication=false;
    // Start is called before the first frame update
    public void EnableAudio()
    {
        Image btnImage = btnSound.GetComponent<Image>();
        flatAudio = !flatAudio;
        if (flatAudio)
        {
            asource.Stop();
            asource.Play();
            btnImage.sprite = imgsBtnSound[1];
            StartCoroutine(WaitAudio());
        }
        else
        {
            asource.Stop();
            StopAllCoroutines();
            btnImage.sprite = imgsBtnSound[0];
        }

    }
    IEnumerator WaitAudio()
    {
        yield return new WaitForSeconds(asource.clip.length);
        btnSound.transform.GetComponent<Image>().sprite = imgsBtnSound[0];
    }

    public void EnableDescription(int num) {
        flatExplication = !flatExplication;
        if (flatExplication)
        {
            GameObject.Find("explicacionPlaneta").transform.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.InElastic);
            asource.Stop();
            asource.clip = planetas.planetas[num].explicacion;
            titulo.text = planetas.planetas[num].titulo;
            descripcion.text = planetas.planetas[num].descripcion;
        }
        else {
            asource.Stop();
            GameObject.Find("explicacionPlaneta").transform.DOScale(Vector2.zero, 0.1f).SetEase(Ease.OutElastic);
        }
        
    }
}
[System.Serializable]
public class planetaObject{
    public string titulo,descripcion;
    public AudioClip explicacion;
    }
