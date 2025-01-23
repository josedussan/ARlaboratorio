using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class vrmanager : MonoBehaviour
{
    private string descripcion= "La erupción del monte Vesubio es una de las erupciones volcánicas más famosas de la historia. En el año 79 A. C. una nube ardiente provocó el entierro de la ciudad romana de Pompeya. La ciudad quedó cubierta bajo una capa de 25 metros (82 pies) de cenizas volcánicas.";
    public TMP_Text texto;
    public GameObject objeto;
    public vrScriptableObject objetoVR;
    public Image imagen1, imagen2;
    private transicionTemporal accion;
    private string escena;

    // Start is called before the first frame update
    void Start()
    {
        escena = PlayerPrefs.GetString("anterior","none");
        cargarElementosEscena();
        StartCoroutine(escritura());
    }

    IEnumerator escritura() {
        foreach (char caracter in descripcion) {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.05f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void cargarElementosEscena() {

        /*while (!encontrado) {
            int i = 0;
            if (escena.Equals(objetoVR.objetos[i].nombreEscena)) {
                descripcion = objetoVR.objetos[i].descripcion;
                imagen1.sprite = objetoVR.objetos[i].image1;
                imagen2.sprite = objetoVR.objetos[i].image2;
                //GameObject objeto3d = Instantiate(objetoVR.objetos[i].objeto,objeto.transform);
                encontrado = true;
            }
            i++;
        }*/

        for (int i=0;i<objetoVR.objetos.Count;i++) {
            if (escena.Equals(objetoVR.objetos[i].nombreEscena))
            {
                descripcion = objetoVR.objetos[i].descripcion;
                imagen1.sprite = objetoVR.objetos[i].image1;
                imagen2.sprite = objetoVR.objetos[i].image2;
                //GameObject objeto3d = Instantiate(objetoVR.objetos[i].objeto,objeto.transform);
            }
        }
    }

}

[System.Serializable]
public class vrObject
{
   
    public string descripcion,nombreEscena;
    public GameObject objeto;
    public Sprite image1,image2;

}
