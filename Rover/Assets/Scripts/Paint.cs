using UnityEngine;

public class Paint : MonoBehaviour {

	[SerializeField]
	private float lookRadius = 10f;

	[SerializeField]
	private Camera cam;

	bool facing = true;
	float distance;

	void FixedUpdate(){

		if (Input.GetMouseButtonDown(0)){

			RaycastHit _hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out _hit)){

				if (_hit.collider.tag=="Terrain"){
					Debug.Log("Collided " + transform.position + " " + _hit.point);
					
					// distance = new Vector3.Distance(transform.position, _hit.point);
					// if (distance <= lookRadius && facing){
					// 	Debug.Log(_hit.point);
					// }
				}
			}
		}
	}
}
