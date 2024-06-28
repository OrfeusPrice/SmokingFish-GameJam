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
    private TMP_InputField input;

    void Start()
    {
        input = GetComponent<TMP_InputField>();
    }

    public void EndEntering()
    {
        if (obj.GetFormula(input.text))
        {
            input.text = "";
            obj = null;
            parent.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void SetInteractiveObject(InteractiveObject interactiveObject) => obj = interactiveObject;
}
