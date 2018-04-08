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
	public GameObject door;
	public Canvas container;
	public Image[] image = new Image[3] ;
	public Text text;
    private bool inTrigger;
	bool activateKeypad = false;
	void Start(){
		coffin_left = GameObject.FindWithTag ("CoffinLeft").GetComponent<CoffinScript> ();
		coffin_middle= GameObject.FindWithTag ("CoffinMiddle").GetComponent<CoffinScript> ();
		coffin_right= GameObject.FindWithTag ("CoffinRight").GetComponent<CoffinScript> ();
	}

    void Update()
    {
        if (inTrigger)
        {
            camera.SetActive(true);
            player.SetActive(false);
            container.gameObject.SetActive(true);
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
				if (Input.GetKey (KeyCode.RightArrow)) {			
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
				}
				else if (Input.GetKey(KeyCode.DownArrow)) {
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
				}else if (Input.GetKey(KeyCode.LeftArrow)) {
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
				}
			}

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = true;           

            }
            
    }

  
}


