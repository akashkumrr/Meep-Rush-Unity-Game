using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerNew : MonoBehaviour {

	//public PauseMenu tpm;

	public float slowMo=0.01f;
	public float normTime=1.0f;

	public float moveSpeed;
	private float moveSpeedStore;

	public float jumpForce;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	public float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpTime;
	public float jumpTimeCounter;

	public Rigidbody2D myRigidbody;
	public bool grounded;
	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;

	private Animator myAnimator;

	//private Collider2D myCollider;

	public GameManager theGameManager;

	public bool stoppedJumping;
	public bool canDoubleJump;


	public AudioSource jumpSound;
	public AudioSource deathSound;

	public float myVariable;

	public float runningDistance;
	public float runningDistanceStore;

	public int coinCounter=0; 
	public int coinCounterStore;

	public float upTime=0;
	public float upTimeStore;

	// for torch powerUp

	public GameObject trch;
	public float maxtm;
	public float tm;
	public Slider SldTm;

	public float plsTm;

	// Use this for initialization
	void Start () {
		trch.SetActive (false);
		SldTm.enabled = false;
		SldTm.gameObject.SetActive(false);


		myRigidbody = GetComponent<Rigidbody2D> ();	
		//myCollider = GetComponent<Collider2D> (); 
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stoppedJumping = true;
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

	/*	if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
		{   
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play ();

			}
			if (!grounded && canDoubleJump) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			}

		}

		if ((Input.GetKey (KeyCode.Space)||Input.GetMouseButtonDown(0) &&!stoppedJumping)) 
		{
			if (jumpTimeCounter > 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)||Input.GetMouseButtonDown(0) )
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
*/
		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	
	
	//  torch powerUp


		if (trch.activeInHierarchy)
		{
			tm -= Time.deltaTime;

			SldTm.value = (float)tm / maxtm;
			SldTm.gameObject.SetActive(true);

		} 
	
		if (tm < 0) 
		{trch.SetActive (false);
			SldTm.gameObject.SetActive(false);
		}
	
	
	// slow mo things
		/*              /////////////////////////////////////   remove this later
		if (Input.GetMouseButtonDown(0)) {
			//Time.timeScale = slowMo;
			//Time.fixedDeltaTime = 0.02f * Time.timeScale;
			tpm.i=1;
		} else 
		{
		//	Time.timeScale = normTime;
		//	Time.fixedDeltaTime = 0.02f * Time.timeScale;
			tpm.i=0;
		}

*/
	

	}




	void OnCollisionEnter2D (Collision2D other)   //      check whether small d or capital D
	{
		
		if (other.gameObject.tag == "killbox") 
		{  if (moveSpeed > PlayerPrefs.GetFloat ("highSpeed")) {
				PlayerPrefs.SetFloat ("highSpeed", moveSpeed);
			}

			upTimeStore =upTimeStore+ upTime;
			PlayerPrefs.SetFloat ("playTime", upTimeStore);

			runningDistanceStore =runningDistanceStore+ runningDistance;
			PlayerPrefs.SetFloat ("rd", runningDistanceStore);

			coinCounterStore = coinCounterStore + coinCounter;
			PlayerPrefs.SetInt ("cc", coinCounterStore);


			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
			upTime = 0;
		}






	}


/*	public void Addcoin(int coinsToAdd)
	{ coinCounterStore += coinCounter;
		coinCounter += coinsToAdd;
		PlayerPrefs.SetInt ("cc", coinCounterStore);
	}
*/

}
