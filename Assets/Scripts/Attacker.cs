using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

//	GameObject player;

	void Start () {
//		player = GameObject.Find ("Player");
		StartCoroutine ("Suecide");
	}

	void Update () {
//		if(player.transform.localScale > 0){
//			
//		}
	}

	IEnumerator Suecide(){
		yield return new WaitForSeconds (6f);
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}
}