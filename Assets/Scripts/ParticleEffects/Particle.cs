using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    //public Dictionary<ParticleEffect, bool> part_effects = new Dictionary<ParticleEffect, bool>();
    public EnemyKnob knob;
    public string formula;

    private void Start()
    {
        knob = GameObject.FindGameObjectWithTag("EnemyKnob").GetComponent<EnemyKnob>();
        formula = knob.GetFormula();
        //part_effects = knob.part_effects;
        StartCoroutine(Destr());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PhObj")
        {
            //foreach (var item in part_effects)
            //{
            //    if (item.Value == true)
            //    {
            //        item.Key.Effect(collision.gameObject);
            //    }
            //}
            Destroy(this.gameObject);
        }
    }

    public string GetFormula() => formula;

    IEnumerator Destr()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
