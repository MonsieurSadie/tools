using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AIScript : MonoBehaviour
{
  public enum State
  {
  	IDLE,
  	MOVING,
  	EATING,
  	SURFING,
  	USA
  }

  public State state = State.IDLE;
  float speed = 1;
  public Vector3 target;

  public float visionAngle = 60;
  public float visionDistance = 5;

  void Start()
  {
  	// on change de state toutes les 5 secondes
    InvokeRepeating("ChangeState", 5, 10);
  }

  void Update()
  {
  	if(state == State.MOVING)
  	{
  		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
  	}
  }

  void ChangeState()
  {
    int currentState = (int)state;
    currentState++;
    if(currentState > (int)State.USA) currentState = 0;
    state = (State) currentState;

    if(state == State.MOVING)
    {
    	target = Random.onUnitSphere * 5;
    }
  }
}
