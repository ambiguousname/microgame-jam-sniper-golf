using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Crosshair : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private bool isAiming;
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private Collider2D hurtbox;
    [SerializeField] private AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        EventManager.OnShoot += Shoot;
        isAiming = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAiming)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, 1f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        shoot.Play();
        //pause movement for a bit
        //check if intersecting with player
        if (hitbox.bounds.Intersects(hurtbox.bounds))
        {
            //die if true
            //also I'll add a sound effect
            Debug.Log("Bounds intersecting");
        }
    }
}
