using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// /!\ nécessite UnityEditor
using UnityEditor;

// on doit ajouter un attribut pour définir quel component doit être customisé
[CustomEditor(typeof(MyComponentToBeCustomized))]
[CanEditMultipleObjects] // comme sons nom l'indique, pour faire de la multi-edition
public class MyCustomInspector : Editor // /!\ ne dérive pas de MonoBehaviour mais de Editor
{
	// pour pouvoir bénéficier de la multi-edition, du undo et de la gestion correcte des prefabs, il faut utiliser 
	// des SerializedProperty.
	// 
	SerializedProperty playerHp;
  SerializedProperty playerArmor;
  SerializedProperty controllerType;
  SerializedProperty speed;
  SerializedProperty deadZone;
  SerializedProperty sensitivity;

  void OnEnable()
  {
      // Setup the SerializedProperties.
  	// serializedObject est une variable fournie par l'Editor, cela correspond à la version sérialisée du component
  	// qui est dessiné / manipulé par l'utilisateur
  	playerHp 				= serializedObject.FindProperty ("playerHp");
	  playerArmor			= serializedObject.FindProperty ("playerArmor");
	  controllerType	= serializedObject.FindProperty ("controllerType");
	  speed						= serializedObject.FindProperty ("speed");
	  deadZone				= serializedObject.FindProperty ("deadZone");
	  sensitivity			= serializedObject.FindProperty ("sensitivity");
  }

  public override void OnInspectorGUI()
  {
      // /!\ mise à jour de l'objet sérialisé : OBLIGATOIRE si vous voulez avoir les bonnes informations dans l'inspector
      serializedObject.Update ();

      // Exemple d'affichage d'un élément d'inspecteur
      // ici un slider qui va de 0 à 100
      EditorGUILayout.IntSlider (playerHp, 0, 100);
			EditorGUILayout.IntSlider (playerArmor, 0, 100);

			// on peut aussi laisser Unity utiliser les éléments d'UI qui sont utilisés
			// par défaut pour chaque type de donnée en utilisant la fonction PropertyField
			EditorGUILayout.PropertyField(controllerType);
			EditorGUILayout.PropertyField(speed);

			// ici on va tester si on doit afficher les données liées à la manette
			if(controllerType.enumValueIndex == (int)MyComponentToBeCustomized.PlayerControllerType.GAMEPAD)
			{
				EditorGUILayout.PropertyField(deadZone);
				EditorGUILayout.PropertyField(sensitivity);
			}

			// Vous n'avez pas besoin de réécrire toutes les properties
			// vous pouvez demander à utiliser l'inspector par défaut, sauf pour certaines propriétés
			// ici l'exemple est un peu long mais on pourrait dessiner le reste des variables avec :
			DrawPropertiesExcluding(serializedObject,new string[]{
				"playerHp", "playerArmor", "controllerType", "speed", "deadZone", "sensitivity"
			});

			// DrawDefaultInspector();

			if(GUILayout.Button("Log"))
			{
				Debug.Log("log");
			}


      // /!\ : il faut ensuite appliquer les modifications qui auraient pu être faites durant cette frame
      // (ce que l'utilisateur modifie sont les données en mémoire, il faut les sérialiser pour les garder)
      serializedObject.ApplyModifiedProperties ();
  }
}
