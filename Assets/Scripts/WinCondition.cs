using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject Follow;

    private void Update ()
    {
        if (Follow)
        {
            this.transform.position = Follow.transform.position;
        }
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Win" && other.gameObject.name != gameObject.name)
        {
            Debug.Log (other.gameObject.name + gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }
}