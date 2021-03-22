using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	public float cmraJump;

	public float defY;
	public float smooth;
	public Rigidbody rbd;

	public float tm;
	public int cnt;

	public Vector3 iniCamPos;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;
		defY = transform.position.y;
		iniCamPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, iniCamPos.z);
		lastPlayerPosition = thePlayer.transform.position;


	/*	if (Input.GetKeyDown (KeyCode.Space))
		{
			
			Vector3 TargetJump = new Vector3 (transform.position.x + distanceToMove, transform.position.y + cmraJump, transform.position.z);
			transform.position = Vector3.Slerp (transform.position, TargetJump, smooth * Time.deltaTime);
		}

	*/

		if (Input.GetKeyDown (KeyCode.Space)||Input.GetMouseButtonDown(0))
		{cnt = 1;
			tm = 0.5f; // tm has ideal value = 0.5f

		}
	
		tm -= Time.deltaTime;

		if (tm > 0) {
			Vector3 TargetJump = new Vector3 (transform.position.x /*+ distanceToMove*/, transform.position.y + cmraJump, transform.position.z);  //   this line f code is generating problem with the appearence of bg while restarting the game
			transform.position = Vector3.Slerp (transform.position, TargetJump, smooth * Time.deltaTime);
		} else {cnt = 0;tm = 0;
		}

		if (transform.position.y > defY) 
		{
		rbd.useGravity = true;
				} 
		else 
		{
			rbd.useGravity = false;
			}
	
	

	}
}
