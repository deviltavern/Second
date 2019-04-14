using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStrategy : Strategy
{

    public MoveStrategy(GameObject aimG, string _command,StrategySponsor _sponsor)
    {
        this.player = aimG;
        this.command = _command;
        this.sponsor = _sponsor;

    }

    GameObject player;

    string command;

    StrategySponsor sponsor;
    int code;




    public override void doSomething()
    {

        // player.transform.position;
        // Debug.Log(command);
        switch (command)
        {
            case Command.moveLeft:

                player.transform.position -= new Vector3(2, 0, 0);
                break;
                
            case Command.mvoeRight:

                player.transform.position -= new Vector3(-2, 0, 0);
                break;
                
            case Command.moveFront:

                player.transform.position -= new Vector3(0, 0, -2);
                break;
                
            case Command.moveBack:

                player.transform.position -= new Vector3(0, 0, 2);
                break;

            default:

                break;
        }
     
        this.sponsor.strategy = null;


    }
}