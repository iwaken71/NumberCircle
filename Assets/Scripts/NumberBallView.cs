using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBallView : MonoBehaviour {
    public Text label;

    public void SetLabel(int number){
        label.text = number.ToString();
    }

    public void SetColor(Color col){
        GetComponent<Renderer>().material.color = col;

    }
}
