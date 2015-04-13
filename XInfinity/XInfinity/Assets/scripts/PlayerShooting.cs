using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public float coolDown=0f;
	public float fireRate=0f;

	public bool isFiring =false;

	public Transform centerFire;

	public GameObject laserPrefab;

	public AudioSource fireFXSound;


	// Use this for initialization
	void Start () {
		isFiring = false;

	}
	
	// Update is called once per frame
	void Update () {
		CheckInput ();
		coolDown -= Time.deltaTime;

		if (isFiring == true) {
			Fire();
		}
	}

	void CheckInput ()
	{
		if (Input.GetKeyDown ("z")) {
			isFiring = true;

		} else {
			isFiring=false;
		}
	}

	void Fire ()
	{
		if (coolDown > 0) {
			return;
		}	
		if (fireFXSound != null) {

			fireFXSound.Play();
		}
		GameObject.Instantiate (laserPrefab, centerFire.position, centerFire.rotation);
		coolDown = fireRate; 
	}
}













