using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOBViewer {

    void addViewer(IViewer viewer);
    void deleteViewer(IViewer viewer);

    void broadCast(ViewInfo info);
}
