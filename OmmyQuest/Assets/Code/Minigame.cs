using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Minigame : MonoBehaviour {

	private string CurrentPage = "05_Minigame";

	public GameObject Character;
	public GameObject ATM;
	public LoadUI loadUI_dataload;
	public characterStore cs;

	private List<GameObject> Thunders;
	public int totalThunders ; // maximum of thunder Thunder
	private int indexThuder; 
	private int countThunder = 0;

	public AudioSource sound_Thunder;
	public AudioSource soundBGM;

	private GameObject particles; // 0 = shot , 1 = thunder , 2 = 100 score , 3 = 200 score , 4 = 300 score , 5 = 400 scores
	private List<string> nameParticles;
	public float timeDestroyParticles;

	public List<UISprite> buttons;
	public List<UISprite> Lifes;
	public UILabel totalDef;
	public UILabel scoreLabel;
	public UILabel HighScore_Label;
	public TweenPosition HightScoreGameOverMenu;

	private int IsAttackedTotal = 5;
	private bool isAttacked;
	private int score = 0;
	public int life = 3;

	private float time; // time to build thunder
	private float TheTimer; // Time Count Dowm
	private float timeStart = 5f; // 5 sec count down
	private float timeAttacked = 1f;

	private bool countDown = false;
	private bool pauseGame;
	private bool startGame = false;

	private string NameCharacter;
	private int HighScore;
	private int isJump = 0;
	private bool jump2 = false;

	private float gold; 
	
	private InteractiveConsole_Facebook facebookInterActive;

	void Awake()
	{	

		HighScore = PlayerPrefs.GetInt("HighSocre_Minigamge1");
		NameCharacter = PlayerPrefs.GetString("NameCharacter_Minigame");

		nameParticles = new List<string>();

		Thunders = new List<GameObject>();

		nameParticles.Add("FX_LightingOnCha/_LightingOnCha"); // index 0
		nameParticles.Add("FX_Score/JumpOnATM100"); // index 1
		nameParticles.Add("FX_Score/JumpOnATM200");	// index 2
		nameParticles.Add("FX_Score/JumpOnATM300");	// index 3
		nameParticles.Add("FX_Score/JumpOnATM400");	// index 4

		button0Enable();

		totalDef.enabled = false;

		Character = Instantiate(Resources.Load("Characters/"+NameCharacter),new Vector3(-0.048f,-5.987309f,16.8f),Quaternion.Euler(0,180,0)) as GameObject;

		if(NameCharacter=="1")
		{
			String[] temps = PlayerPrefsX.GetStringArray("character");
			String[] splittemps = temps[0].Split(' ');
			Transform[] m = Character.GetComponentsInChildren<Transform>();
			//Debug.Log("Characters/m" +splittemps[6]);
			m[m.Length-1].renderer.material = Resources.Load ("Characters/m" +splittemps[6]) as Material;
		}

		AnimCursed animCursed = Character.GetComponent<AnimCursed>();
		
		if(animCursed != null)
		{
			Destroy(animCursed);
		}
		
		BoxCollider boxCol = Character.GetComponent<BoxCollider>();
		
		if(boxCol != null)
		{
			Destroy(boxCol);
		}
		
		CapsuleCollider capsuleCol = Character.GetComponentInChildren<CapsuleCollider>();
		
		capsuleCol.enabled = true;
		
		Character.AddComponent("AnimMinigameCharacter");

	}

	// Use this for initialization
	void Start()
	{
		gold = PlayerPrefs.GetFloat("gold");

		loadUI_dataload = GameObject.Find("DataLoad").GetComponent<LoadUI>();
		loadUI_dataload.enabled = false;

		cs = GameObject.Find("DataLoad").GetComponent<characterStore>();

		sound_Thunder = GameObject.Find("Sound_Thunder").GetComponent<AudioSource>();
		soundBGM = GameObject.Find("Sound_Manager").GetComponent<AudioSource>();
		Character.SendMessage("GoBase0",true,SendMessageOptions.DontRequireReceiver);

		if(GameObject.Find("Facebook_Object") != null)
		{
	    facebookInterActive = GameObject.Find("Facebook_Object").GetComponent<InteractiveConsole_Facebook>();

		}

		TheTimer = timeStart;
		Thunders = new List<GameObject>();

	}

	public void shareScreen()
	{
		facebookInterActive.ShareScreen();
	}

	public void StartGame()
	{
		button1Enable();
		startGame = true;
		countDown = true;
		totalDef.enabled = true;

	}

	private void GameOver()
	{
		/*if(score > HighScore || HighScore == null)
		{
			PlayerPrefs.SetInt("HighSocre_Minigamge1",score);
			HighScore_Label.text = score.ToString();
		}*/

		if(score > 200f)
		{
			if(int.Parse(cs.usecoin[cs.modelName.IndexOf(NameCharacter)]) > 0)
			{
			gold+=1f;
			PlayerPrefs.SetFloat("gold",gold);
			//Debug.Log((int.Parse(cs.usecoin[cs.modelName.IndexOf(NameCharacter)])-1).ToString());
			cs.usecoin[cs.modelName.IndexOf(NameCharacter)] = (int.Parse(cs.usecoin[cs.modelName.IndexOf(NameCharacter)])-1).ToString();
			cs.save();
			}
		}

		OnPause();
		HightScoreGameOverMenu.PlayForward(); // ui tween

		ATM.SendMessage("SetAnimation",false,SendMessageOptions.DontRequireReceiver);
		Character.SendMessage("SetAnimation",false,SendMessageOptions.DontRequireReceiver);

		DestroyAllGameObject();

		StopAllSound();
	}

	public void DestroyAllGameObject()
	{
		
		foreach(GameObject item in Thunders)
		{
			Destroy(item);
		}
		Destroy(particles);
	}
	public void DestroyDataload()
	{
		Destroy(GameObject.Find("DataLoad"));
	}

	public void StopAllSound()
	{
		soundBGM.Stop();
		sound_Thunder.Stop();
	}

	public void RestartGame()
	{

		GoToScene(CurrentPage);
	}

	public void BackToMainMenu()
	{
		GoToScene("04_ Main");
	}

	private void GoToScene(string name)
	{
		Application.LoadLevel(name);
	}

	void BuildThunder(string name)
	{
			
		Thunders.Add(Instantiate(Resources.Load(name))as GameObject);

	}

	public void OnPause()
	{
		if(!pauseGame)
		{
			pauseGame = true;

			foreach(GameObject item in Thunders)
			{
				Animator thunder = item.GetComponent<Animator>();
				thunder.enabled = false;
			}
			Character.SendMessage("SetAnimation",false,SendMessageOptions.DontRequireReceiver);
		}
			
		else
		{
			pauseGame = false;
			
			foreach(GameObject item in Thunders)
			{
				Animator thunder = item.GetComponent<Animator>();
				thunder.enabled = true;
			}
			Character.SendMessage("SetAnimation",true,SendMessageOptions.DontRequireReceiver);
		}
			
		HighScore_Label.text = score.ToString();

	}
	
	public void button0Enable()
	{
		buttons[0].depth = 33;
		buttons[1].depth = 30;
		buttons[2].depth = 30;

	}
	public void button1Enable()
	{
		buttons[0].depth = 30;
		buttons[1].depth = 33;
		buttons[2].depth = 30;

	}
	public void button2Enable()
	{
		buttons[0].depth = 30;
		buttons[1].depth = 30;
		buttons[2].depth = 33;

	}

	public void AllBtnUnEnable()
	{
		foreach(UISprite item in buttons)
		{
			item.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(isAttacked)
		{
			ATM.SendMessage("setLoopMove",true,SendMessageOptions.DontRequireReceiver);

			timeAttacked -= Time.deltaTime;
			if(timeAttacked < 0)
			{
				score -= 100;
				scoreLabel.text = score.ToString();
				timeAttacked = 1f;
			}
				
		}
		else if(!isAttacked)
		{
			ATM.SendMessage("setLoopMove",false,SendMessageOptions.DontRequireReceiver);

		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			if(!pauseGame)
			{
				OnPause();
				//Debug.Log("P true");
			}
			else if(pauseGame)
			{
				OnPause();
				//Debug.Log("P false");
			}
				
		}

		else if(Input.GetKeyDown(KeyCode.H))
		{
			GetAllLife();
		}

		if(!pauseGame && startGame)
		{

			if(countDown)
			{
				TheTimer -= Time.deltaTime;
				//Debug.Log ("Timer = "+Mathf.Floor(TheTimer));
				totalDef.text = Mathf.Floor(TheTimer).ToString();

				if(TheTimer <= 0)
				{
					countDown = false;
					totalDef.enabled = false;
					BuildThunder("Thunder00");
					sound_Thunder.Play();
					//Debug.Log ("Start Game");
				}
					
			}
	
		time += Time.deltaTime;

		if(time > (12) && countThunder != totalThunders)
		{
			time = 0;

			int index = UnityEngine.Random.Range(0,3);

				if(index == 3)
					index = 2;

			BuildThunder("Thunder0"+index.ToString());
			countThunder++;
			//Debug.Log("count thunder = "+countThunder);

			//delay = Random.Range(0,6);
			/*index++;
				if(index > 2)
					index = 0;*/
		}
		
		else if(life == 0)
		{
			GameOver();
			AllBtnUnEnable();
			//Debug.Log ("GameOver");
		}
		
		}
	}

	
	void OnFloor()
	{
		isJump = 0;
		jump2 = false;

		ATM.SendMessage("OnMove",true,SendMessageOptions.DontRequireReceiver);

		if(!isAttacked)
		{

			//Debug.Log ("On Floor");
			button1Enable();

			Character.SendMessage("Jump1",false,SendMessageOptions.DontRequireReceiver);
			Character.SendMessage("Jump2",false,SendMessageOptions.DontRequireReceiver);
			
			isJump = 0;

			if(countThunder == 0)
			{
				score += 100;
				createParticles(1);
				Destroy(particles,timeDestroyParticles);
			}
			 if(countThunder == 1)
			{
				score += 200;
				createParticles(2);
				Destroy(particles,timeDestroyParticles);
			}
			 if(countThunder == 2)
			{
				score += 300;
				createParticles(3);
				Destroy(particles,timeDestroyParticles);
			}
			 if(countThunder > 2)
			{
				score += 400;
				createParticles(4);
				Destroy(particles,timeDestroyParticles);
			}

			scoreLabel.text = score.ToString();

		}

	}

	void OnAttackedThunder()
	{
		isJump = 0;
		jump2 = false;
		isAttacked = true;

		totalDef.enabled = true;
		totalDef.text = IsAttackedTotal.ToString();

		button2Enable();

		CapsuleCollider cap = Character.GetComponentInChildren<CapsuleCollider>();

		if(cap.collider.enabled == true )
		{
			decreaseLife();
			cap.collider.enabled = false;
		}

		Character.SendMessage("setIsAttacked",true,SendMessageOptions.DontRequireReceiver);

		createParticles(0); // create particle Shock
		//Debug.Log ("On Attack");
	
	}

	void createParticles(int index) 
	{
		particles = Instantiate(Resources.Load(nameParticles[index])) as GameObject;
	}

	void decreaseLife()
	{
		life -=1;
		//Debug.Log ("life = "+life);
		Lifes[life].enabled = false;

	}
	void GetAllLife()
	{
		life = 3;
		foreach(UISprite item in Lifes)
		{
			item.enabled = true;
		}
	}

	public void OnClickDef()
	{

			IsAttackedTotal -= 1;
			totalDef.text = IsAttackedTotal.ToString();

			if(IsAttackedTotal == 0)
			{
				var thunder = GameObject.Find("_LightingOnCha(Clone)");
				Destroy(thunder); 
				//Debug.Log ("IsAttackedTotal = "+IsAttackedTotal);
				IsAttackedTotal = 5;

				Character.SendMessage("setIsAttacked",false,SendMessageOptions.DontRequireReceiver);

				CapsuleCollider cap = Character.GetComponentInChildren<CapsuleCollider>();
				cap.collider.enabled = true;

				isAttacked = false;
				totalDef.enabled = false;
				button1Enable();

			}

	}

	public void OnClickJump()
	{
		if(!jump2)
			isJump += 1;

		if(isJump == 1)
		{
			Character.SendMessage("SetJump1",true,SendMessageOptions.DontRequireReceiver);
		}
		else if(isJump == 2)
		{
			Character.SendMessage("SetJump2",true,SendMessageOptions.DontRequireReceiver);
			jump2 = true;
			isJump = 0;
		}
	}
}
