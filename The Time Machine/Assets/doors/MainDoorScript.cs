using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorScript : MonoBehaviour {
    public Animator anim;
    public Rigidbody rigi;
    public Vector3 PlayerPosition;
    bool closed_door_state=false; //false is open -- true is cloes 
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        PlayerPosition = GameObject.Find("player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       
        
		
	}
}
