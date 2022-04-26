using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkerScript : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float scale;
    [SerializeField]private float checkerRadius;

    [SerializeField]private Transform wallChecker;
    [SerializeField]private Transform edgeChecker;
    [SerializeField]private LayerMask whatIsBoundary;
    private Rigidbody2D walkerRB2D;

    [SerializeField]private bool flip;
    [SerializeField]private bool hittingWall;
    [SerializeField]private bool notAtEdge;


    // Start is called before the first frame update
    void Start()
    {
        flip = true;
        hittingWall = false;
        notAtEdge = false;
        walkerRB2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallChecker.position, checkerRadius, whatIsBoundary);
        notAtEdge = Physics2D.OverlapCircle(edgeChecker.position, checkerRadius, whatIsBoundary);

        if (!notAtEdge || hittingWall)
            flip = !flip;

        if (flip)
        {
            EnemyWalkerMovement(-1);
        }
        else
        {
            EnemyWalkerMovement(1);
        }
    }

    void EnemyWalkerMovement(float i)
    {
        transform.localScale = new Vector3(scale * i, scale, scale);
        walkerRB2D.velocity = new Vector2(speed * i, walkerRB2D.velocity.y);
    }
}
