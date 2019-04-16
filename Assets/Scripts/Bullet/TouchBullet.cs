using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBullet : BulletBase {


    public override void onTouchPlayer(Collider co)
    {
        ViewInfo info = new ViewInfo();
        info.arg1 = co.GetComponent<Player>().ID;
        info.aimG = co.gameObject;
        info.code = 1;
        broadCast(info);
        Destroy(this.gameObject);

    }



}
