using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_moving : MonoBehaviour {
    // Use this for initialization
   // private GameObject player;

	public Transform playertransform; //mkan el player
	private Vector3 _cameraoffset;   //el msafa ben el player w el camera

	[Range(0.01f,1.0f)]
	public float smoothfactor=0.5f;
	public bool lookatplayer = false;
	public bool rotatearoundplayer = true;
	public float rotationspeed=5.0f;


	void Start () {
      /*  player = GameObject.Find("player");
        this.transform.LookAt(player.transform);
        this.transform.position = new Vector3(player.transform.position.x-15, player.transform.position.y+40, player.transform.position.z+30);
*/
		_cameraoffset = transform.position - playertransform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
		if (rotatearoundplayer) {
			Quaternion camturnangle = Quaternion.AngleAxis(Input.GetAxis ("Mouse X")*rotationspeed,Vector3.up);
			_cameraoffset = camturnangle * _cameraoffset;
		}

		Vector3 newpos = playertransform.position + _cameraoffset;
		transform.position = Vector3.Slerp (transform.position, newpos, smoothfactor);

		if (lookatplayer || rotatearoundplayer) {
			transform.LookAt (playertransform);
		}



		/*  this.transform.position = new Vector3(player.transform.position.x-15, player.transform.position.y+40, player.transform.position.z+30);
        float rotation_H = Input.GetAxis("Mouse Y");
        float rotation_V = Input.GetAxis("Mouse X");
        this.transform.Rotate(new Vector3(-rotation_H*0.5f, rotation_V*0.5f,0));
		player.transform.Rotate(new Vector3(-rotation_H * 0.5f, rotation_V * 0.5f, 0));*/

    }
}
