using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform target;
	public Vector3 destance =new Vector3( 0f,5f,-10f);

	public float posisionDamping = 2.0f;
	public float rotationDamping = 2.0f;

	private Transform thisTransform;
	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
	 
		Vector3 wantedPosision = target.position + (target.rotation * destance);
		Vector3 currentPosision = Vector3.Lerp (thisTransform.position, wantedPosision, posisionDamping * Time.deltaTime);

		thisTransform.position = currentPosision;

		Quaternion wantRotation = Quaternion.LookRotation (target.position - thisTransform.position, target.up);

		thisTransform.rotation = wantRotation;


	}
}
