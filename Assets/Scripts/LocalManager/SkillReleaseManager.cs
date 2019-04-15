using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillReleaseManager : StrategySponsor,IViewer
{
    public static SkillReleaseManager Instance;


    private void Awake()
    {
        Instance = this;
        touchSphere = GameObject.Find("touchSphere");
        touchSphere.SetActive(false);
        offset = 3.1f;
    }

    bool touchEvent = false;

    Vector3 touchPointVec;
    public float offset;
    public void touch(GameObject touchPoint)
    {

        touchEvent = true;
        touchSphere.gameObject.SetActive(true);
        touchSphere.transform.position = touchPoint.transform.position;
        touchSphere.transform.localScale = new Vector3(1, 1, 1);

        touchPointVec = touchPoint.transform.position;

        
        foreach (GameObject g in playerList)
        {
            g.GetComponent<MeshRenderer>().material.color = Color.white;

        }
        playerList.Clear();

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
        Vector3 dir2 = Vector3.Normalize(aimG.transform.position - g.transform.position);

        g.strategy = new BulletStraitMoveStrategy(dir2, g.gameObject, 10);




    }
    public Ray ray;

    public RaycastHit hit;

    public GameObject rayOrigin;

    public GameObject touchSphere;
    public List<GameObject> playerList = new List<GameObject>();
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;

        
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

    public void updateViewInfo(ViewInfo info)
    {
        switch (info.code)
        {
            case 1:
                Debug.Log(info.arg1);

                GameObject g =  GameObject.Instantiate(ResourcesManager.prefabDic[ResName.ef2],info.aimG.transform);
                g.transform.localPosition = new Vector3();
                break;
        }
    }
}
