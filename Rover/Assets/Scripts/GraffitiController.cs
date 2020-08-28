using UnityEngine;
using UnityEngine.UI;

public class GraffitiController : MonoBehaviour {

	bool equipped = false;

	public Image icon;
	public GameObject graffiti;
	public Transform player;
	float graffitiZOffset;
	float graffitiYOffset;

	void Start(){
		graffitiYOffset = graffiti.transform.position.y - player.position.y;
		graffitiZOffset = player.position.z - graffiti.transform.position.z;
		graffiti.SetActive(false);
	}

	void FixedUpdate () {

		if (Input.GetKeyDown(KeyCode.G)){
			equipped = !equipped;
			if (equipped){
				icon.enabled = true;
				graffiti.SetActive(true);
			}
			else {
				graffiti.SetActive(false);
				icon.enabled = false;
			}
		}

		if (equipped)
			graffiti.transform.position = new Vector3(player.position.x, player.position.y + graffitiYOffset, player.position.z - graffitiZOffset);
	}
}
