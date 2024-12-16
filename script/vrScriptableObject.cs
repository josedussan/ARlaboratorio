using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "vrData", menuName = "vrData", order = 1)]
public class vrScriptableObject : ScriptableObject
{

    public List<vrObject> objetos;
}
