using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuidePanel : MonoBehaviour
{
    GameObject phys;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text pageNum;
    private string[] texts;
    [SerializeField] private GameObject prev;
    [SerializeField] private GameObject next;
    int pageIndex = 1;

    void Start()
    {
        transform.localScale = Vector3.zero;
        phys = GameObject.FindGameObjectWithTag("PhysPanel");
        texts = new string[] { "g=9.8 - ��������� ���������� �������.\n\nP=mg - ��� ����. ��� ������ �����, ��� ������ ��� ����.\n\nF - ����. ��������� ��������, ������� ����� ��������� � �������.",
        "A=FS - ������, ��������� �������������� ���� �������� ����. ������� �� ����, ����������� � ����, � ����������� ��� ��������� ���� ���� ����.\n\n��� (n, ���)=(Q1-Q2)/Q1 - ����������� ��������� �������� � ������ ������ ��������� ���������. ����� ��������������� �������� ������ � �������� ��������������� �����������.",
        "Ek=mv^2/2 - ������������ �������, �������, ������������� ��������� ���.\n\nEp=mgh - ������������� �������, ������� �������������� ������ ������� � ������.\n\nE=Ek+Ep - ������ ������������ �������. �����������, ���� ��� ���� ������.",
        "Fa=grV - ���������� ����, ������������� ����, ����������� �� ����, ���������� � �������� ��� ���. ������� �� ��������� �������� ��� ���� � �� ������ ����������� ����.\n\nI=q/t - ���� ����, ��������� �������������� ������, ���������� ����� ���������� ������� ����������, �� ������� ��� �����������."};
        pageIndex = 0;
        prev.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObject.transform.localScale.magnitude != 0)
                gameObject.transform.localScale = Vector3.zero;
            else if (phys.transform.localScale.magnitude == 0)
                SceneManager.LoadScene("MainMenu");
        }
    }

        public void OpenGuide()
    {
        if (gameObject.transform.localScale.magnitude != 0)
            gameObject.transform.localScale = Vector3.zero;

        else if (phys.transform.localScale.magnitude == 0 && gameObject.transform.localScale.magnitude == 0)
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
