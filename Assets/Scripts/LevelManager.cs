using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public int blockCount = 6;
	public float xInterval = 4f;
	public float zInterval = 4f;
	public GameObject ground;
	public List<GameObject> obstacles = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		for (int i=0; i<blockCount; i++) {
			Vector3 pos = new Vector3(i*50, 0, 0);
			GameObject g = (GameObject)Instantiate(ground);
			g.transform.position = pos;
			CreateObstacles(pos, 25f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	private Vector3 RandomVector3() {
		return new Vector3(
			Random.Range((-xInterval * 0.5f), (xInterval * 0.5f)),
			0,
			Random.Range((-zInterval * 0.5f), (zInterval * 0.5f))
		);
	}
	
	
	private void CreateObstacles(Vector3 center, float size) {
		GameObject ob;
		
		for (float x=center.x-size; x<center.x+size; x+=xInterval) {
			for (float z=center.z-size; z<center.z+size; z+=zInterval) {
				int i = Random.Range(-1, obstacles.Count);
				if (i == -1) continue;
				
				ob = (GameObject)Instantiate(obstacles[i]);
				ob.transform.position = new Vector3(x, 1f, z) + RandomVector3();
				ob.transform.localScale = new Vector3(
					ob.transform.localScale.x,
					Random.Range(0.5f, 12f),
					ob.transform.localScale.z
				);
			}
		}
	}
}
