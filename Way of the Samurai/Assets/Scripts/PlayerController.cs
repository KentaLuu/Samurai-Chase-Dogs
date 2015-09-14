using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;
	public float maxSpeed = 10f;

	public bool grounded = true;
	public float lastYLocation;

	float jumpForce = 6;
	float timeToJumpApex;
	float gravity;
	float jumpVelocity;

	public List<Button> buttons = new List<Button>();
	public List<bool> buttonList = new List<bool>();
	public GameObject playerFloor = new GameObject();

	public float h = 0f;
	public float v = 0f;

	Animator anim;
	Rigidbody2D rb2d;

	public Vector3 velocity;
	public Vector3 position;

	void Start ()
	{
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(false);
		}

		#else
		foreach(var b in buttons)
		{
			buttonList.Add(false);
		}

		#endif
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D> ();
		timeToJumpApex = .45f;
	}

	void FixedUpdate ()
	{
		gravity = -jumpForce / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		//Horizontal Vertical movement
		h = 0;
		h = Input.GetAxis ("Horizontal");
		SlashAndStab ();

		#else
		buttons[0].onClick.AddListener(delegate{Buttons(0);});
		buttons[1].onClick.AddListener(delegate{Buttons(1);});
		buttons[2].onClick.AddListener(delegate{Buttons(2);});
		buttons[3].onClick.AddListener(delegate{Buttons(3);});
		buttons[4].onClick.AddListener(delegate{Buttons(4);});

		#endif

		HVMovement ();

		//Jump
		if ((Input.GetButtonUp ("Jump") 
		     #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		     #else
		     || buttonList[2]
			#endif
		     ) && grounded) {
			rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
			velocity.y = jumpVelocity;
			anim.SetBool ("Jump", true);
			grounded = false;
		} 
		else if (rb2d.position.y == lastYLocation && !grounded) {
			anim.SetBool ("Jump", false);
			anim.SetBool ("Fall", false);
			
			rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
			grounded = true;
			#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
			#else
			buttonList[2]=false;
			#endif
			velocity.y = 0;
		}
		else if (!grounded) {
			if(velocity.y <= 0)
			{
				anim.SetBool ("Jump", false);
				anim.SetBool ("Fall", true);
			}
			velocity.y += gravity * Time.deltaTime;
		}

		//Collider Position
		Vector3 ColliderPosition = playerFloor.transform.position;
		ColliderPosition.x = position.x;
		playerFloor.transform.position = ColliderPosition;

		//Movement render
		rb2d.velocity = velocity;
		
		//Save position
		lastYLocation = rb2d.position.y;

		//Flip
		if (h < 0 && !facingRight)
			Flip ();
		else if (h > 0 && facingRight)
			Flip ();
	}
	void Buttons (int B)
	{
		if(B == 0)
		{
			buttonList[0] = true;
			if(h > 0) h = 0;
			h = -1;
			buttonList[0] = false;
		}
		else if(B == 1)
		{
			buttonList[1] = true;
			if(h < 0) h = 0;
			h = 1;
			buttonList[1] = false;
		}
		else if(B == 2 && grounded)
		{
			buttonList[2] = true;
		}
		else if(B == 3)
		{
			GetComponent<Animator>().Play("Slash");
			if (!buttonList[0] || !buttonList[1]) h = 0;
		}
		else if(B == 4)
		{
			GetComponent<Animator>().Play ("Stab");
			if (!buttonList[0] || !buttonList[1]) h = 0;
		}
	}
	void HVMovement () 
	{
		//H Movement
		velocity.x = h * maxSpeed;
		anim.SetFloat ("Speed", Mathf.Abs (h));

		//V Movement
		v = Mathf.Sign(Input.GetAxis ("Vertical"))/10;
		position = rb2d.position;
		position.y += v;
		//rb2d.position = position;
		//yLocation += v;
	}
	void SlashAndStab()
	{
		if (Input.GetButtonDown ("Fire2")) {
			GetComponent<Animator>().Play ("Stab");
		} 
		if (Input.GetButtonDown ("f")) {
			GetComponent<Animator>().Play("Slash");
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
