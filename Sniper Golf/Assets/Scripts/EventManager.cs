using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction OnShoot;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Debug.Log("Shooting");
            OnShoot();
            shootTimer = 4f;
        }
    }
}
