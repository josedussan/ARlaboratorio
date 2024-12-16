using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class tablaPeriodicaManager : MonoBehaviour
{
    public sustanciaQuimicaScriptableObject sustancias;
    public TMP_Text masa, configuracion, simbolo, nombre, tipo, estado,numero;
    private int numsustancia = 0;
    public List<Material> materialTipo;
    public GameObject cubo,cubo2,tabla;

    // Start is called before the first frame update
    void Start()
    {
        sustanciaBase();
    }

 


    public void animCubo() {
        /*cubo.transform.DOScale(Vector3.zero, 0.1f);
        cubo.transform.DOScale(new Vector3(14.97348f, 14.97348f, 14.97348f), 0.2f).SetEase(Ease.InElastic).SetDelay(0.15f);*/
        cubo2.transform.DOShakeScale(0.2f, 3.5f,2);


    }

    public void sustanciaBase() {
        masa.text = sustancias.objetos[0].masa;
        configuracion.text = sustancias.objetos[0].configuracion;
        simbolo.text = sustancias.objetos[0].simbolo;
        nombre.text = sustancias.objetos[0].nombre;
        tipo.text = sustancias.objetos[0].tipoSustancia;
        cambiarTexturaCubo(sustancias.objetos[0].tipoSustancia);
        estado.text = sustancias.objetos[0].estado.ToString();
        numero.text =  (numsustancia+1).ToString();

    }

    public void activarTabla() {
        tabla.transform.DOScale(new Vector2(1,1), 0.2f);
    }

    public void cambiarTexturas(int num) {
        tabla.transform.DOScale(Vector2.zero,0.2f);

        masa.text = sustancias.objetos[num].masa;
        configuracion.text = sustancias.objetos[num].configuracion;
        simbolo.text = sustancias.objetos[num].simbolo;
        nombre.text = sustancias.objetos[num].nombre;
        tipo.text = sustancias.objetos[num].tipoSustancia;
        cambiarTexturaCubo(sustancias.objetos[num].tipoSustancia);
        estado.text = sustancias.objetos[num].estado.ToString();
        numero.text = (num + 1).ToString();
        animCubo();
    }

    private void cambiarTexturaCubo(string tipo) {
        if (tipo.Equals("Metales Alcalinos"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[0];
        }
        else if (tipo.Equals("Metaloides"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[1];
        }
        else if (tipo.Equals("Actinoides"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[2];
        }
        else if (tipo.Equals("Metales Alcalinotérreos"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[3];
        }
        else if (tipo.Equals("No Metales Reactivos"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[4];
        }
        else if (tipo.Equals("Propiedades Desconocidas"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[5];
        }
        else if (tipo.Equals("Metales Transicionales"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[6];
        }
        else if (tipo.Equals("Gases Nobles"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[7];
        }
        else if (tipo.Equals("Metales Postransicionales"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[8];
        }
        else if (tipo.Equals("Lantánidos"))
        {

            cubo.GetComponent<Renderer>().material = materialTipo[9];
        }

    }
}

[System.Serializable]
public class sustanciaQuimicaObject
{
    public string masa,simbolo,nombre,tipoSustancia,configuracion;
    public tipoEstado estado;
}

public enum tipoEstado
{
    Sólido,
    Líquido,
    Gas,
    Desconocido
}

