using UnityEngine;
using System.Collections;

public class Taco : MonoBehaviour {
	
	bool moveOn = false;
	public float moveForce = 0.1f;
	public float instaOffset = 0.5f;
	public GameObject missile;

	AudioSource[] enemyAudio;
	public AudioClip enemClip01;

	Rigidbody2D rb2D;
	public float dash = 1.0f;

	void Start(){
		rb2D = GameObject.Find ("TacoChu").GetComponent<Rigidbody2D> ();
		enemyAudio = GameObject.Find ("TacoChu").GetComponents<AudioSource> ();
		enemyAudio [0].clip = enemClip01;
	}
		
	void Update(){
		//最終的にはプレイヤーが近くにいるときといないときで処理を書き分ける
		while(moveOn == false){
			StartCoroutine("TacoAction");
		}
	}
		
	IEnumerator TacoAction(){
		moveOn = true;
		int actionNum = (int)Random.Range (1f,3f);

		if(actionNum == 1){
			Move ();
		}else if(actionNum == 2){
			Attack ();
		}else if(actionNum == 3){
//			Debug.Log ("敵待機する");
		}
		int randomTimer = (int)Random.Range (1f,4f);
		yield return new WaitForSeconds ((float)randomTimer);
		moveOn = false;
	}

	void Move(){
		int random = (int)Random.Range (1f,3f);
		if(random == 1){
			for(int i = 0;i < 3;i++){
				rb2D.AddForce (transform.right * moveForce,ForceMode2D.Impulse);
				transform.localScale = new Vector2 (transform.localScale.x * -1,transform.localScale.y);
			}
		}else if(random == 2){
			for(int i = 0;i < 3;i++){
				rb2D.AddForce (transform.right * (-1 * moveForce),ForceMode2D.Impulse);
				transform.localScale = new Vector2 (transform.localScale.x * -1,transform.localScale.y);
			}
		}
	}

	void Attack(){
		enemyAudio [0].PlayOneShot (enemClip01,1f);
		Instantiate (missile,
			new Vector3(this.transform.position.x,this.transform.position.y + instaOffset,this.transform.position.z),
			Quaternion.identity);
	}
}
