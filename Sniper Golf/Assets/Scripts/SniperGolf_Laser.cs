using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_Laser : MonoBehaviour
{
    [SerializeField] private Transform crosshair;
    [SerializeField] private Transform pivotPoint;
    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair").transform;
        pivotPoint = GameObject.Find("Pivot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotateDirection = crosshair.position - this.transform.position;
        Quaternion dir = Quaternion.LookRotation(rotateDirection);
        this.transform.RotateAround(pivotPoint.localPosition, Vector3.forward, Quaternion.Angle(this.transform.rotation, dir));
    }
}
