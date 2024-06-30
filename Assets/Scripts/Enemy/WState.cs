using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WState : MonoBehaviour
{
    public WizardController WC;
    public Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public virtual void Enter()
    {

    }

    public virtual void DoSmth()
    {

    }

    public virtual void ChangeState()
    {

    }
}
