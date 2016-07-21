using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float gravity = 5f;
	public float speed = 5f;
	Vector3 Move;
	CharacterController Cc;
	public GameObject cam;
	public AudioListener AL;
	public Animator anim;
	public float MouseSensitivityX = 1f;
	public float MouseSensitivityY = 1f;
	//inputs
	public float vertical;
	public float horizontal;
	public float mouseX, mouseY;
	public bool Mobile=false;

	public GameObject MobileInputsPrefab;
	JoystickA leftjoystick,rightjoystick,buttonJoystick;
	public Shooting s;
	// Use this for initialization
	void Start () {
		Cc = GetComponent<CharacterController>();
		//GameObject input=(GameObject)Instantiate(MobileInputsPrefab,Vector3.zero,Quaternion.identity);
		if(Mobile){
			Instantiate(MobileInputsPrefab,Vector3.zero,Quaternion.identity);
			leftjoystick = (JoystickA)(GameObject.Find("LeftJoystick").GetComponent<JoystickA>());
			rightjoystick = (JoystickA)(GameObject.Find("RightJoystick").GetComponent<JoystickA>());
			buttonJoystick = (JoystickA)(GameObject.Find("ButtonJoystick").GetComponent<JoystickA>());
			s.joystick = buttonJoystick;
		}

	}
	// Update is called once per frame
	void Update () {
		if(!Mobile){
			Inputs();
		}else{
			MobileInputs();
		}

		Move = Vector3.zero;
		Move.y = -gravity * Time.deltaTime;
		Move.x = horizontal * Time.deltaTime * speed;
		Move.z = vertical * Time.deltaTime * speed;
		//anim
		anim.SetFloat("Vertical",vertical);
		anim.SetFloat("Horizontal",horizontal);
		
		//----

		transform.Rotate(0f,mouseX * MouseSensitivityX,0f);
		cam.transform.Rotate(mouseY * -MouseSensitivityY,0f,0f);

		Cc.Move(transform.rotation * Move);
	
	}
	void Inputs(){
		horizontal = Input.GetAxis("Horizontal");
		vertical = Mathf.Clamp(Input.GetAxis("Vertical"),-0.5f,1f);
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

	}
	void MobileInputs(){
		horizontal = leftjoystick.Horizontal;
		vertical = leftjoystick.Vertical;
		mouseX = rightjoystick.Horizontal;
		mouseY = rightjoystick.Vertical;
	}
}
