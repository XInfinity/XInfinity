using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float maxTurnRate=1200f;
	public Vector3 maxImpuls=new Vector3(10f,10f,700f);
	public Vector3 velocity = Vector3.zero;
	public float implusSenstivity= 500f;
	public float turnSenstivity=1200f;

	public ParticleSystem liftExHostfx;
	public ParticleSystem rightExHostfx;

	private Vector3 impulse= Vector3.zero;
	private float desiredImpulse=0f;
	private Vector3 impulseActual=Vector3.zero;
	private float maxImpulseChange = 100f;
	private Vector3 turnRate = Vector3.zero;
	private float desiredImpulseInput=0f;
	private float desiredTurnXInput=0f;
	private float desiredTurnYInput=0f;	
	private float desiredInputX=0f;
	private float desiredInputY=0f;
	private float desireTurnX=0f;
	private float desireTurnY=0f;
	private Transform thisTransform;
	public float enginPowerValue=0f;
	public GUIText enginPercentageText;

	public Vector3 Velocity
	{
		get{
			return velocity;
		}
	}

	public Vector3 Impulse
	{
		get{
			return impulse;
		}
		set
		{
			impulse.x=Mathf.Clamp(value.x,0,maxImpuls.x);
			impulse.y=Mathf.Clamp(value.y,0,maxImpuls.y);
			impulse.z=Mathf.Clamp(value.z,0,maxImpuls.z);
		}

	}
	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}

	void OnEnginePowerChanged()	{

		if (enginPercentageText != null) {

			enginPowerValue = (desiredImpulse / maxImpuls.z*100)/100f;
			enginPercentageText.text = "Engine"+" "+ (enginPowerValue*100).ToString("f0")+"%";

		}

	}

	void AdjustEngineFX(){

		if (liftExHostfx != null && rightExHostfx != null) {

			liftExHostfx.startSize = 0.5f+enginPowerValue*0.75f;
			rightExHostfx.startSize=0.5f+enginPowerValue*0.75f;

			liftExHostfx.startSpeed=1f+enginPowerValue*4f;
			rightExHostfx.startSpeed=1f+enginPowerValue*4f;

		}

	}


	// Update is called once per frame
	void Update () {
		OnEnginePowerChanged ();
		AdjustEngineFX ();
		CheckInput ();

		thisTransform.Rotate (turnRate * Time.deltaTime, Space.Self);

		if (Vector3.Distance (impulse, impulseActual) < maxImpulseChange * Time.deltaTime) {
			impulseActual = impulse;
		} else {

			impulseActual += (impulse - impulseActual ).normalized*maxImpulseChange*Time.deltaTime;
		}
		velocity = thisTransform.rotation * impulseActual / 10f;
		thisTransform.Translate (velocity * Time.deltaTime, Space.World);

	}



	void CheckInput(){
		if (this == null) {
			return ;
		}
		desiredImpulseInput = 0f;
		desiredTurnXInput = 0f;
		desiredTurnYInput = 0f;
		desireTurnX = 0f;
		desireTurnY = 0f;

		desiredImpulseInput += Input.GetAxis ("Thrust") * implusSenstivity * Time.deltaTime;
		desiredImpulse = (Mathf.Clamp (desiredImpulseInput, GetImpulse2 (), GetMaxImpulse2 ()));
		desiredImpulse += desiredImpulseInput;

		desiredTurnXInput -= Input.GetAxis ("Vertical") * turnSenstivity * Time.deltaTime;
		desireTurnX = (Mathf.Clamp (desiredTurnXInput, -GetMaxTurnRate(), GetMaxTurnRate()));
		desireTurnX += desiredTurnXInput;

		desiredTurnYInput += Input.GetAxis ("Horizontal") * turnSenstivity * Time.deltaTime;
		desireTurnY = (Mathf.Clamp (desiredTurnYInput, -GetMaxTurnRate(), GetMaxTurnRate()));
		desireTurnY += desiredTurnYInput;

		SetImpalse2 (desiredImpulse);
		SetTurnRate (desireTurnX, desireTurnY, 0);
	}

	public void SetImpalse2 (float z)
	{
		Impulse = new Vector3 (0, 0, z);
	}


	public float GetImpulse2 ()
	{
		return impulse.z;
	}

	public float GetMaxImpulse2 ()
	{
		return maxImpuls.z;
	}

	public void SetTurnRate (float x, float y, float z)
	{	
		turnRate.x = Mathf.Clamp (x, -maxTurnRate, maxTurnRate);
		turnRate.y = Mathf.Clamp (y, -maxTurnRate, maxTurnRate);
		turnRate.z = Mathf.Clamp (z, -maxTurnRate, maxTurnRate);

	}

	public 	void SetTurnRate (Vector3 v)
	{
		SetTurnRate(v.x,v.y,v.z);
	}

	public Vector3 GetTurnRate()
	{
		return turnRate;
	}

	public float GetMaxTurnRate ()
	{
		return maxTurnRate;
	}
}



















