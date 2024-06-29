using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMove : WState
{
    public Transform p1;
    public Transform p2;
    public Transform player;

    public bool goToP1;
    public bool goToP2;

    public float speed;
    public Rigidbody2D rb;

    public float FightZone;
    public Color GizmosColor;

    public override void Enter()
    {
        goToP1 = true;
        goToP2 = false;
        WC.GetComponent<Animator>().SetBool("isRun",true);
        WC.GetComponent<Animator>().SetBool("isFight",false);
    }

    public override void DoSmth()
    {
        if (goToP1)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
            
            if(transform.position.x > p1.transform.position.x)
            {
                goToP1 = false;
                goToP2 = true;
            }
        }
        if (goToP2)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
            if (transform.position.x < p2.transform.position.x)
            {
                goToP2 = false;
                goToP1 = true;
            }
        }

        if (Mathf.Abs(player.position.x - transform.position.x) <= FightZone)
        {
            ChangeState();
        }
    }

    public override void ChangeState()
    {
        WC.State = GetComponent<WFight>();
        WC.State.Enter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawWireSphere(transform.position, FightZone);
    }
}
