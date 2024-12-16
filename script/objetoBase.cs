using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objetoBase : MonoBehaviour
{
    private GameObject _objetobase;
    public void SetObject(GameObject newObject) {
        Destroy(_objetobase);
        _objetobase = Instantiate(newObject,this.transform);
    }
    
}
