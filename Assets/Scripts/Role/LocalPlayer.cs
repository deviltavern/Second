using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{

  public static  Player player;

    private void Awake()
    {
        player = this.GetComponent<Player>();
    }


}
