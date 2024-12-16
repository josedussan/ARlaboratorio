using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "climaData", menuName = "climaData", order = 1)]
public class ClimaScriptableObject : ScriptableObject
{
    public List<climaObject> climas;
}
