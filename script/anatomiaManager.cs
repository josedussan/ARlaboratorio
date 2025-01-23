using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class anatomiaManager : MonoBehaviour
{
    private GameObject[] circulatoryLabels, boneLabels, urinaryLabels, nervousLabels, digestiveLabels, respiratoryLabels,muscularLabels;
    [SerializeField]
    private List<GameObject> sistemas;
    [SerializeField]
    private GameObject halfBody;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<AudioClip> descriptions;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private GameObject particles, container;
    // Start is called before the first frame update
    void Start()
    {
        circulatoryLabels = GameObject.FindGameObjectsWithTag("circulatorio");
        boneLabels = GameObject.FindGameObjectsWithTag("oseo");
        urinaryLabels = GameObject.FindGameObjectsWithTag("urinario");
        nervousLabels= GameObject.FindGameObjectsWithTag("nervioso");
        digestiveLabels = GameObject.FindGameObjectsWithTag("digestivo");
        respiratoryLabels = GameObject.FindGameObjectsWithTag("respiratorio");
        muscularLabels = GameObject.FindGameObjectsWithTag("muscular");

        Invoke("DesabledLabels",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeText(string nombre) {
        text.text = nombre;
    }

    public void DesabledSkin() {
        if (halfBody.activeSelf)
        {
            halfBody.SetActive(false);
        }
        else {
            halfBody.SetActive(true);
        }
    }

    public void EnabledSystems(int num) {
        DesabledAll();
        GameObject efecto = Instantiate(particles, container.transform);
        sistemas[num].SetActive(true);
        asource.Stop();
        asource.PlayOneShot(descriptions[num]);
        switch (num) {
            case 0:
                changeText("Sistema Circulatorio");
                for (int i = 0; i < circulatoryLabels.Length; i++)
                {
                    circulatoryLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 1:
                changeText("Sistema Oseo");
                for (int i = 0; i < boneLabels.Length; i++)
                {
                    boneLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 2:
                changeText("Sistema Urinario");
                for (int i = 0; i < urinaryLabels.Length; i++)
                {
                    urinaryLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 3:
                changeText("Sistema Nervioso");
                for (int i = 0; i < nervousLabels.Length; i++)
                {
                    nervousLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 4:
                changeText("Sistema Digestivo");
                for (int i = 0; i < digestiveLabels.Length; i++)
                {
                    digestiveLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 5:
                changeText("Sistema Respiratorio");
                for (int i = 0; i < respiratoryLabels.Length; i++)
                {
                    respiratoryLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
            case 6:
                changeText("Sistema Muscular");
                for (int i = 0; i < muscularLabels.Length; i++)
                {
                    muscularLabels[i].transform.DOScale(new Vector3(0.03215058f, 0.02813862f, 0.0185358f), 0.1f);
                }
                break;
        }
    }

    private void DesabledLabels(GameObject[] list) {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].transform.DOScale(Vector3.zero, 0.1f);
        }
    }

    private void DesabledAll() {
        for (int i=0;i<sistemas.Count;i++) {
            sistemas[i].SetActive(false);
        }
        DesabledLabels(circulatoryLabels);
        DesabledLabels(muscularLabels);
        DesabledLabels(urinaryLabels);
        DesabledLabels(digestiveLabels);
        DesabledLabels(respiratoryLabels);
        DesabledLabels(nervousLabels);
        DesabledLabels(boneLabels);
    }


    private void DesabledLabels() {
        DesabledLabels(circulatoryLabels);
        DesabledLabels(muscularLabels);
        DesabledLabels(urinaryLabels);
        DesabledLabels(digestiveLabels);
        DesabledLabels(respiratoryLabels);
        DesabledLabels(nervousLabels);
        DesabledLabels(boneLabels);
    }
}
