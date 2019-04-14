using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour,IOBViewer {

    public Strategy strategy { get; set; }
    private List<IViewer> viewList = new List<IViewer>();
    public string resID { get; set; }
    public void addViewer(IViewer viewer)
    {
        viewList.Add(viewer);
            
    }

    public void broadCast(ViewInfo info)
    {
        foreach (IViewer view in viewList)
        {
            view.updateViewInfo(info);
        }
    }

    public void deleteViewer(IViewer viewer)
    {
        viewList.Remove(viewer);
    }

    public static T insBulletItem<T>(string resid) where T:MonoBehaviour
    {

        GameObject _bullet = GameObject.Instantiate(ResourcesManager.prefabDic[resid]);
        T bulletComponent = (T)_bullet.AddComponent<T>();

        return bulletComponent;



    }
    
    public virtual void Update()
    {

        if (strategy != null)
        {
            strategy.doSomething();
        }

    }

    public virtual void OnTriggerEnter(Collider co)
    {

        switch (co.tag)
        {
            case "Player":

                Destroy(co.gameObject);


                break;

            default:

                break;
        }

            
    }
}
