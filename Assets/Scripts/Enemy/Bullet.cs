using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("SoundManager").GetComponent<Sounds>().PlaySound(1, 0.3f);
        StartCoroutine(Destr());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Destr()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
