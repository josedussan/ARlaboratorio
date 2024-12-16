using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class moverRecto : MonoBehaviour
{
    [SerializeField]
    private Transform auto, puntob;
    [SerializeField]
    private Text textdis, textvel;
    [SerializeField]
    private Vector3 posinicial;
    [SerializeField]
    private Collider colAuto;
    [SerializeField]
    private Quaternion rotInicial;
    [SerializeField]
    private TMP_Text textoTiempo;
    [SerializeField]
    private int velocidad=1,distancia,tiempo;
    private rotarSobreEje[] rotacionLlantas;

    // Start is called before the first frame update
    void Start()
    {
        posinicial = auto.localPosition;
        rotInicial = auto.localRotation;

        rotacionLlantas = rotarSobreEje.FindObjectsOfType<rotarSobreEje>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = (velocidad*2) * Time.deltaTime;
        auto.position = Vector3.MoveTowards(auto.position, puntob.position, step);
    }

    public void trasladarLineaRecta() {
            distancia = Int32.Parse(textdis.text.Trim());
            velocidad = Int32.Parse(textvel.text.Trim());
            auto.SetLocalPositionAndRotation(posinicial, rotInicial);
            puntob.SetLocalPositionAndRotation(new Vector3(0, distancia-37, 15.9f), new Quaternion());
            tiempo =  distancia / velocidad;
            textoTiempo.text = tiempo.ToString() + " s";
        for (int i=0;i<rotacionLlantas.Length;i++) {
            rotacionLlantas[i].velocidad = -velocidad;
        }
            
        /*float step = velocidad* Time.deltaTime;
        auto.position = Vector3.MoveTowards(auto.position,puntob.position,step);*/


    }
}
