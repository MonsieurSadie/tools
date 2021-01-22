using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIScript))]
public class AICustomEditor : Editor
{
  void OnSceneGUI()
  {
  	AIScript ai = (AIScript)target;

    if (ai == null)
    {
        return;
    }

  	Handles.Label(ai.transform.position, ai.state.ToString());

  	if(ai.state == AIScript.State.MOVING)
  	{
  		// draw a line towards target
  		float dotLineSpacesInPixel = 4;
  		Handles.DrawDottedLine(	ai.transform.position, 
  														ai.target, 
  														dotLineSpacesInPixel);
  	}


  	// dessiner le cone de vision de l'IA
  	Handles.color = new Color(0.1f, 0.3f, 0.7f, 0.6f);
  	// la version suivante fait un arc de vision qui part du forward et va vers la droite
  	//Handles.DrawSolidArc(ai.transform.position, ai.transform.up, ai.transform.forward, ai.visionAngle, ai.visionDistance);

  	// si on veut que l'arc soit symétrique par rapport au forward, il faut faire démarrer à gauche du forward, de la moitié de l'arc
  	Quaternion halfAngleRot = Quaternion.AngleAxis(-ai.visionAngle*0.5f, ai.transform.up);
  	Vector3 arcStartDir = halfAngleRot * ai.transform.forward;
		Handles.DrawSolidArc(ai.transform.position, ai.transform.up, arcStartDir, ai.visionAngle, ai.visionDistance);  	
  }
}
