using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {
    Renderer rd;
    Color nowColor = Color.black;
// Use this for initialization
	void Start () {
        rd = GetComponent<Renderer>();
		
	}
    public void SetColor(Color col){
        nowColor = col;
    }

    void Update(){
        nowColor = Color.Lerp(nowColor, Color.black, Time.deltaTime);
        rd.material.color = nowColor;

    }
}
