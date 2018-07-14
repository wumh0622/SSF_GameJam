using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour {

	private float vanishMoveSpeed = 0.05f;
	private const float vanishLeftEdge = -7.0f;
	private const float vanishRightEdge = 8.0f;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		if (this.transform.position.x < vanishLeftEdge || this.transform.position.x > vanishRightEdge) {
			vanishMoveSpeed = -vanishMoveSpeed;
		}
		this.transform.Translate (vanishMoveSpeed, 0, 0);
	}
	
	void OnTriggerEnter2D(Collider2D obj)
	{
		// when near area hit 'ninja', lose a heart
		// when near area hit 'heart', 'bomb', 'sting', 'invincible', 'box', 'shuriken', 'double', 'vanish', destroy(obj.gameObject)
	}
}