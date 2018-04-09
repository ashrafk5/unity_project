using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room2_controller : MonoBehaviour {
	private CoffinScript coffin_left;
	private CoffinScript coffin_middle;
	private CoffinScript coffin_right;
	public GameObject camera;
	public GameObject player;
//	public GameObject door;
	public Canvas container;
	public Image[] image = new Image[3] ;
	public Text text;
	public bool inTrigger;
	public bool firstTime = true;
	bool activateKeypad = false , rightactive = true,leftactive = true,midactive=true;
	void Start(){
		coffin_left = GameObject.FindWithTag ("CoffinLeft").GetComponent<CoffinScript> ();
		coffin_middle= GameObject.FindWithTag ("CoffinMiddle").GetComponent<CoffinScript> ();
		coffin_right= GameObject.FindWithTag ("CoffinRight").GetComponent<CoffinScript> ();
	}
	public void startGame(){
		camera.SetActive(true);
		player.SetActive(false);
		door.SetActive (true);
		container.gameObject.SetActive(true);
		if (!firstTime) {
			text.text = "You didn't find the object \n Press Enter to try again";
			text.enabled = true;
		}
	}
	public void Play(){
		if (Input.GetKey(KeyCode.KeypadEnter))
		{
			text.enabled = false;

			foreach (var item in image)
			{
				item.gameObject.SetActive(true);
			}
			activateKeypad = true;
		}
		if (activateKeypad) {
			if (Input.GetKey (KeyCode.RightArrow) && rightactive) {			
				door.SetActive (false);
				foreach (var item in image)
				{
					item.gameObject.SetActive(false);
				}
				player.SetActive (true);
				camera.SetActive (false);
				coffin_right.openCoffin ();
				inTrigger = false;
				activateKeypad = false;
				rightactive = false;

			}
			else if (Input.GetKey(KeyCode.DownArrow) && midactive) {
				door.SetActive (false);
				foreach (var item in image)
				{
					item.gameObject.SetActive(false);
				}
				player.SetActive (true);
				camera.SetActive (false);
				coffin_middle.openCoffin ();
				inTrigger = false;
				activateKeypad = false;
				midactive = false;

			}else if (Input.GetKey(KeyCode.LeftArrow) && leftactive) {
				door.SetActive (false);
				foreach (var item in image)
				{
					item.gameObject.SetActive(false);
				}
				player.SetActive (true);
				camera.SetActive (false);
				coffin_left.openCoffin ();
				inTrigger = false;
				activateKeypad = false;
				leftactive = false;
			}
		}
	}
   void Update()
    {
        if (inTrigger)
        {
			startGame ();

        }

		Play ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = true;           

        }
            
    }

  
}


