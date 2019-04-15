using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fllow : MonoBehaviour {
    Text t;
    Player player;
    public Vector3 Offset;
	// Use this for initialization
	void Start () {
        Offset = new Vector3(-565,-256,0);
	}
    
	// Update is called once per frame
	void Update () {
        
        t.rectTransform.localPosition = Camera.main.WorldToScreenPoint(player.transform.position)+Offset;

	}
    public void setTp(Text _t,Player _player){
        t = _t;
        player = _player;
}

}
