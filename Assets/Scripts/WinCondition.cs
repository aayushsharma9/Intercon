using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Follow;
    private GameManager gm;

    private void Start ()
    {
        gm = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
    }

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
            gm.LevelComplete ();
        }
    }
}