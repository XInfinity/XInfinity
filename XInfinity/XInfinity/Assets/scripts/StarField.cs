using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {
	
	private Transform thisTransform;
	private ParticleSystem.Particle[] points;

	public int startMax=100;
	public float startSize= 1f;
	public float startDistance=10f;
	public float startClipDistance =1f;

	private float startDistanceSqr;
	private float startClipDistanceSqr;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		startDistanceSqr = startDistance * startDistance;
		startClipDistanceSqr = startClipDistance * startClipDistance;
	}

	private void CreateStars(){

		points = new ParticleSystem.Particle[startMax];
		for (int i = 0; i < startMax; i++) {
			points[i].position=Random.insideUnitSphere*startDistance+thisTransform.position;
			points[i].color=new Color(1,1,1,1);
			points[i].size=startSize;
		}

	}
	// Update is called once per frame
	void Update () {
		if (points == null) {
			CreateStars();
		}		

		for (int i = 0; i < startMax; i++) {
			if ((points [i].position - thisTransform.position).sqrMagnitude > startDistanceSqr) {
				points [i].position = Random.insideUnitSphere.normalized * startDistance + thisTransform.position;
			}
			if ((points [i].position - thisTransform.position).sqrMagnitude <= startClipDistanceSqr) {
				float Percent = (points [i].position - thisTransform.position).sqrMagnitude / startClipDistanceSqr;

				points [i].color = new Color (1, 1, 1, Percent);
				points [i].size = Percent * startSize; 
			}
		}
		GetComponent<ParticleSystem>().SetParticles(points,points.Length);
	}
}


















