using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class walk : MonoBehaviour {
	public SteamVR_TrackedObject track;
	//手柄
	SteamVR_TrackedObject trackedobj;
	public GameObject go;
	public Transform dic;
	public float speed;
	// Use this for initialization
	void Awake()
	{
		trackedobj = GetComponent<SteamVR_TrackedObject> ();
	}
		
	float angle=0f;
	// Update is called once per frame
	void Update () {
		var device=SteamVR_Controller.Input((int)trackedobj.index);
		bool isPressTouchPad = device.GetPress (SteamVR_Controller.ButtonMask.Touchpad);

		if (isPressTouchPad) {
			Vector2 touchPos = device.GetAxis ();
			angle = Vector2.Angle (new Vector2 (0f, 1f), touchPos);
			Vector3 cross = Vector3.Cross (new Vector2 (0f, 1f), touchPos);
			angle = cross.z > 0f ? -angle : angle;
		}
		if (isPressTouchPad && angle <= 45f && angle > -45f) {
			go.transform.Translate (dic.forward* Time.deltaTime*speed,Space.Self);
		}
		if (isPressTouchPad && angle <= 135f && angle > 45f) {
			go.transform.Translate (dic.right * Time.deltaTime*speed,Space.Self);
		}
		if (isPressTouchPad &&( angle <= -135f || angle > 135f)) {
			go.transform.Translate (-dic.forward * Time.deltaTime*speed,Space.Self);
		}
		if (isPressTouchPad && angle <= -45f && angle > -135f) {
			go.transform.Translate (-dic.right* Time.deltaTime*speed,Space.Self);
		}
	}
}
