using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerAtomoTabla : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> orbitas, eletronesOrbita1,protones,
        eletronesOrbita2, eletronesOrbita3, eletronesOrbita4, eletronesOrbita5, eletronesOrbita6, eletronesOrbita7;
    [SerializeField]
    private List<Material> materiales;
    [SerializeField]
    private atomoScriptableObject dataAtomo;
    // Start is called before the first frame update
    void Start()
    {
        ocultarTodo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarAtomo(string codigo) {
        ocultarTodo();
        int posicion = encontrarElemento(codigo);
        Debug.Log(posicion);
        for (int i=0;i< dataAtomo.objetos[posicion].numProtones;i++) {
            protones[i].SetActive(true);
            Renderer rend = protones[i].GetComponent<Renderer>();
            rend.material = materiales[dataAtomo.objetos[posicion].tipo];
           
        }
        int electrones = 0;
        for (int i=0;i<dataAtomo.objetos[posicion].numOrbitas;i++ ) {
            orbitas[i].SetActive(true);
            
            switch (i) {
                case 0:
                    electrones = dataAtomo.objetos[posicion].electOrbita1;
                    break;
                case 1:
                    electrones = dataAtomo.objetos[posicion].electOrbita2;
                    break;
                case 2:
                    electrones = dataAtomo.objetos[posicion].electOrbita3;
                    break;
                case 3:
                    electrones = dataAtomo.objetos[posicion].electOrbita4;
                    break;
                case 4:
                    electrones = dataAtomo.objetos[posicion].electOrbita5;
                    break;
                case 5:
                    electrones = dataAtomo.objetos[posicion].electOrbita6;
                    break;
                case 6:
                    electrones = dataAtomo.objetos[posicion].electOrbita7;
                    break;
            }
            Debug.Log("orbita: " + i + " electrones: " + electrones);
            activarElectronesOrbita(i,electrones);
        }
        
    }

    private void activarElectronesOrbita(int orbita,int numElectrones) {
        switch (orbita) {
            case 0:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita1[i].SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita2[i].SetActive(true);
                }
                break;
            case 2:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita3[i].SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita4[i].SetActive(true);
                }
                break;
            case 4:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita5[i].SetActive(true);
                }
                break;
            case 5:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita6[i].SetActive(true);
                }
                break;
            case 6:
                for (int i = 0; i < numElectrones; i++)
                {
                    eletronesOrbita7[i].SetActive(true);
                }
                break;
        }
    }

    private int encontrarElemento(string codigo) {
       
        int posicion = 0;
        for (int i=0;i<dataAtomo.objetos.Count;i++) {
            if (dataAtomo.objetos[i].numero.Equals(codigo)) {
                posicion = i;
            }
        }
        return posicion;
    }

    private void ocultarTodo() {
        for (int i=0;i<orbitas.Count;i++) {
            orbitas[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita1.Count; i++)
        {
            eletronesOrbita1[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita2.Count; i++)
        {
            eletronesOrbita2[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita3.Count; i++)
        {
            eletronesOrbita3[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita4.Count; i++)
        {
            eletronesOrbita4[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita5.Count; i++)
        {
            eletronesOrbita5[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita6.Count; i++)
        {
            eletronesOrbita6[i].SetActive(false);
        }
        for (int i = 0; i < eletronesOrbita7.Count; i++)
        {
            eletronesOrbita7[i].SetActive(false);
        }
        for (int i = 0; i < protones.Count; i++)
        {
            protones[i].SetActive(false);
        }
    }

    
}
[System.Serializable]
public class atomoObject
{
    public string numero;
    public int numProtones, numOrbitas, electOrbita1, electOrbita2, electOrbita3, electOrbita4, electOrbita5,
        electOrbita6, electOrbita7,tipo;
}
