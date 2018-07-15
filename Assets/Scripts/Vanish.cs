using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour {

	private float vanishMoveSpeed = 0.05f;
	private const float vanishLeftEdge = -7.0f;
	private const float vanishRightEdge = 8.0f;
    public Ninja owner;
    [SerializeField] LayerMask LM;

    // Use this for initialization
    void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
		if (this.transform.position.x < vanishLeftEdge || this.transform.position.x > vanishRightEdge) {
			vanishMoveSpeed = -vanishMoveSpeed;
		}
		this.transform.Translate (vanishMoveSpeed, 0, 0);

		if(Input.GetButtonDown("Fire1"))
		{
            Collider2D[] overlap = Physics2D.OverlapCircleAll(transform.position, 1, LM, 0);
            foreach (var item in overlap)
			{
                Debug.Log(item.name);
                if(item.tag == "heart" || item.tag == "bomb"|| item.tag == "sting"|| item.tag == "star"|| item.tag == "box"|| item.tag == "Shuriken"|| item.tag == "NinjaDouble"|| item.tag == "Vanish")
				{
                    Destroy(item.gameObject);
                }
			}
            owner.currentWeaponState = Ninja.WeaponState.none;
            Destroy(gameObject);
        }
	}
}