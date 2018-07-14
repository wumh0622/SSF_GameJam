using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

	[SerializeField]
	private int hp;
	[SerializeField]
	private bool canBeHurt;

	private const int MAX_HP = 3;
	private const int MIN_HP = 1;

	// Use this for initialization
	void Start () {
		hp = MAX_HP;
		canBeHurt = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		switch (other.tag) {

		case "heart":
			GainHp ();
			Destroy (other.gameObject);
			break;

		case "sting":
			LoseHp ();
			Destroy (other.gameObject);
			break;

		case "bomb":
			LoseHp ();
			Destroy (other.gameObject);
			break;

		case "star":
			GetStar ();
			Destroy (other.gameObject);
			break;

		case "box":
			Destroy (other.gameObject);
			break;
		}
	}

	void GainHp () {

		if (!IsValidHp (++hp)) 
			hp = MAX_HP;
	}

	void LoseHp () {
		
		if (canBeHurt)
			if (IsDead (--hp)) 
				GameOver ();
	}

	bool IsValidHp (int hp) {
		
		return (hp > MAX_HP) ? false : true;
	}

	bool IsDead (int hp) {

		return (hp <= MIN_HP) ? true : false;
	}

	void GetStar () {

		canBeHurt = false;

		if (IsInvoking ("LoseStar"))
			CancelInvoke ();

		Invoke ("LoseStar", 3.0f);
	}

	void LoseStar () {

		canBeHurt = true;
	}

	void GetBox () {
	}

	void GameOver () {
		Destroy (this.gameObject);
	}
}
