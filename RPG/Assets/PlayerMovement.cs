using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	
	void FixedUpdate () {
		
		rb.AddForce(0, 0, 2000 * Time.deltaTime);

	}
}
