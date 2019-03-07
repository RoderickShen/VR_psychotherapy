using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	//寻路组件
	private  NavMeshAgent agent;
	//玩家
	private GameObject player;
	//动画控制器
	private Animator ani;

	[SerializeField]
	private int healthPoint = 10;

	//攻击音效
	[SerializeField]
	private AudioClip attackAC;
	//死亡音效
	[SerializeField]
	private AudioClip deadAC;
	//平常音效
	[SerializeField]
	private AudioClip walkAC;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		ani = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
	}

	void SwitchAttack(bool value){
		ani.SetBool ("isAttack", value);
	}

	void SwitchDead(){
		ani.SetBool ("isDead",true);
		agent.Stop();//停止寻路
		this.GetComponent<CapsuleCollider>().enabled=false;//关掉碰撞器
		PlaySound(deadAC);
	}
	// Update is called once per frame
	void Update () {
		if (agent.enabled&&healthPoint>0) {
			agent.destination = player.transform.position;
			if (Vector3.Distance (this.transform.position, player.transform.position) < 3f) {
				SwitchAttack (true);
				agent.Stop ();
				PlaySound (attackAC);
			} else {
				SwitchAttack (false);
				agent.Resume ();
				PlaySound (walkAC);
			}
			}

		if (healthPoint <= 0) {
			AnimatorStateInfo asi = this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0);
			if (asi.normalizedTime > 1f && asi.IsName ("back_fall")) {
				Destroy (this.gameObject);
			}
		}
	}

	void PlaySound(AudioClip ac){
		this.GetComponent<AudioSource> ().clip = ac;
		this.GetComponent<AudioSource> ().Play ();
	}

	public void Hit(int point){
		int t = healthPoint - point;
		if (t > 0)
			healthPoint = t;
		else {
			healthPoint = 0;
			SwitchDead ();
		}
	}
}
