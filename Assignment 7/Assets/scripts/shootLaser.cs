using UnityEngine;
using System.Collections;

public class shootLaser : MonoBehaviour {
	public Rigidbody2D laser;
	public Transform shotTrans;
	public float hMove;
	bool isInstantiated = false;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		anim.SetBool ("isShooting", isInstantiated);
		if (Input.GetKey (KeyCode.S) && isInstantiated == false) {
			isInstantiated = true;
			StartCoroutine ("shoot");
			StartCoroutine ("reload");
		}
	}
	IEnumerator reload(){
		yield return new WaitForSeconds (1.0f);
		isInstantiated = false;
	}
	IEnumerator shoot(){
		yield return new WaitForSeconds (.3f);
		Rigidbody2D shot = Instantiate (laser, shotTrans.position, shotTrans.rotation) as Rigidbody2D;
		shot.velocity += new Vector2 (hMove, 0);
	}
}
