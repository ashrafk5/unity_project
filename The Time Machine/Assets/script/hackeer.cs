using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hackeer : MonoBehaviour
{
    private Animator anim;
    private CharacterController _CharacterController;
    public float speed = 5.0f;
    public float rotatingspeed = 240.0f;
    public float gravity = 20.0f;
    private Vector3 _movedir = Vector3.zero;
    public float v;
    public float h;
	public bool hasPistol ; //Maryam  
	public GameObject pistol;//Maryam

    //public Rigidbody rg;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        _CharacterController = GetComponent<CharacterController>();
        //rg = GetComponent<Rigidbody> ();

    }

	public void holdPistol(){
		//Maryam 
		// !! -> Note : ele m3a el code beta3 el inventory hyendh 3l function de lama el player y5tar el pistol en ya5odha
		anim.SetBool ("isIdle",false);
		pistol.SetActive(true);
		hasPistol = true;
		anim.SetBool ("hasPistol",true);
	}

	public void leavePistol(){
		//Maryam 
		// !! -> Note : ele m3a el code beta3 el inventory hyendh 3l function de lama el player y7ot el pistol fl inventory
		//anim.SetBool ("isIdle",true);
		//pistol.SetActive(false);
		hasPistol = false;
		//anim.SetBool ("hasPistol",false);
	}
    // Update is called once per frame
    void Update()
    {
		Walking (); 	//Maryam
		holdPistol();
    }


	public void Walking(){ //Maryam -> na2lt el mashy fe function bas
		/*	inputH = Input.GetAxis ("Horizontal");
            inputV=Input.GetAxis ("Vertical");
            anim.SetFloat ("inputH", inputH);
            anim.SetFloat ("inputV", inputV);
            float movex = inputH * 20f * Time.deltaTime;
            float movez = inputV * 50f * Time.deltaTime;
            rg.velocity = new Vector3 (movex, 0f, movez);
            if(movez<=0f){
                movex = 0f;


        }
        */

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		if (v < 0)
			v = 0;
		transform.Rotate(0, h * rotatingspeed * Time.deltaTime, 0);
		if (_CharacterController.isGrounded)
		{
			bool move = (v > 0) || (hideFlags != 0);
			if(!hasPistol){ //Maryam
				if (move) {
					anim.SetBool ("isIdle", false);
					anim.SetBool ("walk", true);
				} else {
					anim.SetBool ("isIdle", true);
					anim.SetBool ("walk", false);				
				}
			}else{ //Maryam
				if (move) {
					anim.SetBool ("hasPistol", false);
					anim.SetBool ("walkWithPistol", true);
				} else {
					//anim.SetBool ("hasPistol", true);
					anim.SetBool ("walkWithPistol", false);				
				}
			}
			_movedir = Vector3.forward * v;
			_movedir = transform.TransformDirection(_movedir);
			_movedir *= speed;

		}
		_movedir.y -= gravity * Time.deltaTime;
		_CharacterController.Move(_movedir * Time.deltaTime);
	}
}
