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
    private GameObject solido, liquido, gas;
    private Vector3 posIniHielos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void ChangeText(string nombre) {
        frente.text = nombre;
        //trasero.text = nombre;
    }

    public void PosicionHielos() {
        posIniHielos = solido.transform.position;
    }
    public void asignarPosicionHielos() {
        solido.transform.localPosition = posIniHielos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeState(float valor) {
        if (valorTermometro > 2.5f && valorTermometro < 5) {
             ChangeToLiquidState(true);
         } else if (valorTermometro > 0 && valorTermometro < 2.5) {
             ChangeToSolidState();
         } else if (valorTermometro > 7 && valorTermometro < 10) {
             ChangeToGaseousState();

         } else if (valorTermometro > 5 && valorTermometro < 7.5f) {
            ChangeToLiquidState(false);
        }

         if (solido.activeSelf || gas.activeSelf) {
             liquido.SetActive(false);
         }
    }

    public void SliderControlador() {
        valorTermometro = termometro.value;
        ChangeState(valorTermometro);
    }

    private void ChangeToLiquidState(bool flat) {
        liquido.SetActive(true);
        solido.SetActive(false);
        gas.SetActive(false);
        if (flat)
        {
            //menor a 5
            liquido.transform.DOScaleY(2 * termometro.value - 0.8f, 0.1f);
        }
        else {
            //mayor a 5
            liquido.transform.DOScaleY(15 - termometro.value, 0.1f);
        }
        ChangeText("Estado Líquido");
    }
    private void ChangeToSolidState()
    {

        solido.SetActive(true);
        liquido.SetActive(false);
        ChangeText("Estado Sólido");
    }
    private void ChangeToGaseousState()
    {
        gas.SetActive(true);
        liquido.SetActive(false);
        ChangeText("Estado Gaseoso");
    }
}
