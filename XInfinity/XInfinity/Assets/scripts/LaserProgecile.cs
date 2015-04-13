using UnityEngine;
using System.Collections;

public class LaserProgecile : MonoBehaviour {

	public float speed =2f;
	public int damage= 25;
	private Transform thistransform;
	public Transform laserHitFXPrefab;


	// Use this for initialization
	void Start () {
		thistransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		thistransform.position += Time.deltaTime * speed * thistransform.forward;
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Enemy") {
			c.gameObject.SendMessage("TakeDamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}
}
