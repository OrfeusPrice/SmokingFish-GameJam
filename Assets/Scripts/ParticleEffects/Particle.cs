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
        GameObject.Find("SoundManager").GetComponent<Sounds>().PlaySound(0, 0.2f);
        knob = GameObject.FindGameObjectWithTag("EnemyKnob").GetComponent<EnemyKnob>();
        formula = knob.GetFormula();
        //part_effects = knob.part_effects;
        StartCoroutine(Destr());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
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
        */

        if (collision.gameObject.tag == "Enemy" && formula == "I=q/t")
            Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }

    public string GetFormula() => formula;

    IEnumerator Destr()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
