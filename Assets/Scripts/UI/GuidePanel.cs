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
        texts = new string[] { "g=9.8 - ускорение свободного падения.\n\nP=mg - вес тела. Чем больше масса, тем больше вес тела.\n\nF - сила. Векторная величина, которую можно применить к объекту.",
        "A=FS - работа, скалярная количественная мера действия силы. Зависит от силы, применяемой к телу, и пройденного под действием этой силы пути.\n\nКПД (n, эта)=(Q1-Q2)/Q1 - коэффициент полезного действия в данном случае теплового двигателя. Прямо пропорциональна полезной работе и обратноо пропорциональна затраченной.",
        "Ek=mv^2/2 - кинетическая энергия, энергия, обусловленная движением тел.\n\nEp=mgh - потенциальная энергия, энергия взаимодействия одного объекта с другим.\n\nE=Ek+Ep - полная механическая энергия. Сохраняется, если нет силы трения.",
        "Fa=grV - Архимедова сила, выталкивающая сила, действующая на тело, погружённое в жидкость или газ. Зависит от плотности жидкости или газа и от объема погружённого тела.\n\nI=q/t - сила тока, отношение электрического заряда, прошедшего через поперечное сечение проводника, ко времени его прохождения."};
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
