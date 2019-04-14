using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestX : StrategySponsor
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {

           // LocalMoveManager.Instance.strategy = new MoveStrategy(LocalPlayer.player.gameObject, Command.moveLeft, LocalMoveManager.Instance);


        }
    }
}
