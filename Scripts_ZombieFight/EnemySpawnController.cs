using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
	//僵尸
	[SerializeField]
	private GameObject zombie;
	//生成间隔
	[SerializeField]
	private float interval = 8f;
	//计时
	private float timeCount=0;

	// Use this for initialization
	void Start () {
		timeCount = 4f;
	}
	
	// Update is called once per frame
	void Update () {
		//如果倒计时结束则生成一个僵尸并倒计时重置
		if (timeCount > 0) {
			timeCount -= Time.deltaTime;
		} else {
			GameObject z = Instantiate (zombie, this.transform.position, this.transform.rotation)as GameObject;
			timeCount = interval;
		}
	}
}
