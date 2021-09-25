using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_ClubController : MonoBehaviour
{
    public Transform clubPosition;
    public SniperGolf_GolfHit golfController;
    Vector3 targetPos;
    Vector3 targRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (golfController.canHit)
        {
            targetPos = golfController.transform.position - (golfController.transform.position - golfController.player.transform.position).normalized;
            var targetRot = golfController.transform.position - this.transform.position;
            var angle = Mathf.Atan2(targetRot.y, targetRot.x) * Mathf.Rad2Deg;
            targRot = new Vector3(0, 0, angle);
        }
        else
        {
            targetPos = clubPosition.position;
            targRot = Vector3.zero;
        }
        var target = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 3);
        this.transform.position = new Vector3(target.x, target.y, this.transform.position.z);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(targRot), Time.deltaTime * 3);
    }
}
