using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InteractiveObject : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 velocity;
    private bool mouseOnColl;
    [SerializeField] private GameObject panel;
    private PhysPanel physPanel;
    private float time = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseOnColl = false;
        panel = GameObject.FindGameObjectWithTag("PhysPanel");
        physPanel = panel.GetComponentInChildren<PhysPanel>();
        panel.SetActive(false);
    }

    void Update()
    {
        RMBPressed();
    }

    private void RMBPressed()
    {
        if (!panel.activeSelf && mouseOnColl && Input.GetMouseButtonDown(1))
        {
            panel.SetActive(true);
            StartCoroutine(WaitingFormula());
            Debug.Log("Click RMB");
        }

        if (panel.activeSelf)
            PhysMagic();
    }

    private IEnumerator WaitingFormula()
    {
        physPanel.SetInteractiveObject(this);
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
    }

    private void PhysMagic()
    {
        //if (Input.GetKeyDown(KeyCode.Right)
            //Debug.Log("Pressed Enter");
        //StopCoroutine(WaitingFormula());
    }

    public bool GetFormula(string text)
    {
        if (time < 1000) // Если регексы подходят
        {
            StopCoroutine(WaitingFormula());
            return true;
        }
        return false;
    }

    private void OnMouseEnter()
    {
        mouseOnColl = true;
    }

    private void OnMouseExit()
    {
        mouseOnColl = false;
    }
}
