using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBullet : BulletBase {


    public override void OnTriggerEnter(Collider co)
    {

        Debug.Log("123");
        base.OnTriggerEnter(co);

       
    }



}
