using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHItPlaySound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        GetComponent<AudioSource>().Play();
    }
}
