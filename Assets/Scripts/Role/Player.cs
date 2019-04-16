using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Role {
   
    void Awake()
    {
        Role.Player = this;
        moveSpeed = 10;

        this.ID = Random.Range(0, 1000)+"";
    }

    void Update()
    {
        if (strategy != null)
        {
            strategy.doSomething();
        }
    }
}
