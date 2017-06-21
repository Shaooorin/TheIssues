using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

	Image curtainColor;
	public AudioSource[] audioS;
	public AudioClip audioClip001;
	public AudioClip audioClip002;

	void Start () {
		curtainColor = GameObject.Find ("Curtain").GetComponent<Image> ();
		audioS = GameObject.Find ("Canvas").GetComponents<AudioSource> ();
		curtainColor.enabled = true;
		StartCoroutine ("CurtainFadeOut");
		audioS [0].clip = audioClip001;
		audioS [1].clip = audioClip002;
		audioS [0].Play ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "StartScene"){
			audioS [0].Stop ();
			audioS [1].PlayOneShot (audioClip002,1f);
			StartCoroutine ("CurtainFadeIn");
		}
	}

	//画面のフェード----------------------------------------------------------------------
	IEnumerator CurtainFadeOut(){
		for (int n = 9; n >= 0; n--){
			float alphaColor = n * 0.1f;
			curtainColor.color = new Color (0,0,0,alphaColor);
			yield return new WaitForSeconds (0.1f);
		}
	}

	IEnumerator CurtainFadeIn(){
		for (int n = 0; n <= 10; n ++){
			float alphaColor = n / 10.0f;
			curtainColor.color = new Color (0,0,0,alphaColor);
			yield return new WaitForSeconds (0.1f);
		}
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Field001");
	}
}