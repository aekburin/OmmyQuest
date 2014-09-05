using UnityEngine;
using System.Collections;

public class ColliderMiniGame : MonoBehaviour 
{
	private GameObject miniGameManager;

	// Use this for initialization
	void Awake()
	{

	}

	void Start()
	{
		miniGameManager = GameObject.Find ("Minigame_Manager");
	}

	void OnCollisionEnter (Collision collider)
	{

		if(collider.gameObject.tag == ("Thunder"))
		{
			miniGameManager.SendMessage("OnAttackedThunder", SendMessageOptions.DontRequireReceiver);
		}

	    if(collider.gameObject.tag == ("Floor"))
		{
			miniGameManager.SendMessage("OnFloor", SendMessageOptions.DontRequireReceiver);
			//Debug.Log ("Floor");
		}
	}
}
