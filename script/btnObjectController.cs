using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class btnObjectController : MonoBehaviour
{
    public Text tituloBtn;
    public Image imagenBtn;
    public Button objectBtn;

    public void Init(objeto3d data)
    {
        switch(data.tipoBtn){
            case tipoBtn.text:
                imagenBtn.gameObject.SetActive(false);
                tituloBtn.gameObject.SetActive(true);
                tituloBtn.text = data.titulo;
                break;
            case tipoBtn.image:
                imagenBtn.gameObject.SetActive(true);
                tituloBtn.gameObject.SetActive(false);
                imagenBtn.sprite = data.image;
                break;
        }
        
        

    }

    public void SetButton(UnityAction callback) {
        objectBtn.onClick.AddListener(callback);
    }
}
