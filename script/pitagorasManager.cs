using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class pitagorasManager : MonoBehaviour
{
    float gravedad = -10;
    private GameObject[] pelotas;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = Physics.gravity * -gravedad;
        pelotas = GameObject.FindGameObjectsWithTag("marquilla");
        desactivarPelotas();
    }

    public void cargarPelotas() { Invoke("activarPelotas", 1); }

    public void desactivarPelotas() {
        for (int i = 0; i < pelotas.Length; i++)
        {
            pelotas[i].SetActive(false);
        }
    }
    private void activarPelotas()
    {
        for (int i = 0; i < pelotas.Length; i++)
        {
            pelotas[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
