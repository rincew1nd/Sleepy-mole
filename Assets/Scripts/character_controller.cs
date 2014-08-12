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
	private Quaternion FacingVector;

	public Vector2 jumpForce = new Vector2(0, 300);

	void Update () {
		checkMovement();
		checkFacing();
		playSound ();
	}
	
	void checkMovement() {
		if (Input.GetKeyDown(KeyCode.Space)) jump();
		if ((Input.GetAxis("Horizontal") < -0.01 || Input.GetAxis("Horizontal") > 0.01) && isGrounded) move();

		if (!isGrounded)
		{
			if (jumpForce.x != 0 && (!canMoveLeft || !canMoveRight)) {
				isJumpMoveStoped = true;
			} else if (isJumpMoveStoped){
				isJumpMoveStoped = false;
				rigidbody2D.AddForce(new Vector2(0.5f, 0f));
			}
		}
	}
	
	void move() {
		if (isGrounded) {
			// Перемещение персонажа вправо-влево
			if (Input.GetAxis ("Horizontal") > 0.01 && canMoveRight) {
				MoveVector.x = Input.GetAxis ("Horizontal") * MoveSpeed;
			} else if (Input.GetAxis ("Horizontal") < 0.01 && canMoveLeft) {
				MoveVector.x = Input.GetAxis ("Horizontal") * MoveSpeed;
			} else {
				MoveVector.x = 0;
			}

			// Направление спрайта персонажа
			if (Input.GetAxis ("Horizontal") > 0.005) facingRight = true;
			if (Input.GetAxis ("Horizontal") < -0.005) facingRight = false;
		}
		transform.position += MoveVector;
	}
	
	void jump() {
		if(isGrounded && canJump) {
			rigidbody2D.velocity = Vector2.zero;
			jumpForce.x = (facingRight) ? 150:-150;
			rigidbody2D.AddForce(jumpForce);
			isGrounded = false;
		} else if (!isGrounded && canJump) {
			jumpForce.x = 0;
		}
	}
	
	void checkFacing() {
		FacingVector.y = (facingRight) ? 0 : 180;
		transform.rotation = FacingVector;
	}

	void playSound() {
		if (isGrounded) {
			// Проигрывание звуков
			if ((Input.GetAxis ("Horizontal") > 0.005 ||  Input.GetAxis ("Horizontal") < -0.005) && !isWalkingSoundPlaying)
			{
				isWalkingSoundPlaying = true;
				audio.Play();
			}
			if (Input.GetAxis ("Horizontal") < 0.005 &&  Input.GetAxis ("Horizontal") > -0.005) {
				isWalkingSoundPlaying = false;
				audio.Stop();
			}
		} else audio.Stop ();
	}
}
