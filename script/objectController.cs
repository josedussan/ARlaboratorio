using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class objectController : MonoBehaviour
{
    private int startIndex = 0;
    [SerializeField]
    private objetoBase objetobase;
    [SerializeField]
    private Transform btnContainer;
    [SerializeField]
    private objetoDataScriptable objetoDS;
    [SerializeField]
    private btnObjectController btnPrefab;
    private btnObjectController _btnBase;
    [SerializeField]
    private GameObject particulas;
    [SerializeField]
    private AudioSource asource;


    // Start is called before the first frame update
    void Start()
    {
        CreatePrefabs();
        ChangeObject(objetoDS.objetos[startIndex]);
    }

    public void CreatePrefabs() {
        for (int i = 0; i < objetoDS.objetos.Count;i++) {
            _btnBase = Instantiate(btnPrefab, btnContainer);
            _btnBase.Init(objetoDS.objetos[i]);
            int index = i;
            _btnBase.SetButton(()=> ChangeObject(objetoDS.objetos[index]));
        }
    }

    private void ChangeObject(objeto3d objeto) {
        GameObject efecto = Instantiate(particulas,objetobase.transform);
        objetobase.SetObject(objeto.objeto);
        if (asource != null) {
            asource.Stop();
        }
        
        if (objeto.sonido != null) {
            asource.PlayOneShot(objeto.sonido);
        }
        Destroy(efecto, 1);
    }


}
    [System.Serializable]
    public class objeto3d
    {
        public tipoBtn tipoBtn;
        public string titulo;
        public GameObject objeto;
        public Sprite image;
        public AudioClip sonido;
       
    }

    public enum tipoBtn
    {
        text,
        image
    }