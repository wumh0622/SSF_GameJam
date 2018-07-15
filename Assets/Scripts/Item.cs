using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    float speed;

    // Use this for initialization
    void Start () {
        speed = GameManger.instance.scollingSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }
}
