using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "seccionMapaData", menuName = "seccionMapaData", order = 1)]
public class seccionDataScriptable : ScriptableObject
{
    public List<seccionMapa> dataMapa;
}
