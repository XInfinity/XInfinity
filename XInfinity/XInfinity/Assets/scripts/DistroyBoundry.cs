using UnityEngine;
using System.Collections;

public class DistroyBoundry : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Application.LoadLevel("MainMenuScense");
		}
		else{
			Destroy (other.gameObject);
	}
	}
}
