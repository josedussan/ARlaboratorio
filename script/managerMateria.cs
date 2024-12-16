using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class managerMateria : MonoBehaviour
{
    private float valorTermometro;
    [SerializeField]
    private Slider termometro;
    [SerializeField]
    private TMP_Text frente, trasero;
    [SerializeField]
    private GameObject hielos, liquido, gas;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void cambiarTexto(string nombre) {
        frente.text = nombre;
        trasero.text = nombre;
    }

    // Update is called once per frame
    void Update()
    {
        if (valorTermometro > 2.5f && valorTermometro < 5) {
            liquido.SetActive(true);
            hielos.SetActive(false);
            gas.SetActive(false);
            liquido.transform.DOScaleY(2*termometro.value - 0.8f, 0.1f);
            cambiarTexto("Estado Líquido");

        } else if (valorTermometro > 0 && valorTermometro < 2.5) {
            hielos.SetActive(true);
            liquido.SetActive(false);
            cambiarTexto("Estado Sólido");
        } else if (valorTermometro > 7 && valorTermometro < 10) {
            gas.SetActive(true);
            liquido.SetActive(false);
            cambiarTexto("Estado Gaseoso");
        } else if (valorTermometro > 5 && valorTermometro < 7.5f) {
            liquido.SetActive(true);
            hielos.SetActive(false);
            gas.SetActive(false);
            liquido.transform.DOScaleY(15 - termometro.value, 0.1f);
            cambiarTexto("Estado Líquido");
        }

        if (hielos.activeSelf || gas.activeSelf) {
            liquido.SetActive(false);
        }
    }

    public void SliderControlador(float valor) {
        valorTermometro = valor;
    }
}
