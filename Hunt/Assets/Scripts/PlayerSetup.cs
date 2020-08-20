using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	[SerializeField]
	string remoteLayerName = "RemotePlayer";

	void Start(){
		if(!isLocalPlayer){
			for(int i = 0; i<componentsToDisable.Length; i++)
				componentsToDisable[i].enabled = false;
			gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
		}
		else
			Camera.main.gameObject.SetActive(false);
	}
}
