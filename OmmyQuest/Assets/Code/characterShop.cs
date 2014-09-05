using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class characterShop : MonoBehaviour {
	public List<GameObject> allChar;
	public List<Vector3> Positions = new List<Vector3>();
	public List<int> Price;
	public List<int> coin;
	public int currentIndex = 0;
	public GameObject currentObject = null, newObject = null;
	public bool moving;
	public bool isClickLeft;
	public bool isClickRight;
	//set btnSelectSkin  
	public GameObject ButtonSelectSkinBuy;  
	public GameObject ButtonSelectSkin; 
	private UISprite btnSprite;
	private BoxCollider btnSelect;
	private BoxCollider btnBuy;
	private float t;
	private int fromIndex, toIndex;
	public bool[] have; 
	public UILabel mascotPrice;
	public UILabel mascotCash;
	public List<GameObject> allCharBlack;
	characterStore cs;
	// Use this for initialization
	void Start () {
		mascotPrice = GameObject.Find("LabelCoin").GetComponent<UILabel>();
		mascotCash = GameObject.Find("Label_Cash").GetComponent<UILabel>();
		cs = GameObject.Find("DataLoad").GetComponent<characterStore> ();
		cs.currentObject.transform.position = new Vector3(10,10,10);
		ButtonSelectSkinBuy = GameObject.Find ("BT_SelectSkinBuy");
		ButtonSelectSkin = GameObject.Find ("BT_Select");
		btnSprite = ButtonSelectSkinBuy.GetComponent<UISprite> ();
		btnSelect = ButtonSelectSkin.GetComponent<BoxCollider> ();
		btnBuy = ButtonSelectSkinBuy.GetComponent<BoxCollider> ();
		have = new bool[allChar.Count];
		cs = GameObject.Find ("DataLoad").GetComponent<characterStore>();
		for (int i = 0; i<cs.modelName.Count; i++) {
			have[int.Parse(cs.modelName[i])-1] = true; 
		}
		string[] cindex = cs.currentObject.name.Split ('(');
		currentObject = Instantiate(allChar[int.Parse(cindex[0])-1],Positions[1],Quaternion.Euler(0,180,0)) as GameObject;
		Transform[] me = currentObject.GetComponentsInChildren<Transform> ();
		if (cindex[0] == "1") {
			for (int i=1; i<me.Length; i++) {
					if (me [i].renderer != null)
					me [i].renderer.material = Resources.Load ("Characters/m" + cs.meterial [0]) as Material;
			}
		}
		currentObject.name = "storeChar";
		currentIndex = int.Parse(cindex[0])-1;
		moving = false;
		t = 0;
		mascotCash.text = "0";
		mascotPrice.text = Price[currentIndex].ToString();//price
		setDepthBack ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving)
		{
			if (Input.GetKeyDown(KeyCode.Q) || isClickRight)
			{
				btnSelect.enabled = false;
				btnBuy.enabled=false;
				moving = true;
				Move(false);
			}
			else if (Input.GetKeyDown(KeyCode.E) || isClickLeft)
			{
				btnSelect.enabled = false;
				btnBuy.enabled=false;
				moving = true;
				Move(true);
			}
		}
		else
		{
			MoveObject();
		}
		mascotCash.text = "0";
		mascotPrice.text = Price[currentIndex].ToString();

	} 
	
	 void setDepthBack()
	{
		btnSprite.depth = -2;
		btnSprite.transform.position.Set (0f, -184f, 0f);
	}
	 void setDepthFront()
	{
		btnSprite.transform.position.Set(0f, -143f, 0f); 
		btnSprite.depth = 2;
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
		
		if (index >= allChar.Count)
		{
			index  = 0;
		}
		else if (index < 0)
		{
			index  = allChar.Count-1;
		}

		if (index == 0) {
			newObject = Instantiate (allChar[0],Positions[2],Quaternion.Euler(0,180,0)) as GameObject;
			Transform[] me = newObject.GetComponentsInChildren<Transform> ();
			//Debug.Log(me.Length);
			for(int i=1;i<me.Length;i++)
			{
				//Debug.Log(cs.meterial[0]);
				if(me[i].renderer!=null)
					me[i].renderer.material = Resources.Load ("Characters/m" +cs.meterial[0]) as Material;
			}		
		}
		else
		{
			if(!have[index])
			{	
				newObject = Instantiate (allCharBlack [index],Positions[2],Quaternion.Euler(0,180,0)) as GameObject;
			}
			else
			{
				newObject = Instantiate (allChar [index],Positions[2],Quaternion.Euler(0,180,0)) as GameObject;
			}
		}
		newObject.name = "storeChar";

		if (!have [index]) 
		{
			setDepthFront ();

		} 
		else 
		{
			setDepthBack ();
		}
		currentIndex = index;
	}
	
	void MoveObject()
	{
		Vector3 end = Positions[1];
		
		Vector3 start1 = Positions[fromIndex];
		Vector3 start2 = Positions[toIndex];
		
		newObject.transform.position = Vector3.Lerp(start1, end, t);
		currentObject.transform.position = Vector3.Lerp(end, start2, t);
		
		t += 0.05f;
		
		if (t >= 1.00001f)
		{
			DestroyObject(currentObject);
			btnBuy.enabled = true;
			btnSelect.enabled = true;
			currentObject = newObject;
			currentObject.transform.position = end;
			
			fromIndex = 0;
			moving = false;
			t = 0;

			isClickLeft = false;
			isClickRight = false;
		}
	}


}
