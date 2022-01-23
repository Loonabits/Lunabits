using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public Transform rabbitParentObj;
    public int normalRabbitsNumber, badRabbitsNumber, allRabbitsNumber;
    public int targetRabbitNumber = 5;
    public int targetBadRabbits = 2;
    private Dictionary<AI, bool> allRabbits = new Dictionary<AI, bool>(); //bool is whether the rabbit is bad, false is good.

    public Vector2[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRabbit", 5, 10);
        InvokeRepeating("TurnRabbit", 5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRabbit()
    {
        if (allRabbitsNumber < targetRabbitNumber)
        {
            allRabbitsNumber++;
            var rabbit = Instantiate(rabbitPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)], Quaternion.identity, rabbitParentObj).GetComponent<AI>();
            rabbit.rabbitType = AI.Aggresive.Good;
            normalRabbitsNumber++;
            allRabbits.Add(rabbit, false);
        }

    }


    void TurnRabbit()
    {
        var selected = allRabbits.LastOrDefault(x => x.Value == false).Key;
        selected.rabbitType = AI.Aggresive.Bad;
        allRabbits[selected] = true;
        badRabbitsNumber++;
        normalRabbitsNumber--;

        if (badRabbitsNumber > targetBadRabbits)
        {
            var rabbit = allRabbits.FirstOrDefault(x => x.Value == true).Key;
            rabbit.rabbitType = AI.Aggresive.Good;
            allRabbits[rabbit] = false;
            badRabbitsNumber--;
            normalRabbitsNumber++;
        }
    }
}
