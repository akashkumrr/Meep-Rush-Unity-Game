using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//public PauseMenu tpm;

	public float slowMo=0.01f;
	public float normTime=1.0f;
	[Space(10)]

	public GameObject plyGameObj;

	[Space(10)]
	public float moveSpeed;
	public float moveSpeedStore;

	public float speedMultiplier;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;
	public float speedMilestoneCount;
	public float speedMilestoneCountStore;


	[Space(10)]
	public Rigidbody2D myRigidbody;
	public bool grounded;
	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;

	public Animator myAnimator;

	public GameManager theGameManager;

	[Space(10)]

	public float jumpForce;
	public float secJumpForcePerc;
	public bool canDoubleJump;


	public AudioSource jumpSound;
	public AudioSource deathSound;


	[Space(10)]
	public float myVariable;

	public float runningDistance;
	public float runningDistanceStore;

	public int coinCounter=0; 
	public int coinCounterStore;

	public float upTime=0;
	public float upTimeStore;



	[Space(10)]
	public bool hasTeleported;

	public TopPowerUpManager powMan;

	[Space(10)]
	public newSoundManager sManager;
	public GameObject magnetArea;

	[Space(10)]
	public Camera plyCam;

	[Space(10)]
	public GameObject torch;

	// Use this for initialization
	void Start () {
		


		myRigidbody = GetComponent<Rigidbody2D> ();    
		//myCollider = GetComponent<Collider2D> (); 
		myAnimator = GetComponent<Animator> ();
	
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		canDoubleJump = true;
		//myVariable = transform.position.x;

		if (PlayerPrefs.HasKey("cc"))
		{
			coinCounterStore = PlayerPrefs.GetInt ("cc");
		}

		if (PlayerPrefs.HasKey("rd"))
		{
			runningDistanceStore = PlayerPrefs.GetFloat ("rd");
		}

		if (PlayerPrefs.HasKey("playTime"))
		{
			upTimeStore = PlayerPrefs.GetFloat ("playTime");
		}


		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;


		plyCam.orthographicSize = 6.9f;
		sManager.BGM.pitch = Time.timeScale;
	}

	// Update is called once per frame
	void Update () {
		upTime += Time.deltaTime;






		runningDistance = transform.position.x;
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		myVariable = speedMilestoneCount - transform.position.x;
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount)
		{   myVariable = 0;

			speedMilestoneCount += speedIncreaseMilestone;


			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetMouseButtonDown(0))
		{   
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				canDoubleJump = true;
				jumpSound.Play ();

			}
			else if (!grounded && canDoubleJump==true)    //  this one is for second jump
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce*secJumpForcePerc);  // this is to reduce the second jumping height

				canDoubleJump = false;
				jumpSound.Play ();
			}

		}

		if (grounded) 
		{			
			canDoubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

		myAnimator.SetFloat("JPTime", powMan.t2 );
	

	}




	void OnCollisionEnter2D (Collision2D other)   //      check whether small d or capital D
	{

		if (other.gameObject.tag == "killbox") 
		{  if (moveSpeed > PlayerPrefs.GetFloat ("highSpeed")) {
				PlayerPrefs.SetFloat ("highSpeed", moveSpeed);
			}

			//upTimeStore =upTimeStore+ upTime;
			//PlayerPrefs.SetFloat ("playTime", upTimeStore);

			runningDistanceStore =runningDistanceStore+ runningDistance;
			PlayerPrefs.SetFloat ("rd", runningDistanceStore);

		//	coinCounterStore = coinCounterStore + coinCounter;
		//	PlayerPrefs.SetInt ("cc", coinCounterStore);				20 jan 2019


			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
			//upTime = 0;

			powMan.jetpackSlider.gameObject.SetActive (false);
			powMan.magnetSlider.gameObject.SetActive (false);
			powMan.fullcoinSlider.gameObject.SetActive (false);
			powMan.t1 = -1;
			powMan.t2 = -1;
			powMan.t3 = -1;



			magnetArea.gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "TELE") 
		{
			hasTeleported = true;
		}

	}

	public void etc()
	{
		StartCoroutine (countDown ());
	
	}

 IEnumerator countDown()
	{
		plyCam.orthographicSize = 1.0f;
		
		float tm=0;
		while (tm<= 0.31f)            // if this condn is not true then it will run the code below whille loop
		{
			tm += Time.deltaTime;
		//	print (tm);
			plyCam.orthographicSize = (6.9f-1.0f)*tm/0.31f +1.0f ;       // 6.9 is the orig focal len of camera
			sManager.BGM.pitch = tm/0.31f;      // the pitch will increase till 100
			yield return null;
		}



			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;


		plyCam.orthographicSize = 6.9f;
		sManager.BGM.pitch = Time.timeScale;

		yield return null;
	}


	public void etc22()
	{
		StartCoroutine (countDown22 ());

	}

	IEnumerator countDown22()
	{
		plyCam.orthographicSize = 5.0f;

		float tm=0;
		while (tm<= 0.25f)            // if this condn is not true then it will run the code below whille loop
		{
			tm += Time.deltaTime;
	//		print (tm);
			//if(plyCam.orthographicSize<7.00f)
				plyCam.orthographicSize = (6.9f-3.0f)*tm/0.25f +3.0f ;       // 6.9 is the orig focal len of camera and 3.0f is initial focal len

			sManager.BGM.pitch = tm/0.25f;      // the pitch will increase till 100
			yield return null;
		}



		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;


		plyCam.orthographicSize = 6.9f;
		sManager.BGM.pitch = Time.timeScale;

		yield return null;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "TorchPowerup")
		{
			torch.SetActive (true);
			StopAllCoroutines ();                     //// 18 december this line is causing problem while revivng and obtaining torch powerup



			plyCam.orthographicSize = 6.9f;
			sManager.BGM.pitch = Time.timeScale;
			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;

			StartCoroutine (onTime ());
		}



	}

	IEnumerator onTime()
	{
		print ("inside corourtine");

		float tm = 0.0f;

		while (tm <= 5.0f) 
		{
			tm += Time.deltaTime;

			yield return null;
		}

		print (tm);

		print ("Deactivated");
		torch.SetActive (false);
		yield return null;
	}
}

