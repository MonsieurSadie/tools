using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItemExample : MonoBehaviour
{
  // MenuItem va, lui, faire apparaître un nouvel élément dans la barre de menu
  // la fonction appelée doit être statique et n'est pas liée à un game object particulier.
  // --> elle n'a donc pas accès à l'inspector de base.
  // Une autre conséquence est que l'on n'a pas besoin d'ajouter ce script à un game object
  // (les fonctions statiques ont cette propriété d'exister en dehors de l'exécution et d'un contexte de game object)

  // on peut également ajouter un shortcut à cet item (% représente la touche ctrl, donc ici la combinaison est ctrl-g)
  
  // /!\ tout cela requière d'importer la librairie UnityEditor (voir dans les using plus haut)
  [MenuItem("MyMenu/Do Something with a Shortcut Key %g")] 
  static void DoSomethingWithAShortcutKey()
  {
      Debug.Log("Doing something with a Shortcut Key...");
  }
}
