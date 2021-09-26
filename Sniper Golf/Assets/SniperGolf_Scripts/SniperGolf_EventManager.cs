using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_EventManager : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction OnShoot;
    [SerializeField] private float shootTimer;
    [SerializeField] private float aimTimer;
    [SerializeField] public AudioSource aim;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = 4f;
        aimTimer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        aimTimer -= Time.deltaTime;
        if (aimTimer <= 0)
        {
            aim.Play();
        }
        if (shootTimer <= 0)
        {
            Debug.Log("Shooting");
            OnShoot();
            shootTimer = 4f;
            aimTimer = 2f;
        }
    }
}
