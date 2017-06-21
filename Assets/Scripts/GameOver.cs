using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	Image image;
	Player player;

	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
		image = GameObject.Find ("GameOver").GetComponent<Image> ();
		image.enabled = false;
	}

	void Update () {
		if(player.gameOver == true){
			image.enabled = true;
			StartCoroutine ("GameOverFadeOut");
		}
		
	}

	public IEnumerator GameOverFadeOut(){
		image.enabled = true;
		yield return new WaitForSeconds (3f);
		for (int n = 9; n >= 0; n--){
			float alphaColor = n * 0.1f;
			image.color = new Color (0,0,0,alphaColor);
			yield return new WaitForSeconds (0.8f);
		}
	}

	public IEnumerator GameOverFadeIn(){
		image.enabled = true;
		for (int n = 0; n <= 10; n ++){
			float alphaColor = n / 10.0f;
			image.color = new Color (0,0,0,alphaColor);
			yield return new WaitForSeconds (0.1f);
		}
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Field001");
	}
}
