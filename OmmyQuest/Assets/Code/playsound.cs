using UnityEngine;
using System.Collections;

public class playsound : MonoBehaviour {
	public AudioClip cash;
	public AudioClip click;
	public AudioClip Jump1;
	public AudioClip Jump2;
	public AudioClip IsSparked;
	public AudioClip ATM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlaysoundCash()
	{
		audio.PlayOneShot (cash,1);
	}
	public void PlaysoundClick()
	{
		audio.PlayOneShot (click,1f);
	}

	public void PlaySoundJump1()
	{
		audio.PlayOneShot (Jump1,1f);
	}

	public void PlaySoundJump2()
	{
		audio.PlayOneShot (Jump2,1f);
	}

	public void PlaySoundATM()
	{
		audio.PlayOneShot (ATM,1f);
	}
}
