using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sustanciaQuimicaData", menuName = "sustanciaQuimicaData", order = 1)]
public class sustanciaQuimicaScriptableObject : ScriptableObject
{
    public List<sustanciaQuimicaObject> objetos;
}
