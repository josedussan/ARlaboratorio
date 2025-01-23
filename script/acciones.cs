using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class acciones : MonoBehaviour
{
    private GameObject[] labels;
    [SerializeField]
    private GameObject objeto;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<Sprite> imgsBtnSound, imgsBtnAnim;
    [SerializeField]
    private GameObject btnSound,btnAnim;    
    private bool flatLabels = false;
    private bool flatAudio = false,flatAnim=false;
    //private bool banderaAudio = false;

    public UnityEvent evento;
    // Start is called before the first frame update
    void Start()
    {
        labels = GameObject.FindGameObjectsWithTag("marquilla");
        evento.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoundLabels() {
        labels = GameObject.FindGameObjectsWithTag("marquilla");
    }

    public void EnableLabels(float tamano) {
        if (objeto != null) {
            DesableAnimation();
        }
        flatLabels = !flatLabels;
        if (flatLabels) { 
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].transform.DOScale(new Vector3(tamano, tamano,tamano), 0.1f);
            }
        }else {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].transform.DOScale(Vector3.zero, 0.1f);
            }
        }

    }

    public void EnableAudio() {
        Image btnImage = btnSound.GetComponent<Image>();
        flatAudio = !flatAudio;
        if (flatAudio)
        {
            asource.Stop();
            asource.Play();
            btnImage.sprite = imgsBtnSound[1];
            StartCoroutine(WaitAudio());
        }
        else {
            asource.Stop();
            StopAllCoroutines();
            btnImage.sprite = imgsBtnSound[0];
        }
        
    }
    IEnumerator WaitAudio() {
        yield return new WaitForSeconds(asource.clip.length);
        btnSound.transform.GetComponent<Image>().sprite = imgsBtnSound[0];
    }

    public void EnableAnimation() {

        objeto.GetComponent<Animation>().Play();
        Image btnImage = btnAnim.GetComponent<Image>();
        flatAnim = !flatAnim;
        if (flatAnim) {
            btnImage.sprite = imgsBtnAnim[1];
            if (flatLabels)
            {
                flatLabels = false;
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].transform.DOScale(Vector3.zero, 0.1f);
                }
            }
        }
        else {
            DesableAnimation();
        }
    }

    public void DesableAnimation() {
        objeto.GetComponent<Animation>().Stop();
        btnAnim.transform.GetComponent<Image>().sprite = imgsBtnAnim[0];
    }

    public void StopAudio()
    {
        asource.Stop();

    }

    public void panelHelp(bool act) {
        if (act)
        {
            GameObject.Find("PanelAyuda").transform.DOScale(new Vector3(1, 1,1), 0.01f);
        }
        else {
            GameObject.Find("PanelAyuda").transform.DOScale(Vector3.zero, 0.01f);
        }
    }
}
