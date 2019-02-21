using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] checkPoints;
    public float speed;
    private int destination;

    private void Start ()
    {
        destination = 0;
        gameObject.transform.position = checkPoints[destination].transform.position;
        destination++;
    }

    private void Update ()
    {
        Vector3.Lerp (gameObject.transform.position, checkPoints[destination].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance (gameObject.transform.position, checkPoints[destination].transform.position) < 0.01f)
        {
            destination = (destination + 1) % checkPoints.Length;
        }
    }
}