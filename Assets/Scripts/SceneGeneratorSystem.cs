using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGeneratorSystem : MonoBehaviour
{

    static public SceneGeneratorSystem instance;

    public enum PropType
    {
        sting, heart, bomb, star, box, substitute, Shuriken, vanish
    }

    [Header("SpawnPoint")]
    [SerializeField] private Transform[] spawnPoint_Up;
    [SerializeField] private Transform[] spawnPoint_Down;
    [Space(50)]
    [Header("prefab")]
    [SerializeField] private GameObject[] item;
    [Header("Setting")]
    [SerializeField] private int item_P;
    [SerializeField] private int weapon_P;
    [SerializeField] private int[] choose = new int[] { 20, 20, 20, 20, 20, 20, 20, 20 };
    [SerializeField] private float spawnRate = 1;

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

    public void StartGenerat()
    {
        StartCoroutine(Generating());
    }

    IEnumerator Generating()
    {
/*         int random = Random.Range(0, 2);
        if (random == 0)
        {
            Spawn(RandomChoose(), 0);
        }
        random = Random.Range(0, 2);
        if (random == 0)
        {
            Spawn(RandomChoose(), 1);
        } */
        Spawn(RandomChoose(), 0);
        Spawn(RandomChoose(), 1);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(Generating());
        yield break;
    }

    PropType RandomChoose()
    {
        int randomValue = Random.Range(0, 160);
        for (int i = 0; i < choose.Length; i++)
        {
            randomValue -= choose[i];
            if (randomValue < 0)
            {
                return (PropType)i;
            }
        }
        return (PropType)0;
    }

    void Spawn(PropType type, int location)
    {
        if (location == 0)
        {
            switch (type)
            {
                case PropType.sting:
                    if (Random.Range(0, 1) == 0)
                        Instantiate(item[0], spawnPoint_Up[0].position, spawnPoint_Up[0].rotation);
                    else
                        Instantiate(item[0], spawnPoint_Up[spawnPoint_Up.Length - 1].position, spawnPoint_Up[spawnPoint_Up.Length - 1].rotation);
                    break;
                case PropType.heart:
                    int random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[1], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.bomb:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[2], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.star:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[3], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.box:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[4], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.substitute:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[5], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.Shuriken:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[6], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                case PropType.vanish:
                    random = Random.Range(0, spawnPoint_Up.Length);
                    Instantiate(item[7], spawnPoint_Up[random].position, spawnPoint_Up[random].rotation);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case PropType.sting:
                    if (Random.Range(0, 1) == 0)
                        Instantiate(item[0], spawnPoint_Down[0].position, spawnPoint_Down[0].rotation);
                    else
                        Instantiate(item[0], spawnPoint_Down[spawnPoint_Down.Length - 1].position, spawnPoint_Down[spawnPoint_Down.Length - 1].rotation);
                    break;
                case PropType.heart:
                    int random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[1], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.bomb:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[2], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.star:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[3], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.box:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[4], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.substitute:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[5], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.Shuriken:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[6], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                case PropType.vanish:
                    random = Random.Range(0, spawnPoint_Down.Length);
                    Instantiate(item[7], spawnPoint_Down[random].position, spawnPoint_Down[random].rotation);
                    break;
                default:
                    break;
            }
        }
    }
}
