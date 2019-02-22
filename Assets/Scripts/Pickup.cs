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
            gameObject.GetComponentInChildren<Animator> ().Play ("Collect");
            FindObjectOfType<AudioManager> ().Play ("Collect");
            gameObject.GetComponent<BoxCollider2D> ().enabled = false;  
            Destroy (gameObject, collectClip.length);
        }
    }
}