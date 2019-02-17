using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject tele1, tele2, Player;

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.tag == "Tele")
        {     
            StartCoroutine(TeleportWait());
        }
    }

    IEnumerator TeleportWait()
    {
        yield return new WaitForSeconds(0.8f);
        
        Vector2 teleD1 = new Vector2(tele1.transform.position.x, tele1.transform.position.y);
        Vector2 teleD2 = new Vector2(tele2.transform.position.x, tele2.transform.position.y);
        Vector2 PlayerD = new Vector2(Player.transform.position.x, Player.transform.position.y);

        if(Vector2.Distance(teleD1,PlayerD) <= 0.9)          
            {
                Debug.Log("TELE1 holo frandzz");
                Player.transform.position = new Vector2(tele2.transform.position.x, tele2.transform.position.y);
            }  
              
            else
            {
                if(Vector2.Distance(teleD2,PlayerD) <= 0.9)
                {   
                    Debug.Log("TELE2 holo frandzz");
                    Player.transform.position = new Vector2(tele1.transform.position.x, tele1.transform.position.y);
                }
            }
    }
}
