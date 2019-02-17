using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Death")
        {
            Debug.Log("LOSS!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}
