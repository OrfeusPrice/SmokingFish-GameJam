using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private GameObject canvas;
    [SerializeField] private GameObject magic;
    private (int, int) zrange;
    private (int, int) yrange;
    private (int, int) xrange;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        zrange = (-10, 10);
        yrange = (200, 400);
        xrange = (-20, 20);
        StartCoroutine(MagicFly());
    }

    private IEnumerator MagicFly()
    {
        while (true)
        {
            StartCoroutine(MagicFlyLeft());
            StartCoroutine(MagicFlyRight());
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator MagicFlyLeft()
    {
        System.Random r = new System.Random();
        float time = 10;

        GameObject obj = Instantiate(magic, new Vector3(r.Next(100, 300), 1100, 0), Quaternion.identity);
        obj.transform.SetParent(canvas.transform);

        while (time > 0)
        {
            obj.transform.position = obj.transform.position + new Vector3(r.Next(xrange.Item1, xrange.Item2) * Time.deltaTime,
                                                                            -r.Next(yrange.Item1, yrange.Item2) * Time.deltaTime,
                                                                            r.Next(zrange.Item1, zrange.Item2) * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }

        GameObject.Destroy(obj.gameObject);
    }

    private IEnumerator MagicFlyRight()
    {
        System.Random r = new System.Random();
        float time = 10;

        GameObject obj = Instantiate(magic, new Vector3(r.Next(1600, 1800), 1100, 0), Quaternion.identity);
        obj.transform.SetParent(canvas.transform);

        while (time > 0)
        {
            obj.transform.position = obj.transform.position + new Vector3(r.Next(xrange.Item1, xrange.Item2) * Time.deltaTime,
                                                                            -r.Next(yrange.Item1, yrange.Item2) * Time.deltaTime,
                                                                            r.Next(zrange.Item1, zrange.Item2) * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }

        GameObject.Destroy(obj.gameObject);
    }
}
