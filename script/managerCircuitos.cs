using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class managerCircuitos : MonoBehaviour
{
    public List<GameObject> luces,flujoElectrico;
    public GameObject luzBandera;
    public Animator swich;
    public GameObject flecha;
    public AudioSource asource;
    private string nombreObjeto;
    public bool bandera=false;
    private Touch toque;
    // Start is called before the first frame update
    void Start()
    {
        swich.GetComponent<Animation>();
        nombreObjeto= GetComponent<Transform>().name;
    }

    public void OnMouseDown()
    {
        flecha.SetActive(false);
        Debug.Log(nombreObjeto);
        swich.SetBool("accion",true);
        if (!bandera)
        {
            asource.Stop();
            asource.Play();
            for (int i = 0; i < luces.Count; i++)
            {
                luces[i].SetActive(true);
            }
            for (int i = 0; i < flujoElectrico.Count; i++)
            {
                flujoElectrico[i].SetActive(true);

            }
            bandera = true;
        }
        else
        {
            swich.SetBool("accion", false);

            for (int i = 0; i < luces.Count; i++)
                {
                    luces[i].SetActive(false);
                }
            for (int i = 0; i < flujoElectrico.Count; i++)
            {
                flujoElectrico[i].SetActive(false);
                

            }

            if (luzBandera != null)
            {
                if (luzBandera.activeInHierarchy)
                {
                    flujoElectrico[0].SetActive(true);

                }

            }

            bandera = false;
        }
    }

    public void controlarBandera(bool band) {
        bandera = band;
        for (int i = 0; i < flujoElectrico.Count; i++)
        {
            flujoElectrico[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            toque = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(toque.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider != null && hit.transform.name.Equals(nombreObjeto)) {
                    flecha.SetActive(false);
                    swich.SetBool("accion", true);
                    if (!bandera)
                    {
                        asource.Stop();
                        asource.Play();
                        for (int i = 0; i < luces.Count; i++)
                        {
                            luces[i].SetActive(true);
                            
                        }
                        for (int i = 0; i < flujoElectrico.Count; i++)
                        {
                            flujoElectrico[i].SetActive(true);

                        }
                        bandera = true;
                    }
                    else
                    {
                        swich.SetBool("accion", false);

                        for (int i = 0; i < luces.Count; i++)
                        {
                            luces[i].SetActive(false);
                        }
                        for (int i = 0; i < flujoElectrico.Count; i++)
                        {
                            flujoElectrico[i].SetActive(false);

                        }
                        if (luzBandera != null)
                        {
                            if (luzBandera.activeInHierarchy)
                            {
                                flujoElectrico[0].SetActive(true);

                            }

                        }

                        bandera = false;
                    }
                }
                
            }
            
        }
    }
}
