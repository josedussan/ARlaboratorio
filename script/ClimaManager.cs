using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ClimaManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private TMP_Text frontal, back;
    [SerializeField]
    private objetoBase _baseObject;
    [SerializeField]
    private ClimaScriptableObject climates;
    [SerializeField]
    private GameObject  globalLight;

    private void ChangeText(string nombre)
    {
        frontal.text = nombre;
        back.text = nombre;
    }

    public void ChangeClimate(int num)
    {
        asource.Stop();
        asource.loop = true;
        asource.clip = climates.climas[num].sonido;
        ChangeText(climates.climas[num].titulo);
        _baseObject.SetObject(climates.climas[num].objeto);
        asource.Play();
        if (num == 2 || num == 3 ||num==2)
        {
            globalLight.SetActive(false);
        }
        else {
            globalLight.SetActive(true);
        }
    }

}
[System.Serializable]
public class climaObject {
    public string titulo;
    public AudioClip sonido;
    public GameObject objeto;
}
