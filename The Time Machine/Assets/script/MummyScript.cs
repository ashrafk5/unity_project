using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MummyScript : MonoBehaviour {

	Transform player; // referrence to player position
	private MummyHealth mummyHealth;
	private NavMeshAgent nav ;
	public Rigidbody rb;
	public  Animator Mummyanim;
	public bool outCoffin;
	public bool coffinOpen;
	// Use this for initialization
	void Awake()
	{
		Mummyanim = GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player").transform;
		mummyHealth = GetComponent<MummyHealth> ();
		nav = GetComponent<NavMeshAgent>();
	}


	void Update(){
		if (coffinOpen) {
			Walking ();
		} else {
			Mummyanim.SetBool ("StandUp", true);
		}
	}

	public void Walking()
	{
		if (mummyHealth.currentHealth > 0) {
			Mummyanim.SetBool ("StandUp", false);
			Mummyanim.SetBool ("isWalkingForward", true);
			nav.SetDestination (player.position);

		} else {
			nav.enabled = false;
		}
	}


}
