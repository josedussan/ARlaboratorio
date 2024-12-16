using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class RelieveManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip sonido;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private GameObject particulas, contenedor;
    [SerializeField]
    private TMP_Text frente, trasero;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("montana").transform.DOScale(new Vector3(2 * 2.241076f, 2 * 2.241076f, 2 * 2.241076f), 0.5f).SetEase(Ease.InOutBounce);
    }

    public void activarAudio() {
        asource.Stop();
        asource.loop = true;
        asource.clip = sonido;
        asource.Play();
    }
    private void cambiarTexto(string nombre) {
        frente.text = nombre;
        trasero.text = nombre;
    }

    public void CambiarRelieve(int num)
    {
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
        switch (num)
        {
            case 0:
                Resetear();
                GameObject.Find("montana").transform.DOScale(new Vector3(2*2.241076f, 2 * 2.241076f, 2 * 2.241076f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("montaña");
                break;
            case 1:
                Resetear();
                GameObject.Find("cordillera").transform.DOScale(new Vector3(2 * 5.5305f, 2 * 5.5305f, 2 * 5.5305f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("Cordillera");
                break;
            case 2:
                Resetear();
                GameObject.Find("meseta").transform.DOScale(new Vector3(2 * 1.371301f, 2 * 1.371301f, 2 * 1.371301f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("Meseta");
                break;
            case 3:
                Resetear();
                GameObject.Find("valle").transform.DOScale(new Vector3(2 * 5.448257f, 2 * 5.448257f, 2 * 5.448257f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("Valle");
                break;
            case 4:
                Resetear();
                GameObject.Find("sierra").transform.DOScale(new Vector3(2 * 1.3182f, 2 * 1.3182f, 2 * 1.3182f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("Sierra");
                break;
            case 5:
                Resetear();
                GameObject.Find("llanura").transform.DOScale(new Vector3(2 * 2.1049f, 2 * 2.1049f, 2 * 2.1049f), 0.5f).SetEase(Ease.InOutBounce);
                cambiarTexto("Llanura");
                break;
        }
    }

    public void Resetear()
    {
        GameObject.Find("llanura").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("valle").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("montana").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("cordillera").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("meseta").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("sierra").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
    }
}
