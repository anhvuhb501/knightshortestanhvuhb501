using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playmusic : MonoBehaviour
{
    private AudioSource nhac;
    // Start is called before the first frame update
    void Start()
    {
        nhac = GetComponent<AudioSource>();
        nhac.Play();
    }
}
