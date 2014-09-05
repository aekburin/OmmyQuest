using UnityEngine;
using System.Collections;

public class AnimAtm : MonoBehaviour {
	
	private Animator animAtm;
	private AnimatorStateInfo currentBaseState;
	public float animSpeed;

	private GameObject soundmanager;

	private bool loopMove = false;
	private float time;
	public float LoopMovetime;

//	static int IdleState = Animator.StringToHash("Base Layer.Idle");		// and are used to check state for various actions to occur
	static int MoveState = Animator.StringToHash("Base Layer.Move");

//	bool Idle = false;
//	bool Move = false;
	// Use this for initialization
	void Start () {
		animAtm = GetComponent<Animator>();
		soundmanager = GameObject.Find("Sound_Manager");
	}
	
	// Update is called once per frame
	void Update () {
		if(loopMove)
		{
			time+=Time.deltaTime;

			if(time>LoopMovetime)
			{
				animAtm.SetBool("Move",true);
				time = 0;
			}
		}
	}

	void setLoopMove(bool state)
	{
		loopMove = state;
	}

	void FixedUpdate()
	{
		animAtm.speed = animSpeed;
		currentBaseState = animAtm.GetCurrentAnimatorStateInfo(0);

		if (currentBaseState.nameHash == MoveState)
		{
			if (!animAtm.IsInTransition(0))
			{
				// reset  bool so we can move again, and so that the state does not loop 
				animAtm.SetBool("Move", false);

			}
		}
	}

	void OnMove(bool state)
	{
		animAtm.SetBool("Move",state);
		soundmanager.SendMessage("PlaySoundATM",SendMessageOptions.DontRequireReceiver);
	}

	void SetAnimation(bool state)
	{
		animAtm.enabled = state;
	}
}
