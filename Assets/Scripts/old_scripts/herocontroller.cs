using UnityEngine;
using System.Collections;

public class herocontroller : MonoBehaviour {


	public float JumpSpeed = 1f;
	public float MoveSpeed = 0.2f;
	
	public bool isGrounded = false;
	public bool facingRight = true;
	
	public Vector3 MoveVector;
	public Quaternion FacingVector;
	public Vector2 jumpForce = new Vector2(0, 300);

	//public GameObject player_obj;
	ActionScript player_action;
	public Animator char_animator;
	public float movement_speed;
	private float speed_x = 0;
	private int cur_way;
	//private Vector2 n_pos;
	// Use this for initialization
	void Start () {

		player_action = gameObject.GetComponent<ActionScript>();
		cur_way = 0;
		speed_x = 0;
		//n_pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Space))
		{
			jump();
		}

		if (Input.GetAxis ("Horizontal") != 0)
			moveCharacter ();

		gameObject.transform.position = new Vector3 (gameObject.transform.position.x + movement_speed * speed_x * Time.deltaTime, gameObject.transform.position.y, 0);
	}
	void jump() {
		if (isGrounded) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForce);
			isGrounded = false;
		}
	}

	void moveCharacter () {
		if (Input.GetAxis ("Horizontal") < 0) {
			if (cur_way == 1) {
				Char_Flip ();
				cur_way = 0;
			}
			//gameObject.rigidbody2D.AddForce(new Vector2(1*speed_x,0));			
		} else if (Input.GetAxis ("Horizontal") > 0) {
			if (cur_way == 0) {
				Char_Flip ();
				cur_way = 1;
			}
			//gameObject.rigidbody2D.AddForce(new Vector2(1*speed_x,0));
		}
	}

	void FixedUpdate()
	{

		speed_x = Input.GetAxis("Horizontal");
		//char_animator.SetFloat("run",Mathf.Abs(speed_x*movement_speed*20)*100);

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		/*Vector3 direction = new Vector3(transform.position - lastPosition);
		Ray ray = new Ray(lastPosition, direction);
		RaycastHit hit;
		if (Physics.Raycast(ray, hit, direction.magnitude))
		{
			// Do something if hit
		}
		
		this.lastPosition = transform.position;*/
		
	}
	public void Char_Flip()
	{
		gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x*(-1),gameObject.transform.localScale.y);

		//gameObject.transform.Rotate(Vector2.up,180,Space.Self);
	}
}
