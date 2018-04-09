using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinScript : MonoBehaviour {

	public Animator Coffinanim ;
	public GameObject Mummy;
	void Start(){
		Coffinanim = GetComponent<Animator> ();
		//openCoffin ();
	}

	public void openCoffin(){
		Coffinanim.SetTrigger ("IsSelected");
		if (Mummy != null) {
			Mummy.SetActive (true);
			Mummy.GetComponent<MummyScript> ().enabled = true;
			Mummy.GetComponent<MummyScript> ().coffinOpen = true;
		}
	}

}
