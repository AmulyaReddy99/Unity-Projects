using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Camera cam;
	public NavMeshAgent agent;
	public Rigidbody rb;
	public Vector3 jump;
	public ParticleSystem lightEmit;
	public float jumpForce = 8000f;

	public int score = 0;
	public bool isGrounded = true;

	Text scoreText;
	
	void Awake(){
		// lightEmit.Stop();
		cam = FindObjectOfType<Camera> ();
		scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
	}
	
	void Update(){
		
		if (Input.GetButtonDown("Jump")){
			// Debug.Log(rb.velocity.y.ToString());
			// rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			rb.velocity = jump * jumpForce;
			// isGrounded = false;
		}
	}

	void FixedUpdate () {

		if (Input.GetMouseButtonDown(0)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
				if(hit.collider.tag != "Obstacle")
					agent.SetDestination(hit.point);
		}
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
			scoreText.text = score.ToString();
		}
	}
}