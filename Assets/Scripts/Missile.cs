using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	GameObject target;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Target");
		StartCoroutine ("Suecide");
	}

	void Update(){
		this.transform.position = Vector2.MoveTowards (this.transform.position,
			new Vector2(target.transform.position.x,target.transform.position.y),
			(speed * Time.deltaTime));
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Destroy(this.gameObject);
		}
	}

	/// <summary>
	/// 自身のオブジェクトを引数の秒数後(float型)に破棄。
	/// </summary>
	IEnumerator Suecide(){
		yield return new WaitForSeconds (8f);
		Destroy (this.gameObject);
	}
}