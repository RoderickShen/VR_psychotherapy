using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	//开火特效
	public GameObject muzzleFlash;
	//枪口位置
	[SerializeField]
	private Transform firePos;

	//手柄
	SteamVR_TrackedObject trackedobj;

	//射线检测结果
	RaycastHit hit;

	void Awake()
	{
		trackedobj = GetComponent<SteamVR_TrackedObject> ();
	}
	//float angle=0f;
	void FixedUpdate(){
		var device = SteamVR_Controller.Input ((int)trackedobj.index);
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			device.TriggerHapticPulse(2000);//震动
			GameObject go = GameObject.Instantiate (muzzleFlash);
			Destroy (go,1f);
			go.transform.position = firePos.position;
			go.transform.rotation = firePos.rotation;
			//如果检测有结果
			if (Physics.Raycast (firePos.position, firePos.forward, out hit, Mathf.Infinity)) {
				//打印结果名称
				if (hit.collider.name.Contains ("Zombie"))
					hit.collider.GetComponent<EnemyController> ().Hit (1);
			}
		}

	}

	void Start(){

	}

	void Update(){

	}

}
