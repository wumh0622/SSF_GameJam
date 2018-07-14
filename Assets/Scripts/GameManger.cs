using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    static public GameManger instance;

	void Awake()
	{
		if(instance == null)
		{
            instance = this;
        }
		else
		{
            Destroy(this);
        }
	}

    // Use this for initialization
    void Start () {
        SceneGeneratorSystem.instance.StartGenerat();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
