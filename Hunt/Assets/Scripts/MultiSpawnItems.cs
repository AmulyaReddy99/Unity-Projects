using UnityEngine;
// using UnityEngine.AI;

public class MultiSpawnItems : MonoBehaviour {

	// public NavMeshSurface surface;

	public GameObject bait;
	public GameObject obstacle;

	public int baitCount = 50;
	public int obstacleCount = 10;
	int min = -150;
	int max = 150;

	void Start () {
		GenerateLevel();
		// surface.BuildNavMesh();
	}
	
	void GenerateLevel(){
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
