using UnityEngine;
using System.Collections;

public class AnimCursed : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	public float animSpeed = 1.5f;

//	static int idleState = Animator.StringToHash("Base Layer.Stand");
	static int CheerUp = Animator.StringToHash("Base Layer.CheerUp");	// these integers are references to our animator's states
//	static int LookAround = Animator.StringToHash("Base Layer.LookAround");		// and are used to check state for various actions to occur
//	static int SayHi = Animator.StringToHash("Base Layer.SayHi");		// within our FixedUpdate() function below
//	static int Sawasdee = Animator.StringToHash("Base Layer.Sawasdee");
//	static int Touch = Animator.StringToHash("Base Layer.Touch");

	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("CheerUp", true);
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.P))
		{	
			anim.SetBool("Touch",true);
		}

		if(Input.GetKeyDown(KeyCode.O))
		{
			anim.SetBool("Touch",false);
		}
		if(Input.GetKeyDown(KeyCode.T))
		{
			anim.SetBool("CheerUp",true);
		}
		if(Input.GetKeyDown(KeyCode.Y))
		{
			anim.SetBool("CheerUp",false);
		}*/
	}
	void FixedUpdate () {

		anim.speed = animSpeed;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		if (Input.touchCount > 0) 
		{   //  If there are touches...
			Touch theTouch  = Input.GetTouch(0);       //    Cache Touch (0)
			
			var ray = Camera.main.ScreenPointToRay(theTouch.position);
		
			if(Physics.Raycast(ray,out hit,50))
			{ 
				if(Input.touchCount == 0)
				{
					anim.SetBool("Touch",false);
				}

				if(Input.touchCount == 1)
				{
					//anim.SetBool("CheerUp", true);

					if (theTouch.phase == TouchPhase.Began) 
					{
						// if touch began doSomething
					}     
					
					if (theTouch.phase == TouchPhase.Moved)
					{
						anim.SetBool("Touch",true);
					}

					if (theTouch.phase == TouchPhase.Ended)
					{
						anim.SetBool("Touch",false);
					}
				}
			}
		}

		if (currentBaseState.nameHash == CheerUp)
		{
			if (!anim.IsInTransition(0))
			{
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("CheerUp", false);
			}
		}

		/*if (currentBaseState.nameHash == Touch)
		{
			if (!anim.IsInTransition(0))
			{
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Touch", false);
			}
		}*/
	}
}