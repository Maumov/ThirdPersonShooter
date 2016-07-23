using UnityEngine;
using System.Collections;

public class MovementV2 : MonoBehaviour {
	//player atributes
	public float Speed = 1f;
	public float vertical, horizontal, MouseX, MouseY, Jump, LeftShift, Mouse1, Mouse2;

	Vector3 direction;

	//player components
	CharacterController charController;
	Animator anim;
	// Use this for initialization
	void Start () {
		//setting the components
		SetComponents();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputs();



		if(Mouse2 > 0f){
			transform.Rotate(0f,MouseX,0f);
			direction = transform.right * horizontal + vertical * transform.forward;
			direction.Normalize();
			charController.Move( direction * Speed * Time.deltaTime);	
		}else{
			transform.Rotate(0f,horizontal,0f);
			direction = vertical * transform.forward;
			direction.Normalize();
			charController.Move( direction * Speed * Time.deltaTime );	
		}
		SetAnimatorValues();

	}
	void SetComponents(){
		charController = GetComponent<CharacterController>();	
		anim = GetComponentInChildren<Animator>();
	}

	void SetAnimatorValues(){
		anim.SetFloat("Horizontal",horizontal);
		anim.SetFloat("Vertical",vertical);
		anim.SetFloat("Sprint",LeftShift);
	}

	void GetInputs(){
		vertical = Input.GetAxisRaw("Vertical");
		horizontal = Input.GetAxisRaw("Horizontal");
		MouseX = Input.GetAxis("Mouse X");
		MouseY = Input.GetAxis("Mouse Y");

		Mouse1 = Input.GetAxis("Fire1");
		Mouse2 = Input.GetAxis("Fire2");
		LeftShift = Input.GetAxis("Sprint");
		Jump = Input.GetAxis("Jump");
	}
}
