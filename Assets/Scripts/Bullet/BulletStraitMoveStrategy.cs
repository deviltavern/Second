using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStraitMoveStrategy : Strategy
{
    //子弹移动策略
    private Vector3 dir;
    private GameObject bullet;
    private float speed;
    public BulletStraitMoveStrategy(Vector3 _dir,GameObject _bullet,float _sped)
    {
        this.dir = _dir;
        this.bullet = _bullet;
        this.speed = _sped;
    }
    public override void doSomething()//具体决策的运算法则doSomething()
    {

        bullet.transform.position += dir * Time.deltaTime * speed ;
     
    }
}
