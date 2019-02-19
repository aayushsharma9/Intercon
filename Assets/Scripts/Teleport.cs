using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject connectingTele;
    private bool isTeleporting;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isTeleporting)
            {
                connectingTele.GetComponent<Teleport>().setTeleporting();
                Vector2 connectingTelePosition = new Vector2 (connectingTele.transform.position.x, connectingTele.transform.position.y);
                other.transform.position = connectingTelePosition;
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTeleporting = false;
        }
    }

    public void setTeleporting ()
    {
        isTeleporting = true;
    }
}