using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhysPanel : MonoBehaviour
{
    private GameObject guide;
    [SerializeField] private InteractiveObject obj;
    [SerializeField] private GameObject parent;
    [SerializeField] private string[] formulas;
    private Dictionary<string, string> dictFormsulas;
    public GameObject camera;
    private TMP_InputField input;
    private string formula;
    private EnemyKnob enemyKnob;

    void Start()
    {
        guide = GameObject.FindGameObjectWithTag("GuidPanel");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
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
        else if (Input.GetKeyDown(KeyCode.E))
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
            else if (parent.transform.localScale.magnitude > 0)
                StartCoroutine(Error());
        }
        else
        {
            string text = input.text.Replace(" ", string.Empty);
            if (dictFormsulas.Keys.Contains(text.Split('=')[0]))
            {
                if (dictFormsulas[text.Split('=')[0]] == text.Split('=')[1])
                {
                    enemyKnob.SetFormula(text);
                    parent.transform.localScale = new Vector3(0, 0, 0);
                    input.text = "";
                }
                else if (parent.transform.localScale.magnitude > 0)
                {
                    StartCoroutine(Error());
                }
            }
            else if (parent.transform.localScale.magnitude > 0)
            {
                StartCoroutine(Error());
            }
        }
    }

    private IEnumerator Error()
    {
        Vector3 vec = camera.transform.localPosition;
        float x;
        float y;
        float timeLeft = 0.3f;

        while ((timeLeft) > 0)
        {
            x = Random.Range(-0.3f, 0.3f);
            y = Random.Range(-0.3f, 0.3f);

            camera.transform.position = new Vector3(vec.x + x, vec.y + y, vec.z);
            yield return new WaitForSecondsRealtime(0.025f);
            timeLeft -= 0.025f;
        }

        camera.transform.position = vec;
    }

    public void OpenPanel()
    {
        if (guide.transform.localScale.magnitude == 0)
        {
            input.text = "";
            parent.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        parent.transform.localScale = new Vector3(0, 0, 0);
    }

    public void SetInteractiveObject(InteractiveObject interactiveObject) => obj = interactiveObject;
}
