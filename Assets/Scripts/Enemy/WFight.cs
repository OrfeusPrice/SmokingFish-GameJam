using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFight : WState
{
    public GameObject bulletPrefab; 
    public float fireRate = 1f; 
    public float bulletSpeed = 10f; 
    public float range = 5f; 

    private float nextFireTime = 0f;
    void Start()
    {
        
    }

    public override void Enter()
    {
        WC.GetComponent<Animator>().SetBool("isRun", false);
        WC.GetComponent<Animator>().SetBool("isFight", true);
    }

    public override void DoSmth()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (transform.position.x - player.position.x < 0) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;


        if (Vector2.Distance(transform.position, player.position) <= range && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }

        if (Mathf.Abs(player.position.x - transform.position.x) > range)
        {
            ChangeState();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Vector2 direction = (player.position - transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, 0) * bulletSpeed;
    }

    public override void ChangeState()
    {
        WC.State = GetComponent<WMove>();
        WC.State.Enter();
    }
}
