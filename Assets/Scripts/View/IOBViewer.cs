using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOBViewer {
    //IOBViewer添加观察者，删除，广播
    void addViewer(IViewer viewer);
    void deleteViewer(IViewer viewer);

    void broadCast(ViewInfo info);
}
