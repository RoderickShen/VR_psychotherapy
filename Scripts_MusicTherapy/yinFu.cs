using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yinFu : MonoBehaviour {
	public GameObject YinFu;
	public int speed;
	public GameObject Fireworks;
	public AudioClip ac;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);

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
		Debug.Log ("12425425");
	}
}
