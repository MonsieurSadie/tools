using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "My Name")]
[System.Serializable]
public class ScriptableExample : ScriptableObject
{ 
  public string name;
  public int nbData;
  public int nbEnnemiesAtSameTime;
  public int ennemiesSpeed;
}
