using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject[] collectables;
    public int conTotal = 0;
    public int nexTotal = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CollectCon")
        {
            collision.gameObject.SetActive(false);
            conTotal++;
            Debug.Log("Con:" + conTotal);
        }

        if (collision.gameObject.tag == "CollectNex")
        {
            collision.gameObject.SetActive(false);
            nexTotal++;
            Debug.Log("Nex:" + nexTotal);
        }
    }
}
