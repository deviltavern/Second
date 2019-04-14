using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMoveManager : StrategySponsor
{
    public static LocalMoveManager Instance;

    private void Awake()
    {
        Instance = this;
    }
 

    private void Update()
    {

        if (strategy != null)
        {
            strategy.doSomething();
        }





    }


}
