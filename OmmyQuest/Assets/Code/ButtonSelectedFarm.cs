using UnityEngine;
using System.Collections;

public class ButtonSelectedFarm : MonoBehaviour {

	GameObject Store;
	characterShop cs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnClick()
	{
		Store = GameObject.Find ("Store(Clone)");
		cs = Store.GetComponent<characterShop> ();
		GameObject CharacterStore = GameObject.Find("DataLoad");
		characterStore csStore = CharacterStore.GetComponent<characterStore>();
		csStore.swapCharacter(cs.currentIndex, "select");

	}
}
