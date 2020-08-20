using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 initial;
	public Vector3 offset;
	public float lookSensitivity = 3f;

	bool first = true;
	
	void Update () {
		
		// transform.position = GameObject.FindWithTag("Player").transform.position + offset;
		// transform.position = GameObject.FindWithTag("Player").transform.position + offset;

		// if(first){
		// 	transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+lookSensitivity,0);
		// 	first = false;
		// }
		
		if(Input.GetKey("d"))
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+lookSensitivity,0);

		if(Input.GetKey("a"))
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y-lookSensitivity,0);	

		if (Mathf.Abs(transform.eulerAngles.y) > 360) 
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y%360f,0);
	}
}