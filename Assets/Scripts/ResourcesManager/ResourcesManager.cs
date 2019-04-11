using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

    public static Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();
    public static Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();
    void Awake()
    {

        load(ResName.bagItem);
        load(ResName.lred);
     }



    public void load(string res_name)
    {
        GameObject g = Resources.Load<GameObject>(res_name);
        prefabDic.Add(res_name,g);
    
    }


    
}
