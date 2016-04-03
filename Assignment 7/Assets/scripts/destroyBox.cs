using UnityEngine;
using System.Collections;

public class destroyBox : MonoBehaviour {

	AudioSource aud;
	public AudioClip collect;
	void Start(){
		aud = GameObject.Find ("AudioManager").GetComponent<AudioSource> ();
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("player")) {
			if (aud != null) {
				aud.PlayOneShot (collect);
				statsManager.score++;
				Destroy (this.gameObject);
			}
		}
	}
}
