using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private GameObject canvas;
    [SerializeField] string[] formulas;
    [SerializeField] TMP_Text text;
    private (int, int) xrange = (-100, 1800); // (-500, 500);
    private (int, int) yrange = (0, 500); // (-300, -100);
    private float maxTime = 4f;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Formula()
    {
        System.Random r = new System.Random();
        int f = r.Next(6);
        StartCoroutine(FormulaFly(f));

        Debug.Log("Formula:) " + formulas[f]);
    }

    private IEnumerator FormulaFly(int f)
    {
        System.Random r = new System.Random();
        float time = maxTime;
        text.text = formulas[f];

        TMP_Text obj = Instantiate(text, new Vector3(r.Next(xrange.Item1, xrange.Item2), r.Next(yrange.Item1, yrange.Item2), 0),
            Quaternion.Euler(new Vector3(0, 0, r.Next(-30, 30))));
        obj.transform.SetParent(canvas.transform);

        while (time > 0)
        {
            obj.transform.position = obj.transform.position + new Vector3(0, Time.deltaTime * 200f, 0);
            obj.color = new Color(obj.color.r, obj.color.g, obj.color.b , obj.color.a - Time.deltaTime * 0.4f);
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }
        GameObject.Destroy(obj.gameObject);
    }
}
