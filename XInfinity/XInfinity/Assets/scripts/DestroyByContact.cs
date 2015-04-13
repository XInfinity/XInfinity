using UnityEngine;
using System.Collections;
	//public GameObject explosion;
	public class DestroyByContact : MonoBehaviour
	{
	
	void OnTriggerEnter(Collider other) 
	{
	/*	if (other.tag == "Player") {
						//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
						Destroy (other.gameObject);
						Destroy (gameObject);
		}
		else {*/
						//Instantiate (explosion, transform.position, transform.rotation);
						Destroy (other.gameObject);
						Destroy (gameObject);
						//gameController.AddScore (scoreValue);
				//}
	}
}