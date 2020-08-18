using UnityEngine;

public class SpawnBait : MonoBehaviour {

	public GameObject bait;
	public int baitCount = 50;
	int min = -150;
	int max = 150;

	void Start () {
		GenerateLevel();
	}
	
	void GenerateLevel()
	{
		for (int i = 0; i<baitCount; i++){
			// Spawn a bait
			Vector3 pos = new Vector3(Random.Range(min, max), 0.75f, Random.Range(min, max));
			Instantiate(bait, pos, Quaternion.identity, transform);
		}
	}

}
