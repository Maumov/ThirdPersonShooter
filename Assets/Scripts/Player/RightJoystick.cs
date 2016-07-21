using UnityEngine;
using System.Collections;

public class RightJoystick : MonoBehaviour {

	public JoyStickBase moveJoystick;
	//public Transform cameraPivot ;						// The transform used for camera rotation
	
	public float forwardSpeed = 4f;
	public float backwardSpeed  = 1f;
	public float sidestepSpeed = 1f;
	public float jumpSpeed = 8f;
	public float inAirMultiplier  = 0.25f;					// Limiter for ground speed while jumping
	public Vector2 rotationSpeed;	// Camera rotation speed for each axis
	
	private Transform thisTransform ;
	private CharacterController character;
	private Vector3 cameraVelocity;
	private Vector3 velocity;	
	
	// Use this for initialization
	void Start () {
		
	}
	void OnEndGame()
	{
		// Disable joystick when the game ends	
		moveJoystick.enabled = false;
		//buttonJoystick.enabled = false;	
		
		// Don't allow any more control changes when the game ends
		this.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		//		if(moveJoystick.tapCount>0){
		//			if(moveJoystick.position.y>0.5f){
		//				Controller.MoveY = 1f;
		//			}
		//			if(moveJoystick.position.y<-0.5f){
		//				Controller.MoveY = -1f;
		//			}
		//			if((moveJoystick.position.y>-0.5f)&&(moveJoystick.position.y<0.5f)){
		//				Controller.MoveY= 0f;
		//			}
		//			if(moveJoystick.position.x>0.5f){
		//				Controller.MoveX = 0.5f;
		//			}
		//			if(moveJoystick.position.x<-0.5f){
		//				Controller.MoveX = -0.5f;
		//			}
		//			if((moveJoystick.position.x>-0.5f)&&(moveJoystick.position.x<0.5f)){
		//				Controller.MoveX = 0f;
		//			}
		//		}else{
		//			Controller.MoveY = 0f;
		//			Controller.MoveX = 0f;
		//			//Controller.rotate = moveJoystick.position.x;
		//		}
		
		
	}
}
