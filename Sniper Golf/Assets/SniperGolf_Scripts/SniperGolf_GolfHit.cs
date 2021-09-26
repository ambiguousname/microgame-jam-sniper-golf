using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_GolfHit : MonoBehaviour
{
    public GameObject player;
    public GameObject club;
    public SniperGolf_PowerMinigameController powerMinigame;
    public float ballHitSpeed = 10;
    public bool canHit;
    Rigidbody2D ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        powerMinigame.hitSpace.AddListener(BallHit);
        ballRigidbody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        canHit = Vector3.Distance(player.transform.position, this.transform.position) < 2;
        if (Input.GetKeyDown("space") && canHit) {
            powerMinigame.gameObject.SetActive(true);
            player.GetComponent<SniperGolf_PlayerController>().inputEnabled = false;
        }
    }

    void BallHit(float strength) {
        ballRigidbody.AddForceAtPosition(strength * ballHitSpeed * (this.transform.position - club.transform.position).normalized, club.transform.position);
        player.GetComponent<SniperGolf_PlayerController>().inputEnabled = true;
    }
}
