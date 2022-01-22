using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public Transform rabbitParentObj;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRabbit", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRabbit()
    {
        var rabbit = Instantiate(rabbitPrefab, new Vector3(-13, 5, 0), Quaternion.identity, rabbitParentObj).GetComponent<AI>();
        rabbit.rabbitType = AI.Aggresive.Good;
    }
}
