using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// une classe lambda contenant des données que l'on va vouloir afficher de manière customisée dans l'inspector
public class MyComponentToBeCustomized : MonoBehaviour
{
	public enum PlayerControllerType
	{
		[InspectorName("clavier")] // change le nom d'une option d'enum dans l'inspector
		KEYBOARD,
		GAMEPAD
	};

	// l'attribut header sert à ajouter des catégories dans l'inspector (cosmétique)
	[Header("Player data")]

		// l'attribut Range permet de donner des limites aux valeurs que l'on peut lui donner 
		// (ici, via l'inspector, on ne pourra pas aller en-dessous de 0 ou au-dessus de 100)
		[Range(0,100)]
		public int playerHp = 100;

	  public int playerArmor = 0;

	  public string playerName = "Hero";


	[Header("Controls")]
	// Ici, on a un cas classique pour lequel un custom inspector peut être utile :
	// on a des variables qui ne sont utiles que pour un type de contrôleur.
	// Selon le contrôleur choisi, il serait bon de n'afficher qu'une partie des informations
  	public PlayerControllerType controllerType = PlayerControllerType.KEYBOARD;
  	public float speed = 10; // for all controllers
  	public float deadZone = 0.1f; // for gamepads
  	public float sensitivity = 0.9f; // for gamepads


  [Header("More")]
  public float moreData = 1.1f;
  public string strData = "___";

  void Start()
  {
      
  }

  
  void Update()
  {
      
  }
}
