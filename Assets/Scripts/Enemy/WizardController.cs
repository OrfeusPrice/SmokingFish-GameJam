using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public WState State;
    void Start()
    {
        State = GetComponent<WMove>();
        State.WC = this;
        State.Enter();
    }

    void Update()
    {
        State.DoSmth();
    }
}
