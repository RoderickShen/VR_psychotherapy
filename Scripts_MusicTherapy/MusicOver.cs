using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOver : MonoBehaviour {
	public AudioSource music;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("dd",10);
	}
	void dd(){
		if (!music.isPlaying) {
			Destroy (gameObject);
		}
	}
}
