using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Crosshair : MonoBehaviour
{
    public GameObject player;
    public AudioSource aimSound;
    public AudioSource fireSound;
    public float sniperDistance = 2.0f;

    private Vector3 playerPos;
    private bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        isAiming = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAiming)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, 1f * Time.deltaTime);
            if (Vector2.Distance(player.transform.position, this.transform.position) < sniperDistance) {
                aimSound.Play();
            }
        }
    }

    void Shoot()
    {
        fireSound.Play();
        GameController.Instance.LoseGame();
    }
}
