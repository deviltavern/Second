using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : BulletBase {


    public override void onTouchPlayer(Collider co)
    {

        Debug.Log("发生");
        Player player = co.gameObject.GetComponent<Player>();
        ColorStrategy strategy = new ColorStrategy(co.gameObject, 0.6f, player);

    }


}
