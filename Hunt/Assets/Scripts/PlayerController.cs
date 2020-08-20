using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Camera cam;
	public NavMeshAgent agent;
	public Rigidbody rb;
	public ParticleSystem lightEmit;

	public int score = 0;

	Text scoreText;
	
	void Awake(){
		// lightEmit.Stop();
		cam = FindObjectOfType<Camera> ();
		scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
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
