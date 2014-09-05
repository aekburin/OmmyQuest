using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharactersFarm : MonoBehaviour {
	
	public characterStore characterSC;
	public List<string> charactersnameFarm;
	public int currentIndex;
	public bool isClickLeft;
	public bool isClickRight;
	public List<Vector3> Positions = new List<Vector3>();
	GameObject objectchasc;
	private int defaultIndex;
	private int fromIndex, toIndex;
	public GameObject currentGameobject,newObject;
	int lenght;
	private float t;
	public bool moving;
	private UILabel coin_lable; // coin

	void Start()
	{

		coin_lable = GameObject.Find("Balloon_msg").GetComponent<UILabel>();
		objectchasc = GameObject.Find ("DataLoad");
		characterSC = objectchasc.GetComponent<characterStore> ();
		lenght = characterSC.name.Count;
		charactersnameFarm = new List<string> ();
		moving = false;
		t = 0;
		currentIndex =0;
		//Debug.Log("currentIndex"+currentIndex);
		for(int i=0;i<lenght;i++)
		{
			if(characterSC.status[i] == "false")
			{
				//charactersFarm.Add(Instantiate(Resources.Load("Characters/"+characterSC.modelName[i]),new Vector3(0,-2.5f,11),Quaternion.Euler(0,180,0))as GameObject);
				charactersnameFarm.Add(characterSC.modelName[i]);
				Debug.Log(characterSC.modelName[i]+ " " + i.ToString()+ " " + lenght);
			}
		}

		currentGameobject = Instantiate(Resources.Load("Characters/"+charactersnameFarm[0]),new Vector3(0,-2.5f,11),Quaternion.Euler(0,180,0))as GameObject;
		if(charactersnameFarm[0] == "1")
		{
		Transform[] m = currentGameobject.GetComponentsInChildren<Transform>();
		//Debug.Log("Characters/m" +charactersnameFarm[0]);
		m[m.Length-1].renderer.material = Resources.Load ("Characters/m" +characterSC.meterial[0]) as Material;
		}

		coin_lable.text =  characterSC.usecoin[characterSC.modelName.IndexOf(charactersnameFarm[currentIndex])];

	}
	public void Move(bool fromLeft)
	{
		int index = currentIndex;
		
		if (fromLeft)
		{
			fromIndex = 0;
			toIndex = 2;
			index = currentIndex - 1;
		}
		else
		{
			fromIndex = 2;
			toIndex = 0;
			index = currentIndex + 1;
		}
		
		if (index >= charactersnameFarm.Count)
		{
			index  = 0;
		}
		else if (index < 0)
		{
			index  = charactersnameFarm.Count-1;
		}
		
		if (charactersnameFarm[index] == "1") {
			newObject = Instantiate (Resources.Load("Characters/"+charactersnameFarm[0]),Positions[2],Quaternion.Euler(0,180,0)) as GameObject;
			Transform[] me = newObject.GetComponentsInChildren<Transform> ();
			//Debug.Log(me.Length);
			for(int i=1;i<me.Length;i++)
			{
				//Debug.Log(characterSC.meterial[0]);
				if(me[i].renderer!=null)
					me[i].renderer.material = Resources.Load ("Characters/m" +characterSC.meterial[0]) as Material;
			}		
		}
		else
		{
			newObject = Instantiate (Resources.Load("Characters/"+charactersnameFarm[index]),Positions[2],Quaternion.Euler(0,180,0)) as GameObject;
		}
		//Debug.Log ("currentIndex" + charactersnameFarm[currentIndex]);
		newObject.name = "FarmChar";
		currentIndex = index;
	}
	void Update()
	{

		coin_lable.text =  characterSC.usecoin[characterSC.modelName.IndexOf(charactersnameFarm[currentIndex])];


		if (!moving)
		{
			if (Input.GetKeyDown(KeyCode.Q) || isClickRight)
			{
				if(charactersnameFarm.Count != 1)
				{
					moving = true;
					
					Move(false);
				}

			}
			else if (Input.GetKeyDown(KeyCode.E) || isClickLeft)
			{
				if(charactersnameFarm.Count != 1)
				{
					moving = true;
					
					Move(true);
				}
			}
		}
		else
		{
			MoveObject();
		}
	}
	void MoveObject()
	{
		Vector3 end = Positions[1];
		
		Vector3 start1 = Positions[fromIndex];
		Vector3 start2 = Positions[toIndex];
		
		newObject.transform.position = Vector3.Lerp(start1, end, t);
		currentGameobject.transform.position = Vector3.Lerp(end, start2, t);
		
		t += 0.05f;
		
		if (t >= 1.00001f)
		{
			DestroyObject(currentGameobject);
			currentGameobject = newObject;
			currentGameobject.transform.position = end;
			
			fromIndex = 0;
			moving = false;
			t = 0;
			isClickLeft = false;
			isClickRight = false;
		}
	}


}
