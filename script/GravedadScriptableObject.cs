using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gravedadData", menuName = "gravedadData", order = 1)]
public class GravedadScriptableObject : ScriptableObject
{
    public List<GravedadObject> gravedades;
}
