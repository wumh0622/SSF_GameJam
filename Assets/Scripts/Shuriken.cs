using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
	
	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		this.transform.position += new Vector3 (0.1f, 0, 0);

		this.transform.Rotate (new Vector3 (0, 0, 10));
	}
	
	void OnTriggerEnter2D(Collider2D item)
	{
		if (item.tag == "heart" || item.tag == "bomb" || item.tag == "star" || item.tag == "box") {

			Destroy (this.gameObject);
			Destroy (item.gameObject);
		}
	}
}