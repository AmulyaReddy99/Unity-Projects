using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	public float lookSensitivity = 3f;
	
	void Update () {
		
		transform.position = GameObject.FindWithTag("Player").transform.position + offset;
		
		if(Input.GetKey("d"))
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+lookSensitivity,0);

		if(Input.GetKey("a"))
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y-lookSensitivity,0);	

		if (Mathf.Abs(transform.eulerAngles.y) > 360) 
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y%360f,0);
	}
}