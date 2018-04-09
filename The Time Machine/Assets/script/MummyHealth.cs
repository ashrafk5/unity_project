using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MummyHealth : MonoBehaviour {

	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public float sinkSpeed = 10f;              // The speed at which the enemy sinks through the floor when dead.
	public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
	public Room2_controller game;
	public GameObject collectable;
	//public AudioClip deathClip;                 // The sound to play when the enemy dies.


	Animator anim;                              // Reference to the animator.
	//AudioSource enemyAudio;                     // Reference to the audio source.
	ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
	public bool isDead;                                // Whether the enemy is dead.
	bool isSinking;                             // Whether the enemy has started sinking through the floor.


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
	//	enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();

		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;

	}


	void Update ()
	{
		if (isDead && collectable == null) {
			game.firstTime = false;
			game.startGame ();
			game.Play ();
            
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
			Destroy (gameObject, 10f);
		} else if (isDead && collectable != null) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
			Destroy (gameObject, 10f);

			//transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
			Destroy (gameObject, 0.1f);
		} else if (isDead && collectable != null) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
			Destroy (gameObject, 10f);

			//collect el collectable
		}
	}


	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		// If the enemy is dead...
		if(isDead)
			// ... no need to take damage so exit the function.
			//game.startGame();
			return;

		// Play the hurt sound effect.
		//enemyAudio.Play ();

		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;


		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death ();
		}
	}


	void Death ()
	{
		// The enemy is dead.
		anim.SetBool("isWalkingForward",false);
		anim.SetTrigger ("isDead");
		isDead = true;

		// Tell the animator that the enemy is dead.
		//anim.SetTrigger ("isDead");

		// Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
		//enemyAudio.clip = deathClip;
		//enemyAudio.Play ();
		//isSinking = true;

		// Increase the score by the enemy's score value.
		ScoreManager.score += scoreValue;

		// After 2 seconds destory the enemy.
	}


	/*public void StartSinking ()
	{
		// Find and disable the Nav Mesh Agent.
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

		// Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
		GetComponent <Rigidbody> ().isKinematic = true;

		// The enemy should no sink.
		isSinking = true;

		// Increase the score by the enemy's score value.
		//ScoreManager.score += scoreValue;

		// After 2 seconds destory the enemy.
		Destroy (gameObject, 2f);
	}*/
}
