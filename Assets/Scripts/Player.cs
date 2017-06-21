using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Rigidbody2D rb2D;
	public float dash = 1.0f;
	AudioSource[] audioS = new AudioSource[2];
	public AudioClip auClip01;
//	public AudioClip auClip02;
	Animator anim;
	HealthGraph healthGraph;
	public GameObject attacker;
	public static int playerHP = 3;
	bool isPositCtrl = false;
	public float h;
	public bool gameOver = true;

	void Start(){
		gameOver = false;
		healthGraph = GameObject.Find ("cherryPanel").GetComponent<HealthGraph> ();
		rb2D = GameObject.Find ("Player").GetComponent<Rigidbody2D> ();
		anim = GameObject.Find ("Player").GetComponent<Animator>();
		audioS = GameObject.Find ("Player").GetComponents<AudioSource> ();
		audioS[0].clip = auClip01;
	}

	void Update(){
		h = 0.0f;
		if(Input.GetKey(KeyCode.RightArrow) && isPositCtrl == false){
			h = 1.0f;
		}else if(Input.GetKey(KeyCode.LeftArrow) && isPositCtrl == false){
			h = -1.0f;
		}
//		h = Input.GetAxisRaw("Horizontal");
		rb2D.velocity = new Vector2 (h * dash,rb2D.velocity.y);

		//走りのアニメーション遷移
		if(h != 0){
			anim.SetBool ("isRunning",true);
		}else if(h == 0){
			anim.SetBool("isRunning",false);
		}

		//ジャンプの処理
		if(Input.GetKeyDown(KeyCode.Space) && isPositCtrl == false){
			rb2D.AddForce (Vector2.up * dash, ForceMode2D.Impulse);
		}

		//アニメーションの反転
		if((transform.localScale.x > 0 && h < 0 || (transform.localScale.x < 0 && h > 0)) && isPositCtrl == false){
			transform.localScale = new Vector2 (transform.localScale.x * -1,transform.localScale.y);
		}

		//攻撃モーション
		if(Input.GetKeyDown(KeyCode.V) && isPositCtrl == false){
			anim.SetBool ("isAttack",true);
			audioS [0].PlayOneShot (auClip01,1f);
			Attack ();
		}else if(Input.GetKeyUp(KeyCode.V) && isPositCtrl == false){
			anim.SetBool("isAttack",false);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy"){
			healthGraph.HealthDown ();
			StartCoroutine ("Damaged");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			healthGraph.HealthDown ();
			StartCoroutine ("Damaged");
		}
	}

	//ダメージ処理
	IEnumerator Damaged(){
		anim.SetBool ("isDamaged",true);
		if(isPositCtrl == false){
			isPositCtrl = true;
			if(this.transform.localScale.x < 0){
				rb2D.AddForce (Vector2.left * dash,ForceMode2D.Impulse);
			}else if(this.transform.localScale.x > 0){
				rb2D.AddForce (Vector2.right * dash,ForceMode2D.Impulse);
			}
		}
		yield return new WaitForSeconds (1f);
		anim.SetBool ("isDamaged",false);
		isPositCtrl = false;

		if(healthGraph.n < 0){
			isPositCtrl = true;
			gameOver = true;
		}
	}

	void Attack(){
		if(this.transform.localScale.x < 0){
			Instantiate (attacker,new Vector2(this.transform.position.x + (-3f),this.transform.position.y),Quaternion.identity);
		}else if(this.transform.localScale.x > 0){
			Instantiate (attacker,new Vector2(this.transform.position.x + 3f,this.transform.position.y),Quaternion.identity);
		}
	}
}