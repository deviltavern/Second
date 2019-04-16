using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour,IOBViewer {

    public Strategy strategy { get; set; }//构造函数设置具体策略
    private List<IViewer> viewList = new List<IViewer>();//观察者列表
    public string resID { get; set; }

    public virtual void Awake()
    {
        addViewer(SkillReleaseManager.Instance);
    }
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
    
    public virtual void Update()            //调用策略
    {

        if (strategy != null)
        {
            strategy.doSomething();
        }

    }


    public abstract void onTouchPlayer(Collider co);
    public virtual void OnTriggerEnter(Collider co)  //检测到碰撞
    {

        switch (co.tag)
        {
            case "Player":
              
                onTouchPlayer(co);

                break;

            default:

                break;
        }

            
    }
}
