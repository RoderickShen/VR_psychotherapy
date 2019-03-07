using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class goToChildScene : MonoBehaviour {
	public string childScene1;
	public string childScene2;
	public string childScene3;
	public string childScene4;
	public VideoPlayer videoPlayer;
	public AudioSource audioSource;

	public void toSceneOne(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(childScene1);
	}
	public void toSceneTwo(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(childScene2);
	}
	public void toSceneThree(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(childScene3);
	}
	public void toSceneFour(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(childScene4);
	}
	public void PlayMovie(){
		videoPlayer.Play ();
		audioSource.Play ();
	}
	public void StopMovie(){
		videoPlayer.Pause();
		audioSource.Pause();
	}
}



