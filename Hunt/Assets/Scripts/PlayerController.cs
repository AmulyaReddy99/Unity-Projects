using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera cam;

	public NavMeshAgent agent;

	public Rigidbody rb;

	public ParticleSystem lightEmit;

	protected int score = 0;

	[SerializeField]
	private float speed = 5f;
	public float forwardForce = 8000f;
	public float sidewaysForce = 100f;

	void Awake(){
		// lightEmit.Stop();
		cam = FindObjectOfType<Camera> ();
	}
	
	void FixedUpdate () {

		if (Input.GetMouseButtonDown(0)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
				agent.SetDestination(hit.point);
		}

		float _xMov = Input.GetAxis("Horizontal");
		float _zMov = Input.GetAxis("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 velocity = (_movHorizontal + _movVertical) * speed;

		if (velocity != Vector3.zero)
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

	}

	void OnCollisionEnter(Collision collisionInfo){
		
		if(collisionInfo.gameObject.tag=="Bait"){
			// Debug.Log("Collided "+collisionInfo.gameObject.name.ToString());
			Vector3 pos = collisionInfo.gameObject.transform.position;
			Instantiate(lightEmit, pos, Quaternion.identity);
			// lightEmit.transform.position = collisionInfo.gameObject.transform.position;
			lightEmit.Play();
			Destroy(collisionInfo.gameObject);
			score++;
		}
	}
}
