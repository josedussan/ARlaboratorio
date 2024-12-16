using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "reaccionData", menuName = "reaccionData", order = 1)]
public class reaccionScriptableObject : ScriptableObject
{

    public List<reaccionObject> reacciones;
}
