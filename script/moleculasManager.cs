using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class moleculasManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> acidoAcetico,benzeno,agua,acidoCarbonico,fosforo,galactosa,marquillas;
    [SerializeField]
    private GameObject particulas, contenedor;
    [SerializeField]
    private TMP_Text frente, trasero;
    // Start is called before the first frame update
    void Start()
    {
        activarAcidoAcetico();
    }

    private void cambiarNombre(string nombre) {
        frente.text = nombre;
        trasero.text = nombre;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarEfecto() {
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
    }


    public void activarAcidoAcetico() {
        desactivarMoleculas();
        cambiarNombre("Ácido Acético (C<size=100>2</size>h<size=100>4</size>O<size=100>2</size>)");
        for (int i=0;i<acidoAcetico.Count;i++) {
            acidoAcetico[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f*i);
        }
    }

    public void activarBenzeno() {
        desactivarMoleculas();
        cambiarNombre("Benceno (C<size=100>6</size>)H<size=100>6</size>");
        for (int i = 0; i < benzeno.Count; i++)
        {
            benzeno[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f * i);
        }
    }

    public void activarAgua()
    {
        desactivarMoleculas();
        cambiarNombre("Agua (H<size=100>2</size>O)");
        for (int i = 0; i < agua.Count; i++)
        {
            agua[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f * i);
        }
    }

    public void activarFosforo()
    {
        desactivarMoleculas();
        cambiarNombre("Fósforo (P)");
        for (int i = 0; i < fosforo.Count; i++)
        {
            fosforo[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f * i);
        }
    }

    public void activarAcidoCarbonico()
    {
        desactivarMoleculas();
        cambiarNombre("Acido Carbonico (H<size=100>2</size>CO<size=100>3</size>)");
        for (int i = 0; i < acidoCarbonico.Count; i++)
        {
            acidoCarbonico[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f * i);
        }
    }

    public void activarGalactosa()
    {
        desactivarMoleculas();
        cambiarNombre("Galactosa (C<size=100>6</size>H<size=100>12</size>O<size=100>6</size>)");
        for (int i = 0; i < galactosa.Count; i++)
        {
            galactosa[i].transform.DOScale(new Vector3(100, 100, 100), 0.2f).SetEase(Ease.InOutElastic).SetDelay(0.2f * i);
        }
    }

    public void desactivarMoleculas() {
        for (int i = 0; i < acidoAcetico.Count; i++)
        {
            acidoAcetico[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < acidoCarbonico.Count; i++)
        {
            acidoCarbonico[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < benzeno.Count; i++)
        {
            benzeno[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < agua.Count; i++)
        {
            agua[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < fosforo.Count; i++)
        {
            fosforo[i].transform.DOScale(Vector3.zero, 0.1f);
        }
        for (int i = 0; i < galactosa.Count; i++)
        {
            galactosa[i].transform.DOScale(Vector3.zero, 0.1f);
        }
    }
}
