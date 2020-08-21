using UnityEngine;
using UnityEngine.Networking;

public class SpawnOverNetwork : NetworkBehaviour {

	public GameObject bait;
	public GameObject obstacle;

	public int baitCount = 25;
	public int obstacleCount = 5;
	int min = -150;
	int max = 150;

	void Start () {
		CmdGenerateLevel();
		// surface.BuildNavMesh();
	}
	
	[Command]
	void CmdGenerateLevel(){
		
		GameObject[] objects = new GameObject[30];

		for (int i = 0; i<baitCount; i++){
			// Spawn a bait
			Vector3 pos = new Vector3(Random.Range(min, max), 0.75f, Random.Range(min, max));
			objects[i] = Instantiate(bait, pos, Quaternion.identity);
		}

		for (int i = 0; i<obstacleCount; i++){
			// Spawn the obstacle
			Vector3 pos = new Vector3(Random.Range(min, max), 0.75f, Random.Range(min, max));
			objects[baitCount+i] = Instantiate(obstacle, pos, Quaternion.identity);
		}

		// if(isLocalPlayer)
		for (int i = 0; i<objects.Length; i++)
			NetworkServer.Spawn(objects[i]);

	}
}
