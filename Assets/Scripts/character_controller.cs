using UnityEngine;
using System.Collections;

public class character_controller : MonoBehaviour {
	
	public float MoveSpeed = 0.2f;
	
	public bool isGrounded = false;
	public bool facingRight = true;
	public bool canMoveRight = true;
	public bool canMoveLeft = true;
	public bool canJump = true;
	private bool isJumpMoveStoped = false;
	private bool isWalkingSoundPlaying = false;
	
	public Vector3 MoveVector;
	private float MoveVector_notGrounded;
	private Quaternion FacingVector;

	public Vector2 jumpForce = new Vector2(0, 300);

	void Update () {
		checkMovement();
		checkFacing();
		if (!isGrounded)
		{
			if (MoveVector.x != 0 && (!canMoveLeft || !canMoveRight)) {
				MoveVector_notGrounded = MoveVector.x;
				MoveVector.x = 0;
				isJumpMoveStoped = true;
			} else if (isJumpMoveStoped){
				MoveVector.x = MoveVector_notGrounded;
				isJumpMoveStoped = false;
			}
		}
	}
	
	void checkMovement() {
		if (Input.GetKeyDown(KeyCode.Space)) jump();
		if (Input.GetAxis("Horizontal") < -0.01 || Input.GetAxis("Horizontal") > 0.01) move();
	}
	
	void move() {
		if (isGrounded) {
			if (Input.GetAxis ("Horizontal") > 0.01 && canMoveRight) {
				MoveVector.x = Input.GetAxis ("Horizontal") * MoveSpeed;
			} else if (Input.GetAxis ("Horizontal") < 0.01 && canMoveLeft) {
				MoveVector.x = Input.GetAxis ("Horizontal") * MoveSpeed;
			} else {
				MoveVector.x = 0;
			}
			if (Input.GetAxis ("Horizontal") > 0.005) facingRight = true;
			if (Input.GetAxis ("Horizontal") < -0.005) facingRight = false;

			if ((Input.GetAxis ("Horizontal") > 0.005 ||  Input.GetAxis ("Horizontal") < -0.005) && !isWalkingSoundPlaying)
			{
				isWalkingSoundPlaying = true;
				audio.Play();
			}
			if (Input.GetAxis ("Horizontal") < 0.005 &&  Input.GetAxis ("Horizontal") > -0.005) {
				isWalkingSoundPlaying = false;
				audio.Stop();
			}
		}
		if (!isGrounded) audio.Stop ();
		transform.position += MoveVector;
	}
	
	void jump() {
		if(isGrounded && canJump) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(jumpForce);
			isGrounded = false;
		}
	}
	
	void checkFacing() {
		FacingVector.y = (facingRight) ? 0 : 180;
		transform.rotation = FacingVector;
	}
}
