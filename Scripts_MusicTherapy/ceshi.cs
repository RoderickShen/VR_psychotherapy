using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceshi : MonoBehaviour {

	public GameObject YinFu;
	public int speed;
	public GameObject Fireworks;
	public AudioClip ac;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider target)
	{                  //碰撞检测 
		if (target.gameObject.name.Contains("myHand")) 
		{ 
			GameObject fire = (GameObject)Instantiate(Fireworks, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(ac, transform.position);
			UIScore.Instance.Add(10);
			Destroy(gameObject);
		}
		if (target.gameObject.name.Contains("wall")) 
		{ 
			Destroy(gameObject);
		}
	}
}
