using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

	// public NavMeshSurface surface;

	public GameObject player;
	public GameObject obstacle;

	private bool playerSpawned = false;
	private bool obstacleSpawned = false;

	void Start () {
		GenerateLevel();
		// surface.BuildNavMesh();
	}
	
	void GenerateLevel()
	{

		if (!playerSpawned)
		{
			// Spawn the player
			Vector3 pos = new Vector3(0, 1, 0);
			Instantiate(player, pos, Quaternion.identity);
			playerSpawned = true;
		}
		if (!obstacleSpawned)
		{
			// Spawn the player
			Vector3 pos = new Vector3(0, 1, 0);
			Instantiate(obstacle, pos, Quaternion.identity);
			obstacleSpawned = true;
		}
	}

}
