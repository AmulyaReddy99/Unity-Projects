using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

	public PlayerWeapons weapons;
	public ParticleSystem blast;
	
	[SerializeField]
	public NavMeshAgent agent;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	void Start () {
		if (cam == null)
			this.enabled = false;
	}

	void FixedUpdate (){

		if (Input.GetMouseButtonDown(0)){
			RaycastHit _hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			// if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapons.range, mask))	
			if (Physics.Raycast(ray, out _hit))
				if (_hit.collider.tag=="Obstacle" && Input.GetButtonDown("Fire1")){
					Destroy(_hit.collider.gameObject);
					Shoot(_hit.point);
				}
				else
					agent.SetDestination(_hit.point);
		}
	}

	void Shoot(Vector3 pos){
		Instantiate(blast, pos, Quaternion.identity);
		blast.Play();
	}

}
