using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCircleView : MonoBehaviour {

    public Text circleNumberLabel;
    public Text primeLabel;
	// Use this for initialization
    public void SetLabel(int number){
        circleNumberLabel.text = number.ToString();
    }

	public void SetPrimeLabel(string input)
	{
        
         primeLabel.text = input;
       
	}
}
