using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeBG : MonoBehaviour {

    public List<Material> Material;
    public int defaultMaterial;
    public int currentMaterial;
	public List<int> Price;
	public List<int> MyBG;
	public float gold;
	UISprite Buy;
	UILabel cash;
	UILabel coin;
	bool canbuy = false;
    // Use this for initialization
    void Start()
    {

		Buy = GameObject.Find("BT_Buy_Shop").GetComponent<UISprite>();
		MyBG = new List<int>();
		int[] tempMyBG = PlayerPrefsX.GetIntArray("MyBG");
		foreach(int i in tempMyBG)
		{
			MyBG.Add(i);
		}
		cash = GameObject.Find("Label_Cash").GetComponent<UILabel>();
		coin = GameObject.Find("LabelCoin").GetComponent<UILabel>();
		coin.text = "0";
		cash.text = Price[0].ToString();
        currentMaterial = defaultMaterial;
        renderer.material = Material[defaultMaterial];
    }
	void Update()
	{
		gold = PlayerPrefs.GetFloat("gold");
		coin.text = "0";
		if(MyBG.IndexOf(currentMaterial)>-1)
		{
			setDepth(0);
		}
		else
		{
			setDepth(2);
		}
		if(gold > Price[currentMaterial])
		{
			canbuy = true;
		}
	}
	public void setDepth(int depth)
	{
		Buy.depth = depth;
	}
    public void NextMaterial()
    {
        if ((currentMaterial + 1) > Material.Count - 1)
        {
            currentMaterial = 0;
            renderer.material = Material[currentMaterial];
            
        }
        else
        {
            currentMaterial += 1; 
            renderer.material = Material[currentMaterial];
            
        }
		cash.text = Price[currentMaterial].ToString();

    }
    public void PrevioussMaterial()
    {

        if ((currentMaterial - 1) < 0)
        {
            currentMaterial = Material.Count - 1;
            renderer.material = Material[currentMaterial];
            
        }
        else
        {
            currentMaterial -= 1;
            renderer.material = Material[currentMaterial];

        }
		cash.text = Price[currentMaterial].ToString();
    }
    public void SaveMeterial()
    {
		if(gold > Price[currentMaterial])
		{
			PlayerPrefs.SetFloat("gold",gold-Price[currentMaterial]);
	        defaultMaterial = currentMaterial;
	        renderer.material = Material[defaultMaterial];
	        PlayerPrefs.SetInt("IndexMaterialBG", defaultMaterial);
			if(MyBG.IndexOf(currentMaterial)<0)
			{
				MyBG.Add(currentMaterial);
			}
			PlayerPrefsX.SetIntArray("MyBG",MyBG.ToArray());
		}
    }
	public void selectMeterial()
	{
		PlayerPrefs.SetInt("IndexMaterialBG", defaultMaterial);
	}
    public void ResetToBeginMeterial()
    {
        renderer.material = Material[defaultMaterial];
    }
	
}
