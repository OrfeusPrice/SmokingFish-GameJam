using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuidePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text pageNum;
    [SerializeField] private string[] texts;
    [SerializeField] private GameObject prev;
    [SerializeField] private GameObject next;
    int pageIndex = 1;

    void Start()
    {
        pageIndex = 0;
        prev.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.transform.localScale = Vector3.zero;
    }

    public void OpenGuide()
    {
        if (gameObject.transform.localScale.magnitude == 0)
        {
            next.SetActive(true);
            prev.SetActive(false);
            pageIndex = 0;
            pageNum.text = (pageIndex + 1).ToString();
            text.text = texts[pageIndex].ToString();
            gameObject.transform.localScale = Vector3.one;
        }
    }

    public void NextPage()
    {
        if (pageIndex < texts.Length - 1)
        {
            pageIndex++;
            pageNum.text = (pageIndex + 1).ToString();
            text.text = texts[pageIndex].ToString();
            prev.SetActive(true);
            if (pageIndex == texts.Length - 1)
                next.SetActive(false);
        }
    }

    public void PrevPage()
    {
        if (pageIndex > 0)
        {
            pageIndex--;
            pageNum.text = (pageIndex + 1).ToString();
            text.text = texts[pageIndex].ToString();
            next.SetActive(true);
            if (pageIndex == 0)
                prev.SetActive(false);
        }
    }
}
