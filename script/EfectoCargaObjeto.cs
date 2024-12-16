using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EfectoCargaObjeto : MonoBehaviour
{
    [SerializeField]
    private GameObject particulas;
    [SerializeField]
    private GameObject objeto3D;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(particulas);

        StartCoroutine(WaitForSeconds(4f));
        objeto3D.SetActive(true);
    }

   IEnumerator WaitForSeconds(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(particulas);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
