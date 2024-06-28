using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhysPanel : MonoBehaviour
{
    [SerializeField] private InteractiveObject obj;
    private TMP_InputField input;
    [SerializeField] GameObject parent;

    void Start()
    {
        input = GetComponent<TMP_InputField>();
    }

    public void EndEntering()
    {
        if (obj.GetFormula(input.text))
        {
            obj = null;
            parent.SetActive(false);
        }
    }

    public void SetInteractiveObject(InteractiveObject interactiveObject) => obj = interactiveObject;
}
