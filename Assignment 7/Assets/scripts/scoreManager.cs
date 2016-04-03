using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
	public Text score;
	
	// Update is called once per frame
	void Update () {
		score.text = statsManager.score.ToString ();
	}
}
