using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public int totalObject;
    public GameObject firstObject;
    public List<GameObject> ballPrefeb;
 
}


