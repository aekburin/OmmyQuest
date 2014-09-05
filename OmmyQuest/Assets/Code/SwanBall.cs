using UnityEngine;
using System.Collections;

public class SwanBall : MonoBehaviour {
	public GameObject ball;
	float time = 0;
	// Use this for initialization
	void Start () {
		time = Random.Range (50, 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time--;
		} else {
			time = Random.Range (50, 100);
			Instantiate(ball,gameObject.transform.position,Quaternion.identity);		
		}
	}
}
