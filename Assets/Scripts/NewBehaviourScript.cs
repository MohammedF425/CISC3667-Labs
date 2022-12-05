using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int walkspeed = 15;
	[SerializeField] float inputHorizontal;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;

	public GameObject bulletToLeft;
	public GameObject bulletToRight;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	float nextFire = 0.0f;

	[SerializeField] Animator animator;


   // Start is called before the first frame update
    void Start()
    {
		if(rigid == null)
			rigid = gameObject.GetComponent<Rigidbody2D>();
			if(animator == null){
				animator = GetComponent<Animator>();
			}
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
		inputHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
			jumpPressed = true;

		if(Input.GetButtonDown ("Fire2") && Time.time>nextFire){
			nextFire=Time.time + fireRate;
			fire();
		}
		
		
    }

	//called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{

		rigid.velocity = new Vector2(inputHorizontal * walkspeed, rigid.velocity.y);
		if (isGrounded&& !jumpPressed)
        {
            if (inputHorizontal > 0 || inputHorizontal < 0)
                animator.SetInteger("motion", 1);
            else
                animator.SetInteger("motion", 0);
        }
		if((inputHorizontal<0&&isFacingRight) || (inputHorizontal>0&&!isFacingRight)){
			Flip();

		}
		if (jumpPressed&& isGrounded)
			Jump();
	}

	void Flip(){
		transform.Rotate(0, 180, 0);
		isFacingRight=!isFacingRight;

	}

	void Jump()
	{
		jumpPressed = false;
		isGrounded = false;
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		animator.SetInteger("motion", 2);
		
	}

	void fire(){
		bulletPos = transform.position;

		if(isFacingRight){
			bulletPos += new Vector2(+1f,0.2f);
			Instantiate (bulletToRight, bulletPos, Quaternion.Euler(new Vector3(0, 0, -90)));
		}else{
			bulletPos += new Vector2(-1f,0.2f);
			Instantiate (bulletToLeft, bulletPos, Quaternion.Euler(new Vector3(0, 0, 90)));

		}
	}

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			isGrounded = true;
			animator.SetInteger("motion", 0);

	}
	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag=="Obstacle"){
			gameObject.transform.position=new Vector3(-5.0f,-1.5f,10.0f);
		}
	}
}
