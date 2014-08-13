using UnityEngine;
using System.Collections;

public class character_controller : MonoBehaviour {

	// Передвижение
	public float MoveSpeed = 0.2f; // Переделать движение под ригидбоди!
	public Vector3 MoveVector;
	private Quaternion FacingVector;
	public Vector2 jumpForce = new Vector2(0, 300);

	// Немного логических переменных
	public bool isGrounded = false;
	public bool facingRight = true;
	public bool canMoveRight = true;
	public bool canMoveLeft = true;
	public bool canJump = true;
	private bool isJumpMoveStoped = false;
	private bool isStuck = false;
	private bool isDead = false;
	private Vector3 lastPosition;
	public int timerforstuck = 0;

	void Update () {
		checkMovement();
		checkFacing();
		checkStuck();
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
				if(facingRight) rigidbody2D.AddForce(new Vector2(50f, 0f));
				if(!facingRight) rigidbody2D.AddForce(new Vector2(-50f, 0f));
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
			if (Input.GetAxis("Horizontal") < -0.01 || Input.GetAxis("Horizontal") > 0.01)
			{
				jumpForce.x = (facingRight) ? 150f:-150f;
			} else {
				jumpForce.x = 0;
			}
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

	void checkStuck()
	{
		timerforstuck++;
		if (timerforstuck == 3)
		{
			if (isStuck)
			{
				Debug.Log(timerforstuck);
				isStuck = false;
				rigidbody2D.fixedAngle = true;
			}
			if (!isGrounded && transform.position == lastPosition)
			{
				Debug.Log("ololo");
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
		if (isGrounded) {
			// Проигрывание звуков
			if ((Input.GetAxis ("Horizontal") > 0.005 ||  Input.GetAxis ("Horizontal") < -0.005) && !audio.isPlaying)
			{
				audio.Play();
			}
			if (Input.GetAxis ("Horizontal") < 0.005 &&  Input.GetAxis ("Horizontal") > -0.005 && audio.isPlaying) {
				audio.Stop();
			}
		} else audio.Stop ();
	}
}
