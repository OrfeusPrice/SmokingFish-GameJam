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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PhObj") Destroy(this.gameObject); 
    }
}
