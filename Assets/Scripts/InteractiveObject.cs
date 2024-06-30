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
    private bool mouseOnColl;
    [SerializeField] private GameObject panel;
    private PhysPanel physPanel;
    private float time = 30f;
    [SerializeField] private string formula;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseOnColl = false;
        panel = GameObject.FindGameObjectWithTag("PhysPanel");
        physPanel = panel.GetComponentInChildren<PhysPanel>();
    }

    void Update()
    {
        RMBPressed();
    }

    private void RMBPressed()
    {
        if (panel.transform.localScale.magnitude == 0 && mouseOnColl && Input.GetMouseButtonDown(1))
        {
            physPanel.OpenPanel();
            StopCoroutine(WaitingFormula());
            StartCoroutine(WaitingFormula());
        }
    }

    private IEnumerator WaitingFormula()
    {
        physPanel.SetInteractiveObject(this);
        Time.timeScale = 0;
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
        physPanel.ClosePanel();
    }

    private void PhysMagic(string formula)
    {
        switch(formula.ToLower())
        {
            case "static":
                rb.bodyType = RigidbodyType2D.Static;
                break;
            case "kinematic":
                rb.bodyType = RigidbodyType2D.Kinematic;
                break;
            case "dynamic":
                rb.bodyType = RigidbodyType2D.Dynamic;
                break;
        }

        switch(formula[0])
        {
            case 'F':
                MatchCollection floats = Regex.Matches(Regex.Match(formula, @"F=\(-?\d+(,?\d+)?;-?\d+(,?\d+)?\)").Value,
                    @"-?\d+(,?\d+)?");
                rb.AddForce(new Vector2(float.Parse(floats[0].Value), float.Parse(floats[1].Value)));
                break;
            case 'm':
                rb.mass = float.Parse(Regex.Match(Regex.Match(formula, @"m=\d+(,?\d+)?").Value, @"\d+(,?\d+)?").Value);
                break;
            case 'g':
                rb.gravityScale =float.Parse(Regex.Match(Regex.Match(formula, @"g=-?\d+(,?\d+)?").Value, @"-?\d+(,?\d+)?").Value);
                break;
        }

        gameObject.tag = "PhObj";
    }

    public bool GetFormula(string text)
    {
        text = text.Replace(" ", String.Empty);
        text = text.Replace('.', ',');
        if (Regex.IsMatch(text, @"F=\(-?\d+(,?\d+)?;-?\d+(,?\d+)?\)") ||
            Regex.IsMatch(text, @"m=\d+(,?\d+)?") ||
            Regex.IsMatch(text, @"g=-?\d+(,?\d+)?") ||
            text.ToLower().Equals("static") && rb.bodyType != RigidbodyType2D.Static ||
            text.ToLower().Equals("kinematic") && rb.bodyType != RigidbodyType2D.Kinematic ||
            text.ToLower().Equals("dynamic") && rb.bodyType != RigidbodyType2D.Dynamic)
        { // ≈сли регексы подход€т (сюда будем добавл€ть новые физические заклинани€)
            Time.timeScale = 1;
            PhysMagic(text);
            return true;
        }
        return false;
    }

    private void ActFormula()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!formula.Equals(string.Empty))
        {
            if (collision.gameObject.tag == "Magic" && collision.gameObject.GetComponent<Particle>().GetFormula().Equals(formula))
                ActFormula();
        }
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
