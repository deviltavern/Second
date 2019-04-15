using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillReleaseManager : StrategySponsor,IViewer
{
    public static SkillReleaseManager Instance;


    private void Awake()
    {
        Instance = this;
        touchSphere = GameObject.Find("touchSphere");//找到碰撞球
        touchSphere.SetActive(false);
    //   offset = 3.1f;
       
    }

    bool touchEvent = false;

    Vector3 touchPointVec;
 //   public float offset;
    public void touch(GameObject touchPoint)
    {

        touchEvent = true;
        touchSphere.gameObject.SetActive(true);
        touchSphere.transform.position = touchPoint.transform.position;
        touchSphere.transform.localScale = new Vector3(1, 1, 1);

        touchPointVec = touchPoint.transform.position;

        
        foreach (GameObject g in playerList)
        {
            //材质球的组件MeshRenderer，变为白色
            g.GetComponent<MeshRenderer>().material.color = Color.white;

        }
        playerList.Clear();
           //   *Collider碰撞器，ExplosionDamage将碰撞到的tag=Player加入List
        ExplosionDamage(touchPointVec, 10);

        foreach (GameObject g in playerList)
        {

            shootTouchBullet(LocalPlayer.player.gameObject, g);


        }


    }
   
    public static void shootTouchBullet(GameObject player,GameObject aimG)
    {


        TouchBullet g = TouchBullet.insBulletItem<TouchBullet>(ResName.ef1);

        g.transform.position = player.transform.position;
        Vector3 dir2 = Vector3.Normalize(aimG.transform.position - g.transform.position);     //a到b的距离  b-a

        g.strategy = new BulletStraitMoveStrategy(dir2, g.gameObject, 10);




    }
    public Ray ray; //声明一条射线

    public RaycastHit hit;

    public GameObject rayOrigin;

    public GameObject touchSphere;
    public  List<GameObject> playerList = new List<GameObject>();

    public static Dictionary<string, GameObject> spPlayer = new Dictionary<string, GameObject>();
   



    void ExplosionDamage(Vector3 center, float radius)
    {
        //   *Collider碰撞器，ExplosionDamage将碰撞到的tag=Player加入List

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;

       //碰撞到的 hitColliders[i].gameObject.name也可以通过已下输出。  
      // Physics.OverlapSphere(transform.position, 10000, LayerMask.GetMask("xxx")) 
      //这个方法第三个参数： 是表示在xxx层中查找

        while (i < hitColliders.Length)
        {
            //被扫到的碰撞体的行为，例如：

            if (hitColliders[i].gameObject.tag == "Player")
            {           
                playerList.Add(hitColliders[i].gameObject);
            }
           
            i++;
        }
    }

	void Update () {

    //    if (touchEvent == true)
    //    {
    //
    //        float distance = Vector3.Distance(touchSphere.transform.localScale, new Vector3()) / offset;
    //        ExplosionDamage(touchPointVec, distance); ;
    //        touchSphere.transform.localScale += new Vector3(1, 0, 1) * Time.deltaTime*10;
    //        if (distance > 4)
    //        {
    //            foreach (GameObject g in playerList)
    //            {
    //                shootTouchBullet(LocalPlayer.player.gameObject, g);
    //
    //
    //            }
    //
    //            touchEvent = false;
    //            touchSphere.gameObject.SetActive(false);
    //            touchSphere.transform.localScale = new Vector3(1, 1, 1);
    //        }
    //    }
    //



	}
    private List<GameObject> aList = new List<GameObject>();

    public void setLabel (string id,Player _player){
        
        GameObject cavas = GameObject.Find("Canvas");
        GameObject g = GameObject.Instantiate<GameObject>(ResourcesManager.prefabDic[ResName.lables],cavas.transform);
        Text t = g.GetComponent<Text>();
        t.text = id;
        t.transform.gameObject.AddComponent<Fllow>();
        Fllow f=t.GetComponent<Fllow>();
        f.setTp(t,_player);
    }



    public static void shootFireball(GameObject player, GameObject aimG)
    {


        FireBall g = FireBall.insBulletItem<FireBall>(ResName.ef1);

        g.transform.position = player.transform.position;
        Vector3 dir2 = Vector3.Normalize(aimG.transform.position - g.transform.position);     //a到b的距离  b-a

        g.strategy = new BulletStraitMoveStrategy(dir2, g.gameObject, 10);




    }
    

    public void fireBall(string playerID ) {
        GameObject g = spPlayer[playerID];
       
            
            g.GetComponent<MeshRenderer>().material.color = Color.red;
            
            shootFireball(LocalPlayer.player.gameObject, g);

        

        }

    public void save2Dic(string key, GameObject g)
    {
        
        if (spPlayer.ContainsKey(key) == false)
        {
            spPlayer.Add(key, g);

        }
    }


    public void updateViewInfo(ViewInfo info)
    {
        switch (info.code)
        {
            case 1:
                Debug.Log(info.arg1);

                setLabel(info.arg1, info.aimG.transform.GetComponent<Player>());
                GameObject g =  GameObject.Instantiate(ResourcesManager.prefabDic[ResName.ef2],info.aimG.transform);
                g.transform.localPosition = new Vector3();
                save2Dic(info.arg1, info.aimG);
                break;
        }

        
    }
}
