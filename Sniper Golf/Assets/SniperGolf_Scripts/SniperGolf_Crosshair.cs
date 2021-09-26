using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Crosshair : MonoBehaviour
{
    public GameObject player;
    public AudioSource aimSound;
    public AudioSource fireSound;
    public AudioSource loseSound;
    public SniperGolf_Shake cameraShake;
    public float sniperDistance = 0.5f;
    Vector3 startScale;
    bool zoomIn = false;

    private Vector3 playerPos;
    private bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        isAiming = true;
        startScale = this.transform.localScale;
    }

    IEnumerator Aim() {
        zoomIn = true;
        isAiming = false;
        aimSound.Play();
        while (aimSound.isPlaying)
        {
            yield return null;
        }
        zoomIn = false;
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAiming)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, 1f * Time.deltaTime);
            if (Vector2.Distance(player.transform.position, this.transform.position) < sniperDistance) {
                StartCoroutine(Aim());
            }
        }
        if (zoomIn)
        {
            this.transform.localScale -= Vector3.one * Time.deltaTime * 0.1f;
        }
        else {
            if (this.transform.localScale.magnitude < startScale.magnitude)
            {
                this.transform.localScale += Vector3.one * Time.deltaTime;
            }
        }
    }

    void Shoot()
    {
        fireSound.Play();
        cameraShake.ShakeCamera(0.05f, 0.001f);
        if (Vector2.Distance(player.transform.position, this.transform.position) < sniperDistance)
        {
            loseSound.Play();
            GameController.Instance.LoseGame();
        }
        else {
            isAiming = true;
        }
    }
}
