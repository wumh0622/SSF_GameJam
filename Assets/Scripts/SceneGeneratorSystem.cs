using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGeneratorSystem : MonoBehaviour {

    static public SceneGeneratorSystem instance;

    [SerializeField] private Transform[] spawnPoint_Up;
    [SerializeField] private Transform[] spawnPoint_Down;
    [SerializeField] private GameObject[] item;

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

    public void StartGenerat()
    {
        StartCoroutine(Generating());
    }

    IEnumerator Generating()
    {
        yield return 0;
    }
}
