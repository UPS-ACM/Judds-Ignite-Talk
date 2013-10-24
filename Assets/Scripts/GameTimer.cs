using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float labelWidth = 150f;
	
	private float levelTime = 0;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void Update () {
		levelTime += Time.deltaTime;
	}
	
	
	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label(new Rect((Screen.width * 0.5f) - (labelWidth * 0.5f), 10f, labelWidth, 25f),
			string.Format("Level time: {0:0.0} seconds", levelTime));
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		GUI.Label(new Rect((Screen.width * 0.5f) - (labelWidth * 0.5f), 35f, labelWidth, 25f),
			string.Format("Blocks passed: {0:0.0}", player.transform.position.x / 50));
	}
}
