using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar (){
		content.fillAmount = Map(100,0,100,0,1);
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//(80-0) * (1 - 0) / (100 - 0) + 0;
		//	80 * 1 / 100 =0.8
	}

}
