using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float forwardForce = 8000f;
	public float sidewaysForce = 100f;

	[SerializeField]
	private float speed = 5f;
	
	void FixedUpdate () {

		float _xMov = Input.GetAxis("Horizontal");
		float _zMov = Input.GetAxis("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 velocity = (_movHorizontal + _movVertical) * speed;

		if (velocity != Vector3.zero)
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

	}

	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.collider)
			Debug.Log("Collided"+collisionInfo.collider.name.ToString());
	}
}