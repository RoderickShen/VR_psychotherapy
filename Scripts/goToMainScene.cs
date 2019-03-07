using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToMainScene : MonoBehaviour {
	public SteamVR_TrackedObject track;
	//手柄
	SteamVR_TrackedObject trackedobj;
	void Awake()
	{
		trackedobj = GetComponent<SteamVR_TrackedObject> ();
	}
	// Update is called once per frame
	void Update () {
		var device=SteamVR_Controller.Input((int)trackedobj.index);
		bool isPressGrip = device.GetPress (SteamVR_Controller.ButtonMask.Grip);
		if (isPressGrip) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Main");
		}
	}
}