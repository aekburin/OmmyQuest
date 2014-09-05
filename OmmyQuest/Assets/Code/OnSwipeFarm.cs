using UnityEngine;
using System.Collections;

public class OnSwipeFarm : MonoBehaviour {

	public GameObject swipeObject;
	void Start()
	{
		GameObject camera = GameObject.Find("_CameraUI");
		GetComponent<SwipeRecognizer>().Raycaster = camera.GetComponent<ScreenRaycaster>();
	}
	void OnSwipe( SwipeGesture gesture )
	{
		// make sure we started the swipe gesture on our swipe object
		//   we use the object the swipe started on, instead of the current one

		GameObject selection = gesture.StartSelection; 
		if( selection == swipeObject )
		{
			Debug.Log ("Swiped " + gesture.Direction + " with finger " + gesture.Fingers[0] +
			           " (velocity:" + gesture.Velocity + ", distance: " + gesture.Move.magnitude + " )");
			
			GameObject Store = GameObject.Find ("Farm(Clone)");
			CharactersFarm cs = Store.GetComponent<CharactersFarm>();
			if(gesture.Direction.ToString() == "Left")
			{
				cs.isClickRight = true;
			}
			if(gesture.Direction.ToString() =="Right")
			{
				cs.isClickLeft = true;
			}

		}
	}
}
