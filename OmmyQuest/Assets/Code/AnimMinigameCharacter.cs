using UnityEngine;
using System.Collections;

public class AnimMinigameCharacter : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	public float animSpeed = 1f;

//	bool Jump1 = false;
//	bool Jump2 = false;

//	static int idleState = Animator.StringToHash("Base Layer 0.Idle2");
//	static int IsAttacked = Animator.StringToHash("Base Layer 0.Attacked_Thunder");	// these integers are references to our animator's states
	static int Jump01 = Animator.StringToHash("Base Layer 0.Jump01");		// and are used to check state for various actions to occur
	static int Jump02 = Animator.StringToHash("Base Layer 0.Jump02");		// within our FixedUpdate() function below

	public GameObject soundmanager;


	void Awake()
	{
		anim = GetComponent<Animator>();

		soundmanager = GameObject.Find("Sound_Manager");
	}

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.Q))
		{	
		
			anim.SetBool("IsAttacked",false);

		}

		if(Input.GetKeyDown(KeyCode.W))
		{

			anim.SetBool("Jump1",true);
	
		}
		if(Input.GetKeyDown(KeyCode.E))
		{

			anim.SetBool("Jump2",true);

		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			anim.SetBool("GoBase0",true);
		}*/

	}

	void setIsAttacked(bool state)
	{
		anim.SetBool("IsAttacked",state);
		//Debug.Log ("IsAttacked = "+state);

	}

	void SetJump1(bool state)
	{
		anim.SetBool("Jump1",state);

		if(anim.GetBool("IsAttacked") != true)
			soundmanager.SendMessage("PlaySoundJump1",SendMessageOptions.DontRequireReceiver);
		//Debug.Log ("Jump1 = "+state);
	}

	void SetJump2(bool state)
	{
		anim.SetBool("Jump2",state);

		if(anim.GetBool("IsAttacked") != true)
			soundmanager.SendMessage("PlaySoundJump2",SendMessageOptions.DontRequireReceiver);
		//Debug.Log ("Jump2 = "+state);
	}

	void SetAnimation(bool state)
	{
		anim.enabled = state;
		//Debug.Log ("Animator = "+state);
	}

	void GoBase0(bool state)
	{
		anim.SetBool("GoBase0",state);
		//Debug.Log ("GoBase0 = "+state);
	}

	void FixedUpdate()
	{
		anim.speed = animSpeed;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		if (currentBaseState.nameHash == Jump01)
		{


			if (!anim.IsInTransition(0))
			{
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump1", false);
			}
		}
		
		if (currentBaseState.nameHash == Jump02)
		{

			if (!anim.IsInTransition(0))
			{
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump2", false);
			}
		}
	}
}
