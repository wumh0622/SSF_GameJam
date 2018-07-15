using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    static public GameManger instance;
	enum GameState
	{
		Start,Playing,Over
	}
    [SerializeField] bool spawnPower = true;
    [SerializeField] float scollingSpeed = 3;

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
<<<<<<< HEAD

        if (spawnPower)
=======
        
		if (spawnPower)
>>>>>>> 26e44679829fdb3ee0e134d1c44627b4528b65c4
        {
            SceneGeneratorSystem.instance.StartGenerat();
        }
    }
	
	// Update is called once per frame
	void Update () {
        
		if (scollingSpeed != 0)
        {
            BackGroundScolling.instance.Scolling(scollingSpeed);
        }
    }

	public void Gameover () {

		UIManger.instance.EnableGameoverCanvas ();
	}
}
