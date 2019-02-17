using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject tele1, tele2, Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tele")
        {
            //if (Player.transform.position == tele1.transform.position)
            // {
            //     Debug.Log("TELE holo frandzz");
            //    Player.transform.position = new Vector2(tele2.transform.position.x, tele2.transform.position.y);
            // }

            //if(Player.transform.position == tele2.transform.position)
            {
                Debug.Log("TELE1 holo frandzz");

                Player.transform.position = new Vector2(tele1.transform.position.x, tele1.transform.position.y);
            }
        }
    }

}
