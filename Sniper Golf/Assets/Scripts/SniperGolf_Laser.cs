using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Laser : MonoBehaviour
{
    [SerializeField] private Transform crosshair;
    private bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair").transform;
        EventManager.OnShoot += Shoot;
        isCharging = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotateDirection = crosshair.position - this.transform.position;
        float angle = Mathf.Atan2(rotateDirection.x, rotateDirection.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    void Shoot()
    {
        //make it transparent
        this.GetComponent<Material>().color = new Color(0, 0, 0, 0);
    }
}
