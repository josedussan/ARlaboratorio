using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HidroManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> sonidos;
    [SerializeField]
    private AudioSource asource;
    [SerializeField]
    private GameObject particulas, contenedor;
    // Start is called before the first frame update

    public void CambiarHidrografia(int num) {
        asource.Stop();
        asource.loop = true;
        asource.clip = sonidos[num];
        asource.Play();
        GameObject efecto = Instantiate(particulas, contenedor.transform);
        Destroy(efecto, 2);
        switch (num) {
            case 0:
                Resetear();
                GameObject.Find("lago").transform.DOScale(new Vector3(5.6f, 5.6f, 5.6f),0.5f).SetEase(Ease.InOutBounce);
                break;
            case 1:
                Resetear();
                GameObject.Find("rio").transform.DOScale(new Vector3(5.6f, 5.6f, 5.6f), 0.5f).SetEase(Ease.InOutBounce);
                break;
            case 2:
                Resetear();
                GameObject.Find("mar").transform.DOScale(new Vector3(5.6f, 5.6f, 5.6f), 0.5f).SetEase(Ease.InOutBounce);
                break;
        }
    }

    public void Resetear()
    {
        GameObject.Find("lago").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("mar").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
        GameObject.Find("rio").transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBounce);
    }
}
