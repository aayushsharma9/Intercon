using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AnimationClip collectClip;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Animator> ().Play ("Collect");
            Destroy (gameObject, collectClip.length);
        }
    }
}