using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyerScript : MonoBehaviour
{
    [SerializeField]private Player thePlayer;
    [SerializeField]private float scale;
    [SerializeField]private float speed;
    [SerializeField]private float maxdistance;

    void FixedUpdate()
    {
        if((transform.position.x - thePlayer.transform.position.x) <= maxdistance)
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed * Time.deltaTime);

        if (thePlayer.transform.position.x < transform.position.x)
        {
            EnemyFlyerMovement(-1);
        }
        else
        {
            EnemyFlyerMovement(1);
        }
    }

    void EnemyFlyerMovement(float i)
    {
        transform.localScale = new Vector3(scale * i, scale, scale);
    }
}
