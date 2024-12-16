using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CircuitosManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> circuitos,luces;
    [SerializeField]
    private TMP_Text frente, trasero;
    [SerializeField]
    private GameObject particulas,contenedor;
    // Start is called before the first frame update

    public void activarCircuito(int num) {
        ocultarTodo();
        apagarLuces();
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
        switch (num) {
            case 0:
                circuitos[0].transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).SetEase(Ease.InBounce);
                cambiartTexto("Circuito Eléctrico Simple");
                
                break;
            case 1:
                circuitos[1].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f).SetEase(Ease.InBounce);
                cambiartTexto("Circuito Eléctrico en Serie");
                break;
            case 2:
                circuitos[2].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f).SetEase(Ease.InBounce);
                cambiartTexto("Circuito Eléctrico en Paralelo");
                break;
        }
    }

    public void ocultarTodo() {
        for (int i = 0; i < circuitos.Count; i++) {
            circuitos[i].transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBounce);
        }
    }

    public void apagarLuces() {
        for (int i = 0; i < luces.Count; i++)
        {
            luces[i].SetActive(false);
        }
    }

    private void cambiartTexto(string texto) {
        frente.text = texto;
        trasero.text = texto;
    }
    
}
