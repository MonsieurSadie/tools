using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuExample : MonoBehaviour
{
	int someData = 11;

	// ContextMenu permet d'exécuter une fonction en utilisant le menu contextuel d'un script depuis l'inspector
	// la fonction en question ne peut pas être paramétrée (mais elle peut accéder à des variables du script)
	[ContextMenu("Setup")]
  void SetupObjects()
  {
  	Debug.LogFormat("Calling SetupObjects");
  	Debug.LogFormat("doing something with a class variable of value {0}", someData);
  }
}
