using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float hitPoints= 100f;
	public float currentHitPoints;
	public GameObject destroyFX;

	// Use this for initialization
	void Start () {
		currentHitPoints = hitPoints; 
	}

	public void TakeDamage(float amt)
	{
		currentHitPoints -= amt;
		if (currentHitPoints <= 0) {
			currentHitPoints=0;
			Die();
		}
	}

	void Die ()
	{
		Debug.Log ("Die Die Die");
		if (gameObject.tag == "Enemy") {
			Instantiate(destroyFX,this.transform.position,this.transform.rotation);
			Destroy(gameObject);
		}
	}
}
