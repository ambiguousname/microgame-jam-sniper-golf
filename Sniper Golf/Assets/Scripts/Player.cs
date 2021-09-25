using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Vector2 speed = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        speed.x = .005f;
        speed.y = .005f;
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = 0;
        float movementY = 0;
        if (Input.GetKey("up"))
        {
            movementY += 1;
        }
        if (Input.GetKey("down"))
        {
            movementY -= 1;
        }
        if (Input.GetKey("left"))
        {
            movementX -= 1;
        }
        if (Input.GetKey("right"))
        {
            movementX += 1;
        }
        Vector3 movement = new Vector3(speed.x * movementX, speed.y * movementY, 0);
        this.transform.Translate(movement);
        movement *= Time.deltaTime;
    }
}
