using UnityEngine;
using System.Collections;

public class MovementV2 : MonoBehaviour {
	//player atributes
	public float Speed = 1f;
	public float vertical, horizontal, MouseX, MouseY, Jump, LeftShift, Mouse1;
	public bool Mouse2, armed;
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
		if(Mouse2){
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
		horizontal = Mouse2 == true ? horizontal : vertical > 0f?  0f : vertical < 0f ? 0f : horizontal;
		anim.SetFloat("Horizontal",horizontal);
		anim.SetFloat("Vertical",vertical);
		anim.SetFloat("Sprint",LeftShift);
		anim.SetBool ("RightClick",Mouse2);
		anim.SetBool ("Armed",armed);
	}

	void GetInputs(){
		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		MouseX = Input.GetAxis("Mouse X");
		MouseY = Input.GetAxis("Mouse Y");

		Mouse1 = Input.GetAxis("Fire1");
		Mouse2 = Input.GetButton("Fire2");
		LeftShift = Input.GetAxis("Sprint");
		Jump = Input.GetAxis("Jump");
	}
}
