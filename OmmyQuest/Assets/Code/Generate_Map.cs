using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Generate_Map : MonoBehaviour {
	public static List<GameObject> ObjectType;
	// Use this for initialization
	void Start () {
		ObjectType = GetComponent<MapGenrator_Manager> ().ObjectType;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static List<GameObject> createAsset(List<GameObject> List_Obj,Vector3 range,int index)
	{
		if (List_Obj.Count != 0) {
				Vector3 Position = List_Obj [List_Obj.Count - 1].transform.position;
				Vector3 newPosition = new Vector3 (0+ range.x, 0 + range.y, Position.z + range.z);      
				List_Obj.Add (Instantiate (ObjectType [index], newPosition, Quaternion.identity)as GameObject);
		} else {
			List_Obj.Add (Instantiate (ObjectType [index], new Vector3(range.x,range.y,0), Quaternion.identity)as GameObject);		
		}
		return List_Obj;
	}
}
