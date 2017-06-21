using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject player;
	public float cameraOffset;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		this.transform.position = new Vector3 (player.transform.position.x,
			player.transform.position.y + cameraOffset,this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x,
			this.transform.position.y,this.transform.position.z);
	}
}
