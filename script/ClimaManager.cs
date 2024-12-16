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
    private TMP_Text frente, trasero;
    [SerializeField]
    private objetoBase _objetoBase;
    [SerializeField]
    private ClimaScriptableObject climas;
    [SerializeField]
    private GameObject  luzglobal;

    private void cambiarTexto(string nombre)
    {
        frente.text = nombre;
        trasero.text = nombre;
    }

    public void cambiarTiempo(int num)
    {
        asource.Stop();
        asource.loop = true;
        asource.clip = climas.climas[num].sonido;
        cambiarTexto(climas.climas[num].titulo);
        _objetoBase.SetObject(climas.climas[num].objeto);
        asource.Play();
        if (num == 2 || num == 3 ||num==2)
        {
            luzglobal.SetActive(false);
        }
        else {
            luzglobal.SetActive(true);
        }

    

    }

}
[System.Serializable]
public class climaObject {
    public string titulo;
    public AudioClip sonido;
    public GameObject objeto;
}
