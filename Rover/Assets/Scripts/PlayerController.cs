using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public Rigidbody skateboard;

	public ThirdPersonCharacter character;

	public float forwardForce = 8000f;
	public float sidewaysForce = 100f;
	
	[SerializeField]
	private float speed = 10f;

	[SerializeField]
	private float lookRadius = 10f;

	[SerializeField]
	public float RotateSpeed = 1.0F;

	bool onBoard = false;

	public float offset = 1f;
	public float height;

	void Start(){
		height = transform.position.y - skateboard.position.y;
	}
	
	void FixedUpdate () {

		float _xMov = Input.GetAxis("Horizontal");
		float _zMov = Input.GetAxis("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 velocity = (_movHorizontal + _movVertical) * speed;

		if (velocity != Vector3.zero)
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

		transform.Rotate(0, _xMov * RotateSpeed, 0);

		float distance = Vector3.Distance(skateboard.position, transform.position);

		// if player presses r, toggle get in and out
		if (Input.GetKeyDown(KeyCode.R) && distance <= lookRadius){
			// walk to skateboard, face it and raise a little
			if (!onBoard){
				FaceTarget();
				transform.position = new Vector3(skateboard.position.x, transform.position.y + height, skateboard.position.z);
			} else
				transform.position = new Vector3(transform.position.x + offset, transform.position.y - height, skateboard.position.z);
			
			onBoard = !onBoard;
		}

		if(onBoard)
			skateboard.position = new Vector3(transform.position.x, skateboard.position.y, transform.position.z);
	}

	void FaceTarget ()
	{
		Vector3 direction = (skateboard.position - skateboard.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnCollisionEnter(Collision collision){
		if(LayerMask.LayerToName(collision.collider.gameObject.layer) == "Terrain")
			rb.velocity = Vector3.zero;
	}

}
