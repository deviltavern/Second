using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BagAction : MonoBehaviour {

    Bag bag;
    public static BagAction Instance;

    void Awake()
    {
        Instance = this;
    }
	void Start () {
        bag = Bag.Instance;
	}


    /// <summary>
    /// 添加策略
    /// </summary>

    public void addAlgorithom(ItemBase item,string id)
    {

        foreach (GameObject _item in bag.bagItemDic.Values)
        {
            BagItem bagItem = _item.GetComponent<BagItem>();
            Debug.Log(bagItem.itemID);

            if (bagItem.itemID == id)
            {
                bagItem.plusNum();


                return;
            }

            if (bagItem.itemID == null)
            {
                bagItem.addItem(item);
                bagItem.itemID = id;
                Debug.Log("生成资源");
                break;
            }
        
        }


    
    }
}
