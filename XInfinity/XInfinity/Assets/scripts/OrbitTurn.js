#pragma strict

var speed:float;
public var centerObject:GameObject;
function Start () {
	
}

function Update () {
	transform.RotateAround(centerObject.transform.position, new Vector3(0, 1, 0), speed*10 * Time.deltaTime);

}