using UnityEngine;
using System.Collections;

public class Fibonacci : MonoBehaviour {

	void Start () {
		FibonacchiFunction ();
	}

	void FibonacchiFunction(){
		int n;
		int f0, f1, f2;

		f0 = 0;
		f1 = 1;

		Debug.Log (f0);

		while(f1 < 100){
			Debug.Log (f1);

			f2 = f0 + f1;
			f0 = f1;
			f1 = f2;
		}
	}
}