using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class managerMapa : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> secciones;
    [SerializeField]
    private seccionDataScriptable infoMapa;
    [SerializeField]
    private List<Vector3> inicialPositions;
    [SerializeField]
    private List<Quaternion> inicialRotation;
    [SerializeField]
    private TMP_Text nombre, superficie, municipios, capital,actividad;
    [SerializeField]
    private Image bandera;
    [SerializeField]
    private GameObject canvas,globo,plano;
    [SerializeField]
    private AudioClip sonido;
    [SerializeField]
    private AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<secciones.Count;i++) {
            inicialPositions[i]=secciones[i].transform.localPosition;
            inicialRotation[i]=secciones[i].transform.localRotation;
        }
    }

    public void MostrarInfo(string codigo) {
        resetear();
        canvas.transform.DOScale(Vector3.zero,0.1f);
        int posicionObjeto = buscarInfo(codigo);
        nombre.text = infoMapa.dataMapa[posicionObjeto].Nombre;
        superficie.text = infoMapa.dataMapa[posicionObjeto].superficie;
        municipios.text = infoMapa.dataMapa[posicionObjeto].municipios;
        capital.text = infoMapa.dataMapa[posicionObjeto].capital;
        if (infoMapa.dataMapa[posicionObjeto].tipo.Equals(tipoSeccion.colombia))
        {
            asource.Stop();
            bandera.sprite = infoMapa.dataMapa[posicionObjeto].bandera;
            actividad.text = infoMapa.dataMapa[posicionObjeto].actividad;
            asource.PlayOneShot(infoMapa.dataMapa[posicionObjeto].musica);
        }
        else {
            asource.PlayOneShot(sonido);
        }
        
        elevarSeccion(posicionObjeto);
        canvas.transform.SetLocalPositionAndRotation(inicialPositions[posicionObjeto],new Quaternion());
        canvas.transform.DOScale(new Vector3(0.5f,0.5f,0.5f), 0.1f);


    }

    public void elevarSeccion(int cod) {
        secciones[cod].transform.SetLocalPositionAndRotation(new Vector3(inicialPositions[cod].x, 2, inicialPositions[cod].z), inicialRotation[cod]);
    }

    public void resetear() {
        for (int i = 0; i < secciones.Count; i++)
        {
            secciones[i].transform.SetLocalPositionAndRotation(inicialPositions[i],inicialRotation[i]);
        }
    }

    private int buscarInfo(string cod) {
        bool encontrado = false;
        int i = 0;
        while (encontrado != true)
        {
            if (infoMapa.dataMapa[i].codigo.Equals(cod))
            {
                encontrado = true;
            }
            else {
                i++;
            }
        }
        return i;
    }


    public void mostrarModelo(string modelo) {
        switch (modelo) {
            case "plano":
                globo.transform.DOScale(Vector3.zero,0.2f);
                plano.transform.DOScale(new Vector3(1,1,1), 0.2f).SetDelay(0.2f);
                break;
            case "globo":
                plano.transform.DOScale(Vector3.zero, 0.2f);
                globo.transform.DOScale(new Vector3(7.604359f, 7.604359f, 7.604359f), 0.2f).SetDelay(0.2f);
                break;
        }
    }
}
[System.Serializable]
public class seccionMapa
{
    public string codigo;
    public tipoSeccion tipo;
    public string Nombre,superficie,municipios,capital,actividad;
    public Sprite bandera;
    public AudioClip musica;
}

public enum tipoSeccion
{
    mundo,
    colombia
}