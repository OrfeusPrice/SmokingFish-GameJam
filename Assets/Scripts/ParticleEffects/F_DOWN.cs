using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_DOWN : ParticleEffect
{
    public override void Effect(GameObject gameObj)
    {
        gameObj.GetComponent<Rigidbody2D>().gravityScale += 1.0f;
    }
}
