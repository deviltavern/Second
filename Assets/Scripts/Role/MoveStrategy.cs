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
        initPosition = player.transform.position;

    }

    GameObject player;

    string command;

    StrategySponsor sponsor;
    int code;


    Vector3 dir;
    float distance;

    Vector3 initPosition;
    public override void doSomething()
    {

        // player.transform.position;
         Debug.Log(command);

        switch (code)
        {
            case 0:

                //初始化移动位置
                switch (command)
                {
                    case Command.moveLeft:
                        dir -= new Vector3(2, 0, 0);
                        break;

                    case Command.mvoeRight:
                        Debug.Log("123333333333333333");
                       dir -= new Vector3(-2, 0, 0);
                        break;

                    case Command.moveFront:

                       dir -= new Vector3(0, 0, -2);
                        break;

                    case Command.moveBack:

                       dir -= new Vector3(0, 0, 2);
                        break;

                    case Command.touch:

                        SkillReleaseManager.Instance.touch(player);
                        Debug.Log("执行touch事件！");
                        break;

                    default:

                        break;
                }

                code++;
                break;

            case 1:

                dir = Vector3.Normalize(dir);
                player.transform.position += dir * Time.deltaTime * 10;


                distance = Vector3.Distance(initPosition, player.transform.position);

                if (distance > 2)
                {
                    code++;
                }
                
                break;


            case 2:
                this.sponsor.strategy = null;
                break;
        }
       

        
       // LocalMoveManager.Instance.strategy = null;

    }
}