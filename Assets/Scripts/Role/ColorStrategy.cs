using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStrategy : Strategy {
  
    private GameObject player;
    private float fametime;
    public ColorStrategy( GameObject _player, float _fametime,StrategySponsor sper)
    {

        this.player = _player;
        this.fametime = _fametime;
        sper.strategy = this;
    }
    float frameTime = 0;
    public override void doSomething()
    {
        frameTime += Time.deltaTime;

        if (frameTime > fametime)
        {
            Debug.Log("结束这个策略");
        }
        else
        {
            player.GetComponent<MeshRenderer>().material.color -= new Color(0.01f, 0.01f, 0.01f);
        }
      

      
    }
}
