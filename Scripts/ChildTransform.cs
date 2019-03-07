using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTransform : MonoBehaviour {
	public Transform same;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localEulerAngles = new Vector3 (0, same.localEulerAngles.y, 0);
		transform.localPosition = new Vector3 (same.localPosition.x, 0, same.localPosition.z);
	}
}
