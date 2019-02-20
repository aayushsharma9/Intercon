using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public int destroySec;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Wait for it!");
            StartCoroutine(destroy(destroySec));
        }
    }
    IEnumerator destroy(int destroySec)
    {
        yield return new WaitForSeconds(destroySec);
        Destroy(gameObject);
        Debug.Log("Ayy Boom!!");
    }

}
