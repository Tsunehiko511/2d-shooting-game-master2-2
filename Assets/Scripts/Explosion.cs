using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip BoomSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Destroy(gameObject, 0.5f);
        audioSource.PlayOneShot(BoomSE);

    }
}
