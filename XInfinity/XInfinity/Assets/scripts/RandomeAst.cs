using UnityEngine;
using System.Collections;

public class RandomeAst : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardcount;
	
	void Start ()
	{
		SpawnWaves ();
	}
	
	void SpawnWaves ()
	{
		for (int i = 0; i<=hazardcount; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);
		}
	}
}
