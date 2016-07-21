using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float FireRate = 2f;
	float cooldown = 0f;
	public float damage = 25f;
	bool shoot;
	public Animator anim;
	Ray ray;
	public Camera cam;
	public LayerMask player;
	public bool Mobile=false;
	public JoystickA joystick;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.FindObjectOfType<UnityEngine.UI.Text>().text = joystick.moveJoystick.tapCount.ToString();
		cooldown -= Time.deltaTime;
		if(!Mobile){
			Inputs();
		}else{
			MobileInputs();
		}
		if(shoot && cooldown<0f){
			GetComponent<AudioSource>().Play();
			ray = cam.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
			Debug.DrawRay(ray.origin, ray.direction * 200, Color.red);
			Shoot();
//			anim.SetFloat("Shoot",0f);
			cooldown = FireRate;

		}
	}
	void Shoot(){
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit,200f,player)){
			hit.collider.gameObject.GetComponent<Health>().TakeDamage(35f);
			Debug.Log(hit.collider.name);
		}
			
	}
	void Inputs(){
		shoot = Input.GetButton ("Fire1");
	}
	void MobileInputs(){
		shoot = joystick.Pressed;
	}
}
