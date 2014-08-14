using UnityEngine;
using System.Collections;

public class character_controller : MonoBehaviour {
	
	// Move and facing
	public float MoveSpeed = 50f;
	public float JumpHeight = 300f;
	private Quaternion FacingVector;
	public Vector2 moveForce = new Vector2(0, 0);
	
	// Some logic variables
	public bool isGrounded = false;
	public bool facingRight = true;
	public bool canMoveRight = true;
	public bool canMoveLeft = true;
	public bool canJump = true;
	public bool isDead = false;
	private bool isJumpMoveStoped = false;
	private bool isStuck = false;
	private Vector3 lastPosition;
	public int timerforstuck = 0;
	
	void FixedUpdate () {
		isCharacterDead();
		checkMovement();
		checkJumpMoveStoped();
		checkFacing();
		checkStuck();
		playSound ();
	}
	
	void isCharacterDead() {
		if (isDead)
			GameObject.Find("scene_logic").GetComponent<scene_logic>().sceneReset();
	}
	
	void checkMovement() {
		if (Input.GetKeyDown(KeyCode.Space)) jump();
		if ((Input.GetAxis("Horizontal") < -0.01 || Input.GetAxis("Horizontal") > 0.01) && isGrounded) move();
	}
	
	void jump() {
		if(isGrounded && canJump) {
			rigidbody2D.velocity = Vector2.zero;
			
			if (Input.GetAxis("Horizontal") < -0.01 || Input.GetAxis("Horizontal") > 0.01)
			{
				moveForce.x = (facingRight) ? 150f:-150f;
			} else {
				moveForce.x = 0;
			}
			moveForce.y = JumpHeight;
			
			rigidbody2D.AddForce(moveForce);
			isGrounded = false;
		} else if (!isGrounded && canJump) {
			moveForce.x = 0;
		}
	}
	
	void move() {
		if (isGrounded) {
			// Moving character
			if (Input.GetAxis ("Horizontal") > 0.01 && canMoveRight) {
				moveForce.x = MoveSpeed;
			} else if (Input.GetAxis ("Horizontal") < 0.01 && canMoveLeft) {
				moveForce.x = -MoveSpeed;
			} else {
				moveForce.x = 0;
			}
			moveForce.y = 0;
			
			// Check character facing
			if (Input.GetAxis ("Horizontal") > 0.005) facingRight = true;
			if (Input.GetAxis ("Horizontal") < -0.005) facingRight = false;
			
			// Move sprite
			rigidbody2D.AddForce(moveForce);
		}
	}
	
	void checkJumpMoveStoped() {
		if (!isGrounded)
		{
			if (moveForce.x != 0 && (!canMoveLeft || !canMoveRight)) {
				isJumpMoveStoped = true;
			} else if (isJumpMoveStoped){
				isJumpMoveStoped = false;
				if(facingRight) rigidbody2D.AddForce(new Vector2(MoveSpeed, 0f));
				if(!facingRight) rigidbody2D.AddForce(new Vector2(-MoveSpeed, 0f));
			}
		}
	}
	
	void checkFacing() {
		// Change character facing
		FacingVector.y = (facingRight) ? 0 : 180;
		transform.rotation = FacingVector;
	}
	
	void checkStuck()
	{
		// Check character for stucking in other blocks
		timerforstuck++;
		if (timerforstuck == 3)
		{
			if (isStuck)
			{
				isStuck = false;
				rigidbody2D.fixedAngle = true;
			}
			if (!isGrounded && transform.position == lastPosition)
			{
				rigidbody2D.fixedAngle = false;
				isStuck = true;
			}
			lastPosition = transform.position;
			timerforstuck = 0;
		}
		if (timerforstuck > 2)
			timerforstuck = 0;
	}
	
	void playSound() {
		// Play walking sound
		if (isGrounded) {
			if ((Input.GetAxis ("Horizontal") > 0.005 ||  Input.GetAxis ("Horizontal") < -0.005) && !audio.isPlaying)
				audio.Play();
			if (Input.GetAxis ("Horizontal") < 0.005 &&  Input.GetAxis ("Horizontal") > -0.005 && audio.isPlaying)
				audio.Stop();
		} else audio.Stop ();
	}
}