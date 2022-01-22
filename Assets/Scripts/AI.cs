using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Transform player;

    public float moveSpeed = 10f;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }


    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed* Time.deltaTime);
    }
}
