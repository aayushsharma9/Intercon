using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public AnimationClip destroyClip;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInChildren<Animator> ().Play ("Autodestroy");
            gameObject.GetComponentInChildren<BoxCollider2D> ().enabled = false;
            Destroy (gameObject, destroyClip.length);
        }
    }
}