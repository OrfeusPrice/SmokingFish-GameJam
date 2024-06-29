using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnob : MonoBehaviour
{
    public GameObject projectilePrefab;
    //public Dictionary<ParticleEffect, bool> part_effects = new Dictionary<ParticleEffect, bool>();
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;
    private string formula;

    private void Start()
    {
        //part_effects.Add(projectilePrefab.GetComponent<F_UP>(), true);
        //part_effects.Add(projectilePrefab.GetComponent<F_DOWN>(), false);
        //GetComponent<SpriteRenderer>().color = Color.blue;
        formula = "";
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * projectileSpeed;
            nextFireTime = Time.time + fireRate;
        }   

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    part_effects[projectilePrefab.GetComponent<F_UP>()] = true;
        //    part_effects[projectilePrefab.GetComponent<F_DOWN>()] = false;
        //    GetComponent<SpriteRenderer>().color = Color.blue;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    part_effects[projectilePrefab.GetComponent<F_UP>()] = false;
        //    part_effects[projectilePrefab.GetComponent<F_DOWN>()] = true;
        //    GetComponent<SpriteRenderer>().color = Color.red;
        //}
    }

    public void SetFormula(string text) => formula = text;

    public string GetFormula() => formula;
}
