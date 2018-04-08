using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrance_script : MonoBehaviour {
    public static GameObject door;
    public Animator anim;

    private void Start()
    {
        door = GameObject.Find("maindoor");
        anim = door.GetComponent<Animator>();
    }

    
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
    

    if (other.CompareTag("Player"))
        {

            anim.SetInteger("open", 1);


        }
    }
}
