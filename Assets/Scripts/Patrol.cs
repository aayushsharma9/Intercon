using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] checkPoints;
    public float speed;
    private int destination;
    bool collided = false;

    private void Start ()
    {
        destination = 0;
        gameObject.transform.position = checkPoints[destination].transform.position;
        destination++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collided = false;
        }
    }
    private void Update ()
    {
        Vector2 selfPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 des = new Vector2(checkPoints[destination].transform.position.x, checkPoints[destination].transform.position.y);

        if (Mathf.Abs(Vector2.Distance(selfPos, des)) < 1)
        {
            destination = (destination + 1) % checkPoints.Length;
        }

        Vector2 moveDir = des - selfPos;
        moveDir.Normalize();
        gameObject.transform.Translate(moveDir * speed * Time.deltaTime);

        if(collided)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Translate(moveDir * speed * Time.deltaTime);
        }
        
    }
}