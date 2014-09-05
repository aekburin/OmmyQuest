using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MapGenrator_Manager : MonoBehaviour
{
		public List<GameObject> ObjectType;
		public List<List<GameObject>> allObject;
		public float speed = 150;
		public Vector3[] lane;
		// Use this for initialization
		void Start ()
		{
			allObject = new List<List<GameObject>> ();
			addObject(0,5,new Vector3(0,0,247.4657f));
			addObject(1,10,new Vector3(0,0,100f));
		}
	
		// Update is called once per frame
		void Update ()
		{
			/*for (int i =0; i<allObject.Count; i++) {
				check (i,new Vector3(0,0,0));
			}*/
		check (0, new Vector3 (0, 0, 247.4657f));
		int randomLane = (int)Mathf.Floor(Random.Range (0, 3));
		check (1, lane[randomLane]);
		}
		void check(int index , Vector3 Range)
		{
			if (allObject [index] != null) {
				bool isRemove = false;
				foreach (GameObject a in allObject[index]) {
					float x = a.transform.position.x;
					float y = a.transform.position.y;
					float z = a.transform.position.z;
					a.transform.position = new Vector3 (x, y, z - 150 * Time.deltaTime);
				}
				for (int i=index; i<allObject[index].Count; i++) {
					if (allObject [index] [i].transform.position.z < (-allObject [index] [i].transform.localScale.z / 2)) {
						Destroy (allObject [index] [i]);
						allObject [index].RemoveAt (i);
						isRemove = true;
					}
				}
				if (isRemove) {
					isRemove = false;
					Generate_Map.createAsset (allObject [index], Range , index);
				}
				
			}
		}
		void addObject(int index,int count,Vector3 Range)
		{
			
			if (allObject.Count==0 || allObject.Count-1 < index) {
				allObject.Add (new List<GameObject> ());
			Debug.Log("add");
			}
			for (int i=0; i<count; i++) {
				allObject [index] = Generate_Map.createAsset (allObject[index], Range, index);
			}
		}
}
