using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Paint : MonoBehaviour {

	[SerializeField]
	private float lookRadius = 10f;

	[SerializeField]
	private Camera cam;

	bool facing = true;
	float distance;

	public GameObject Brush;
	public float BrushSize = 0.02f;
	public RenderTexture RTexture;
	public GameObject plane;

	bool makePlane;

	void Start(){
		makePlane = true;
	}

	void FixedUpdate(){

		if (Input.GetMouseButton(0)){

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)){

				if (makePlane){
					Debug.Log("=====================------------>>" + hit.point);
					Instantiate(plane, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
					makePlane = false;
				}
				else{
					var go = Instantiate(Brush, hit.point + Vector3.up * 0.001f, Quaternion.identity, transform);
					go.transform.localScale = Vector3.one * BrushSize;

					if(hit.collider.tag=="Terrain"){
						Debug.Log("Collided " + transform.position + " " + hit.point);

						// distance = new Vector3.Distance(transform.position, _hit.point);
						// if (distance <= lookRadius && facing){
						// 	Debug.Log(_hit.point);
						// }
					}
				}
			}
		}
	}

	public void Save(){
		StartCoroutine(CoSave());
	}

	public IEnumerator CoSave(){
		yield return new WaitForEndOfFrame();
		Debug.Log(Application.dataPath + "/savedImage.png");

		RenderTexture.active = RTexture;

		var texture2D = new Texture2D(RTexture.width, RTexture.height);
		texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
		texture2D.Apply();

		var data = texture2D.EncodeToPNG();

		File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);
	}
}
