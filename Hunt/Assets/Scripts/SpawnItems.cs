using UnityEngine;
// using UnityEngine.AI;

public class SpawnItems : MonoBehaviour {

	// public NavMeshSurface surface;

	public GameObject bait;
	public GameObject player;
	public GameObject obstacle;

	public int baitCount = 50;
	public int obstacleCount = 10;
	int min = -150;
	int max = 150;

	private bool playerSpawned = false;

	void Start () {
		GenerateLevel();
		// surface.BuildNavMesh();
	}
	
	void GenerateLevel()
	{
		
		if (!playerSpawned){
			// Spawn the player
			Vector3 pos = new Vector3(0, 1, 0);
			Instantiate(player, pos, Quaternion.identity);
			playerSpawned = true;
		}

		for (int i = 0; i<baitCount; i++){
			// Spawn a bait
			Vector3 pos = new Vector3(Random.Range(min, max), 0.75f, Random.Range(min, max));
			Instantiate(bait, pos, Quaternion.identity, transform);
		}

		for (int i = 0; i<obstacleCount; i++){
			// Spawn the obstacle
			Vector3 pos = new Vector3(Random.Range(min, max), 0.75f, Random.Range(min, max));
			Instantiate(obstacle, pos, Quaternion.identity);
		}
	}

}
