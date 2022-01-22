using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
    private Transform player;

    public float moveSpeed = 3f;

    IAstarAI ai;

    public List<Vector3> buffer;
    private bool stale;

    private Rigidbody2D r2d;
    public Collider2D col;

    public float jumpForce = 10f;
    public LayerMask ground;

    void Awake()
    {
        ai = GetComponent<IAstarAI>();
        player = FindObjectOfType<PlayerController>().transform;
        col = this.GetComponent<Collider2D>();
        r2d = this.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed* Time.deltaTime);
        ai.destination = player.position;
        ai.GetRemainingPath(buffer, out stale);

        if (buffer.Count > 0)
        {
            bool goingRight = buffer[2].x > this.transform.position.x;
            Vector3 dir = goingRight ? Vector2.right : Vector2.left;
            this.transform.Translate(dir * moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    public void Jump(bool jumpLeft)
    {
        if (isGrounded() && !OnSameLevel()) 
        {
            r2d.AddForce(new Vector2(jumpLeft ? -5 : 5, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRight = transform.position;
        bottomRight.x += col.bounds.extents.x;
        bottomRight.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRight, ground);
    }

    private bool OnSameLevel()
    {
        if (this.transform.position.y > player.transform.position.y - 1f)
        {
            return true;
        }
        return false;
    }
}
