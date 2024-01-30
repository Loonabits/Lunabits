using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;


    public void Start(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate() {
        if (TargetInDistance()) {
            PathFollow();
        }
    }

    private void UpdatePath() {
        if (TargetInDistance() && seeker.IsDone())  {
            //seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow() {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) return;
    }

    private bool TargetInDistance() {

    }

    private bool OnPathComplete() {

    }
}
