using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhysPanel : MonoBehaviour
{
    [SerializeField] private InteractiveObject obj;
    [SerializeField] private GameObject parent;
    [SerializeField] private string[] formulas;
    private Dictionary<string, string> dictFormsulas;
    private TMP_InputField input;
    private string formula;
    private EnemyKnob enemyKnob;

    void Start()
    {
        dictFormsulas = new Dictionary<string, string>();
        input = GetComponent<TMP_InputField>();
        enemyKnob = GameObject.FindGameObjectWithTag("EnemyKnob").GetComponent<EnemyKnob>();
        foreach (string str in formulas)
            dictFormsulas.Add(str.Split('=')[0], str.Split('=')[1]);
    }

    private void Update()
    {
        if (parent.transform.localScale.magnitude == 0 && Input.GetKeyDown(KeyCode.E))
            OpenPanel();
        else if (Time.timeScale != 0 && Input.GetKeyDown(KeyCode.E))
            ClosePanel();
    }

    public void EndEntering()
    {
        if (Time.timeScale == 0)
        {
            if (obj.GetFormula(input.text))
            {
                obj = null;
                parent.transform.localScale = new Vector3(0, 0, 0);
                input.text = "";
            }
        }
        else
        {
            string text = input.text.Replace(" ", string.Empty);
            if (dictFormsulas[text.Split('=')[0]] == text.Split('=')[1])
            {
                enemyKnob.SetFormula(text);
                parent.transform.localScale = new Vector3(0, 0, 0);
                input.text = "";
            }
        }
    }

    private void OpenPanel()
    {
        parent.transform.localScale = new Vector3(1, 1, 1);
    }

    private void ClosePanel()
    {
        parent.transform.localScale = new Vector3(0, 0, 0);
    }

    public void SetInteractiveObject(InteractiveObject interactiveObject) => obj = interactiveObject;
}
