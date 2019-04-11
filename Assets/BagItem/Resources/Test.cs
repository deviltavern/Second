using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Drug dg = new Drug();
            dg.resID = ResName.lred;
            BagAction.Instance.addAlgorithom(dg, dg.resID);

            Debug.Log("按下了s");
        }
	}
}
