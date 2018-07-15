using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{

    static public GameManger instance;
    enum GameState
    {
        Start, Playing, Over
    }
    [SerializeField] bool spawnPower = true;
    [SerializeField] public float scollingSpeed = 3;

    GameState currentGameState = GameState.Start;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (currentGameState == GameState.Start)
        {
            if (Input.anyKeyDown)
            {
                if (spawnPower)
                {
                    SceneGeneratorSystem.instance.StartGenerat();
					UIManger.instance.GameStart();
                    currentGameState = GameState.Playing;
                }
            }
        }
        if (scollingSpeed != 0)
        {
            BackGroundScolling.instance.Scolling(scollingSpeed);
        }
    }

    public void Gameover()
    {

        UIManger.instance.EnableGameoverCanvas();
    }
}
