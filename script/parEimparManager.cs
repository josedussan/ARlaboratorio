using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class parEimparManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objetos;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private List<AudioClip> sonidos;
    [SerializeField]
    private Sprite correcto, incorrecto;
    [SerializeField]
    private Image imagen;
    private bool banderaPanel = true;
    [SerializeField]
    private TMP_Text txtnumero;
    [SerializeField]
    private GameObject particulas;

    // Start is called before the first frame update
    void Start()
    {
        ocultarObjetos();
        var numero = Random.Range(1, objetos.Count);
        txtnumero.text = numero.ToString();
        LlenarCanasta(numero);
        
    }
    public void CerrarPanel(RectTransform panel) {
        if (banderaPanel) {
            panel.DOScale(Vector3.zero, 0.1f);
            banderaPanel = false;
        } else{
            panel.DOScale(new Vector3(1,1,1), 0.1f);
            banderaPanel = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(Button btn)
    {
        if (verificarNumero(int.Parse(txtnumero.text), btn.name))
        {
            var numero = Random.Range(1, objetos.Count);
            txtnumero.text = numero.ToString();
            LlenarCanasta(numero);
            Debug.Log("correcto");
            MostrarMensajeRespuesta(correcto);
            asource.PlayOneShot(sonidos[0]);
        }
        else {
            MostrarMensajeRespuesta(incorrecto);
            Debug.Log("incorrecto");
            asource.PlayOneShot(sonidos[1]);
        }
    }

    private void LlenarCanasta(int num) {
        ocultarObjetos();
        var numfigura = Random.Range(0,2);
        for (int i=0;i<num;i++) {
            //objetos[i] = Instantiate(frutas.objetos[numfigura].objeto, objetos[i].transform);
            GameObject efecto = Instantiate(particulas, objetos[i].transform);
            //objetos[i]= frutas.objetos[numfigura].objeto;
            //objetos[i].SetObject(frutas.objetos[numfigura].objeto);
            Destroy(efecto, 1);
            objetos[i].SetActive(true);
        }
    }

    bool verificarNumero(int numero, string nombreBtn) {
        bool respuesta=false;
        if ((numero % 2 == 0 && nombreBtn.Equals("btnPar"))|| (numero % 2 != 0 && nombreBtn.Equals("btnImpar")))
        {
            respuesta = true;

        }

        return respuesta;
    }

    private void ocultarObjetos() {
        for (int i = 0; i < objetos.Count; i++)
        {
            objetos[i].SetActive(false);
        }
    }

    private void MostrarMensajeRespuesta(Sprite img)
    {
        imagen.sprite = img;
        imagen.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        imagen.transform.DOScale(Vector3.zero, 0.1f).SetDelay(0.7f);
    }
}
