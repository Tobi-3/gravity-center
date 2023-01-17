using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player_Movement : MonoBehaviour{


	[Tooltip("This is the gameobject were the player is attracted to. If nothing, the player will fly, you can change that gameobject on Runtime")]
	public GameObject CenterOfGravity;
	public float GravityForce;
	public float distanceToCenter;

	/* this is the distance that the player has to the gravityCenter at the start of the game. 
	This is the "default" and there will be no changes on the GravityForce if player is further away
	than this default. Needs to be changed with the new level */
	private float distanceOnStart; 
	
	public float PlayerSpeed;
	public float MaxSpeed;
	public float JumpSpeed;
	public bool isMoving;
	public bool isJumping;

	[Tooltip("For Double Jump or more. Set to 1 for a single jump")]
	public int NumberOfJumps;
	private bool IsGrounded;
	private int JumpCount;
	private float distToGround;
	private Collider2D col;
	public LayerMask GroundedMask;
	
	private Rigidbody2D RB2D;
	

	private SpriteRenderer PlayerSpriteRenderer;
	private Animator anim;
	private float AngularSpeedLimitation;


	void Start() {
		RB2D = GetComponent<Rigidbody2D>();
		PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

		col = GetComponent<Collider2D>();
		distToGround = col.bounds.extents.y;
		JumpCount = 0;

		//change once new leveldesign is implemented
		distanceOnStart = 12f;
	}



	void Update() {
		On_PlayerMovement();
		On_PlayerJump();
		MirrorAnimationPlayer();
		CheckIfPlayerGrounded();
		ResetNumberOfJumps();
		CalculateDistance();
		changeGravityForce();
		GravityDrag();
		Debug.DrawRay(this.transform.position, -transform.up, Color.green);
	}
	
	//calcs Distance between Player and Center of Gravity
	private void CalculateDistance(){
		distanceToCenter =  Vector3.Distance(CenterOfGravity.transform.position, this.transform.position);
	}

	//increases the grav Pull when closer to the Gravity Center
	private void changeGravityForce(){
		if(distanceToCenter < distanceOnStart){
			GravityForce = 1 + 1 - distanceToCenter / distanceOnStart;
		}
	}

	//This function calculate the speed limitation of the player depending of how far he is from the center of Gravity.
	//This will prevent the player from flying if he goes too fast, too close from the center of gravity 
	private float CalculateAngularSpeedLimitation(){

		if(CenterOfGravity != null){
			float speedLimitation;
			float distance;

			distance = Vector3.Distance(transform.position, CenterOfGravity.transform.position);
			distance = distance/10;
			Debug.Log($"distance: {distance}");
			// Debug.Break();
			speedLimitation = Mathf.Lerp(0.5F, 2F, distance);
			speedLimitation = speedLimitation/5;

			return speedLimitation;
			
		}
		else{ return 1; } //If the player doesn't have a gravity center, no speed limitation is set.
	}


	private void GravityDrag(){
		if(CenterOfGravity != null){
			RB2D.AddForce((CenterOfGravity.transform.position - transform.position) * GravityForce);
			Vector3 dif = CenterOfGravity.transform.position - transform.position;
			float RotationZ = Mathf.Atan2(dif.y , dif.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0.0F, 0.0F, RotationZ + 90);
		}
	}


	private void On_PlayerMovement(){
		if(Input.GetAxis("Horizontal") != 0){
			Vector2 localvelocity;
			localvelocity = transform.InverseTransformDirection(RB2D.velocity);
			localvelocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerSpeed * 100 * CalculateAngularSpeedLimitation();
			RB2D.velocity = transform.TransformDirection(localvelocity);
			isMoving = true;
			anim.SetBool("PlayerMoving", true);
		}
		else { //Slow down the player when no pressure on the Horizontal Axis (For more responsive controls).
			
			Vector2 localvelocity;
			localvelocity = transform.InverseTransformDirection(RB2D.velocity);
			localvelocity.x = localvelocity.x * 0.5F;
			RB2D.velocity = transform.TransformDirection(localvelocity);
			isMoving = false;
			anim.SetBool("PlayerMoving", false);
		}
	}

	private void On_PlayerJump(){
		if(Input.GetButtonDown("Jump")){
			if(JumpCount < NumberOfJumps){
				JumpCount++;
				Vector2 localvelocity;
				localvelocity = transform.InverseTransformDirection(RB2D.velocity);
				localvelocity.y = 0;
				RB2D.velocity = transform.TransformDirection(localvelocity);

				RB2D.AddRelativeForce(new Vector2(0,1) * JumpSpeed * 10, ForceMode2D.Impulse);
			}
		}
	}


	private void CheckIfPlayerGrounded(){
		
		if (isGrounded()) 
		{	
			IsGrounded = true;
			isJumping = false;
			anim.SetBool("PlayerJumping", false);
		}
		else {
			IsGrounded = false;
			isJumping = true;
			anim.SetBool("PlayerJumping", true);
		}
	}


	private bool isGrounded2(){
		CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		float rotation = transform.rotation.z;
		
		Vector2 bottomPoint = rotation * (capsule.bounds.center - capsule.bounds.extents.y * (capsule.bounds.center - CenterOfGravity.transform.position).normalized) ;
		
		return Physics2D.CapsuleCast(bottomPoint, capsule.size, capsule.direction, rotation, -transform.up, 1f, GroundedMask).collider != null;
	}


	private bool isGrounded(){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.9f, GroundedMask);

		return  hit.collider != null;
	}

	

	//Below this point, The script is doing normal stuff (like animation)//


	private void MirrorAnimationPlayer(){
		Vector2 localVelocity = transform.InverseTransformDirection(RB2D.velocity);

		if(localVelocity.x > 0.5F){
			if(PlayerSpriteRenderer.flipX == true){
				PlayerSpriteRenderer.flipX = false;
			}
		}
		else if (localVelocity.x < -0.5){
			if(PlayerSpriteRenderer.flipX == false){
				PlayerSpriteRenderer.flipX = true;
			}
		}
	}
	

	private void ResetNumberOfJumps()
	{	
		if (IsGrounded && JumpCount > 0) 
		{
			JumpCount = 0;
		}
	}
}
