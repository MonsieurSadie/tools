using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsExampleScript : MonoBehaviour
{
    [Tooltip("event that will fire when player dies")]
    public UnityEvent OnPlayerDeath     = null;
    [Tooltip("event that will fire when player gains score")]
    public UnityEvent OnPlayerScores    = null;

    
    void Update()
    {
        // on simule la mort du joueur par la touche K
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath.Invoke(); // on exécute les fonctions qui ont pu être enregistrées via l'inspector
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            if (OnPlayerScores != null)
            {
                OnPlayerScores.Invoke(); // on exécute les fonctions qui ont pu être enregistrées via l'inspector
            }
        }
    }
}
