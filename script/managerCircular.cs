using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class managerCircular : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoT, textof,textov;
    [SerializeField]
    private Text valorw, valorr;
    [SerializeField]
    private GameObject aro;
    [SerializeField]
    private Transform avion;
    private Vector3 posicionA;
    private rotarSobreEje velocidad;

    // Start is called before the first frame update
    void Start()
    {
        posicionA = avion.localPosition;
        Debug.Log(posicionA);
        velocidad = FindAnyObjectByType<rotarSobreEje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarRadio() {
        Debug.Log(string.IsNullOrEmpty(valorw.text));
        if (!string.IsNullOrEmpty(valorw.text) && !string.IsNullOrEmpty(valorr.text))
        {
            Debug.Log(valorw.text);
            float w = Int32.Parse(valorw.text.Trim());
            float r = Int32.Parse(valorr.text.Trim());
            // Debug.Log(w);
            float periodo = (2 * Mathf.PI) / w;
            textoT.text = periodo.ToString();
            float frecuencia = 1 / periodo;
            textof.text = frecuencia.ToString() + " Hz";
            posicionAvion(r);
            escalaAro(r);
            float v = r * w;
            textov.text = v.ToString() + " m/s";
            velocidad.velocidad = -(v+50);
        }
        else
        {
            Debug.Log("entra al else");
        }
    
    }

    private void posicionAvion(float posicion) {

        avion.SetLocalPositionAndRotation(new Vector3(posicion*10,0,0),avion.localRotation);
        Debug.Log(posicion * 10);
    }

    private void escalaAro(float num) {
        float factor = 4 * num;
        aro.transform.DOScale(new Vector3(factor,factor,factor),0.2f);
    }



}
