using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class gravedadMnaager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pelota,planeta;
    [SerializeField]
    private TMP_Text frenteG, traseroG, frenteN, traseroN;
    public List<Material> materiales;
    [SerializeField]
    private GravedadScriptableObject gravedades;

    private float gravedad = -9.8f;
    private Rigidbody rbJugador;
    public void Start()
    {
        rbJugador = pelota.GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity* gravedad;
    }
    public void resetearPelota() {
        pelota.SetActive(false);
        pelota.transform.DOPunchPosition(Vector3.zero, 0.1f);
    }

    public void rebotar() {
        rbJugador.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    public void activarPelota() {
        pelota.SetActive(true);
    }

    public void cambiarGravedad(int num) {
        Physics.gravity = new Vector3(0, gravedades.gravedades[num].gravedad , 0);
        cambiarTexto(gravedades.gravedades[num].gravedadTxt, gravedades.gravedades[num].titulo);
        if (gravedades.gravedades[num].llevaMaterial)
        {
            Renderer rend = planeta.GetComponent<Renderer>();
            rend.material = gravedades.gravedades[num].material;
            planeta.transform.DOScale(new Vector3(5.5078f, 5.5078f, 5.5078f), 0.1f);
        }
        else {
            planeta.transform.DOScale(Vector3.zero,0.1f);
        }
    }


    private void cambiarTexto(string gravedad, string nombre) {
        frenteG.text = gravedad;
        traseroG.text = gravedad;
        frenteN.text = nombre;
        traseroN.text = nombre;
    }
}

[System.Serializable]
public class GravedadObject {
    public string gravedadTxt, titulo;
    public bool llevaMaterial;
    public Material material;
    public float gravedad;
}
