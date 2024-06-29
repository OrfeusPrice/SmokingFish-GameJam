using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFight : WState
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Enter()
    {
        WC.GetComponent<Animator>().SetBool("isRun", false);
        WC.GetComponent<Animator>().SetBool("isFight", true);
    }

    public override void DoSmth()
    {

    }

    public override void ChangeState()
    {
        WC.State = GetComponent<WMove>();
        WC.State.Enter();
    }
}
