using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "planetaData", menuName = "planetaData", order = 1)]
public class PlanetaScriptableObject : ScriptableObject
{
    public List<planetaObject> planetas;

}
