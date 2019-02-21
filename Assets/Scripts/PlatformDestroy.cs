using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public AnimationClip destroyClip;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponentInChildren<Animator> ().Play ("Autodestroy");
            Destroy (gameObject, destroyClip.length);
        }
    }
}