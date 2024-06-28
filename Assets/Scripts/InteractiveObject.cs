using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Text.RegularExpressions;
using static System.Convert;
using System;

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
    }

    private IEnumerator WaitingFormula()
    {
        physPanel.SetInteractiveObject(this);
        Time.timeScale = 0;
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    private void PhysMagic(string formula)
    {
        switch(formula[0])
        {
            case 'v':
                MatchCollection floats = Regex.Matches(Regex.Match(formula, @"v=\(-?\d+(\.?\d+)?,-?\d+(\.?\d+)?\)").Value,
                    @"-?\d+(\.?\d+)?");
                rb.AddForce(new Vector2(float.Parse(floats[0].Value), float.Parse(floats[1].Value)));
                break;
        }
    }

    public bool GetFormula(string text)
    {
        text = text.Replace(" ", String.Empty);
        if (Regex.IsMatch(text, @"v=\(-?\d+(\.?\d+)?,-?\d+(\.?\d+)?\)") ||
            Regex.IsMatch(text, @"v=\(-?\d+(\.?\d+)?,-?\d+(\.?\d+)?\)")) // Если регексы подходят (сюда будем добавлять новые)
        {
            Time.timeScale = 1;
            PhysMagic(text);
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
