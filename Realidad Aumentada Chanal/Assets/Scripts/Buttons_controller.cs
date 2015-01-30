using UnityEngine;
using System.Collections;

public class Buttons_controller : MonoBehaviour {

	public GameObject canva1;
	public GameObject txt_1;

	public GameObject canva2;
	public GameObject txt_2;

	public void console_swag(){
		Debug.Log ("Swag");
	}


	public void change_canva1_adelante(){

		Vector3 canv_pos = canva1.transform.position;
		canv_pos.x += 2.0f;
		canva1.transform.position = canv_pos;
		Debug.Log ("Canva canbiada");


	}
	public void change_canva1_atras(){
		
		
	}

	public void change_canva2_adelante(){

	}

	public void change_canva2_atras(){
		
	}
}
