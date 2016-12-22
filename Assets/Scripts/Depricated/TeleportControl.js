

var target: Transform;

function Start () {
	
}

function OnTriggerEnter(col : Collider) {
	if(col.tag == "Player"){
	col.transform.position = target.position;

	}
}
