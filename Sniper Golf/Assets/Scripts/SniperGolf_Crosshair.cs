using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Crosshair : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, 3f * Time.deltaTime);
    }
}
