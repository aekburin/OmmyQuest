using UnityEngine;
using System.Collections;

public class createnewCharacter : MonoBehaviour {
	public UILabel name;
    ChangeMaterial_OLD cmo;
	public GameObject manager;

	// Use this for initialization
	void Start () {
		cmo = manager.GetComponent<ChangeMaterial_OLD> ();
	}
	
	// Update is called once per frame
	void Update () {
		//cmo = manager.GetComponent<ChangeMaterial_OLD> ();
	}
	public void createCharcter()
	{
		string[] array = new string[1];
		array [0] = "true 1 0 " + name.text + " 0 1 "+(cmo.currentMaterial+1)+" 150"+" "+0+" "+0;
		PlayerPrefsX.SetStringArray ("character",array);
		Debug.Log (array[0]);
	}
}
