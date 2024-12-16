using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "atomoData", menuName = "atomoData", order = 1)]
public class atomoScriptableObject : ScriptableObject
{
    public List<atomoObject> objetos;
}
