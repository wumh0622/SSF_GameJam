using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScolling : MonoBehaviour {

	public static BackGroundScolling instance;
    [SerializeField] GameObject[] backGround;
    [SerializeField] float gap;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Scolling(float speed)
	{
        for (int i = 0; i < backGround.Length; i++)
		{
            backGround[i].transform.position = new Vector3( backGround[i].transform.position.x - Time.deltaTime * speed, backGround[i].transform.position.y, backGround[i].transform.position.z);
			if(backGround[i].transform.position.x < -gap)
			{
                backGround[i].transform.position = new Vector3(backGround[i].transform.position.x + gap * 3, backGround[i].transform.position.y, backGround[i].transform.position.z);
            }
        }
    }
}
