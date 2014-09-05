using UnityEngine;
using System.Collections;
using System;
public class ButtonBuyScript : MonoBehaviour {
	GameObject Store;
	characterShop cs;
	int myMoney;
	BoxCollider buttonBuy,buttonSelect;
	bool canclick =false;
	// Use this for initialization
	void Start () {
		buttonBuy = GameObject.Find("BT_SelectSkinBuy").GetComponent<BoxCollider>();
		buttonSelect = GameObject.Find("BT_Select").GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		buttonSelect.enabled = true;
		 myMoney = Convert.ToInt16(PlayerPrefs.GetFloat("money"));
		 Store = GameObject.Find ("Store(Clone)");
		characterStore chastore = GameObject.Find("DataLoad").GetComponent<characterStore>();
		if(Store != null){
			 cs = Store.GetComponent<characterShop> ();
			if(myMoney >= cs.Price[cs.currentIndex])
			{
				buttonBuy.enabled = true;
				buttonSelect.enabled = true;
				canclick = true;
			}
			else 
			{
				buttonBuy.enabled = false;
				if(chastore.modelName.IndexOf((cs.currentIndex+1).ToString()) == -1)
				{
					buttonSelect.enabled = false;
				}
				canclick = false;
			}

		}
	}
	void OnClick()
	{


		if(canclick)
		{
			PlayerPrefs.SetFloat("money",myMoney-cs.Price[cs.currentIndex]);
			GameObject CharacterStore = GameObject.Find("DataLoad");
			characterStore csStore = CharacterStore.GetComponent<characterStore>();
			csStore.AddCharacter (cs.currentIndex+1,cs.Price[cs.currentIndex].ToString(),cs.coin[cs.currentIndex].ToString());
			Achivement ach = GameObject.Find ("DataManager").GetComponent<Achivement>();
			ach.findACBuddy (csStore.AllCharacters.Count);
		}

	}
}
