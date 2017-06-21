using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthGraph : MonoBehaviour {

	Image[] cherryChain = new Image[3];
	Image cherry01;
	Image cherry02;
	Image cherry03;

	public bool current = false;
	public int n = 2;

	void Start () {
		cherry01 = transform.FindChild ("cherry01").GetComponent<Image> ();
		cherry02 = transform.FindChild ("cherry02").GetComponent<Image> ();
		cherry03 = transform.FindChild ("cherry03").GetComponent<Image> ();
		cherryChain [0] = cherry01;
		cherryChain [1] = cherry02;
		cherryChain [2] = cherry03;
	}

//	void Update () {
//		if(Input.GetKeyDown(KeyCode.Q)){
//			HealthDown ();
//		}
//	}

	public void HealthDown(){
		current = true;
		if((current == true) && n >= 0){
			cherryChain[n].enabled = false;
			n--;
			current = false;
		}
	}
}