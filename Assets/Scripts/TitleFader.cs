using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleFader : MonoBehaviour {

	Image titleColor;
	bool isFade = false;

	void Start () {
		titleColor = GameObject.Find ("Title").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		while(isFade == false){
			StartCoroutine("FadeLoop");
		}
	}

	IEnumerator FadeLoop(){
		isFade = true;
		for (int n = 0; n <= 10; n ++){
			float alphaColor = n / 10.0f;
			titleColor.color = new Color (255,255,255,alphaColor);
			yield return new WaitForSeconds (0.12f);
		}

		yield return new WaitForSeconds (0.8f);

		for (int n = 9; n >= 0; n --){
			float alphaColor = n / 10.0f;
			titleColor.color = new Color (255,255,255,alphaColor);
			yield return new WaitForSeconds (0.1f);
		}

		yield return new WaitForSeconds (0.8f);

		isFade = false;
	}
}
