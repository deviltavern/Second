using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillReleaseManager : StrategySponsor
{


    public Ray ray;

    public RaycastHit hit;

    public GameObject rayOrigin;


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
                hitColliders[i].GetComponent<MeshRenderer>().material.color = Color.red;
                playerList.Add(hitColliders[i].gameObject);
            }
           
            i++;
        }
    }

	void Update () {



        if (Input.GetKeyDown(KeyCode.F))
        {


            ExplosionDamage(rayOrigin.transform.position, 3);

            string value = "";

            for (int i = 0; i < playerList.Count; i++)
            {
                value += i + "--";
            }

            CommandView.Instance.setCommand("探测结果:"+value);





        }



	}
}
