using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDouble : MonoBehaviour {

	private float ninjaDoubleAliveTime = 3.0f;
	
	// Use this for initialization
	void Start () {

		Invoke ("DestroyNinjaDouble", ninjaDoubleAliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		// copy a ninja.gameObject, and set its color.alpha or animation, and its position is right next to ninja.gameObject
	}
	
	void OnTriggerEnter2D (Collider2D item)
	{
		switch (item.tag) {

		case "heart":
			HitHeart (item.gameObject);
			break;

		case "bomb":
			HitBomb (item.gameObject);
			break;

		case "sting":
			HitSting (item.gameObject);
			break;

		case "star":
			HitStar (item.gameObject);
			break;

		case "box":
			HitBox (item.gameObject);
			break;

		case "shuriken":
			HitShuriken (item.gameObject);
			break;

		case "ninjadouble":
			HitNinjaDouble (item.gameObject);
			break;

		case "vanish":
			HitVanish (item.gameObject);
			break;
		}
	}

	void DestroyNinjaDouble () {
		
		Destroy (this.gameObject);
	}

	void HitHeart (GameObject item) {

		// NinjaDouble is happy
		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		Destroy (this.gameObject);
		Destroy (item);
	}

	void HitBomb (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		Destroy (this.gameObject);
		Destroy (item);
	}

	void HitSting (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
			Invoke ("DestroyNinjaDouble", ninjaDoubleAliveTime);
		}
		item.tag = "Untagged";
		this.GetComponent<Item> ().enabled = true;
		this.enabled = false;
	}

	void HitStar (GameObject item) {
		
		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
			Invoke ("DestroyNinjaDouble", ninjaDoubleAliveTime);
		}
		// shining ninja double
		Destroy (item);
	}

	void HitBox (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		// hiiiiiiiiit boxxxxxxxxxxxx do sth
		Destroy (this.gameObject);
		Destroy (item);
	}

	void HitShuriken (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		Destroy (this.gameObject);
		Destroy (item);
	}

	void HitNinjaDouble (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		Destroy (this.gameObject);
		Destroy (item);
	}

	void HitVanish (GameObject item) {

		if (IsInvoking ("DestroyNinjaDouble")) {
			CancelInvoke ();
		}
		Destroy (this.gameObject);
		Destroy (item);
	}
}