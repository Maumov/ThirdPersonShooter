using UnityEngine;
using System.Collections;

public class JoystickA: MonoBehaviour {
	public JoyStickBase moveJoystick;

	public float Horizontal;
	public float Vertical;
	public bool Pressed;
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

		if(moveJoystick.tapCount>0){
			Pressed = true;
			if(moveJoystick.position.y>0.25f){
				Vertical = moveJoystick.position.y;
			}
			if(moveJoystick.position.y<-0.25f){
				Vertical = moveJoystick.position.y;
			}
			if((moveJoystick.position.y>-0.25f)&&(moveJoystick.position.y<0.25f)){
				Vertical= 0f;
			}
			if(moveJoystick.position.x>0.25f){
				Horizontal = moveJoystick.position.x;
			}
			if(moveJoystick.position.x<-0.25f){
				Horizontal = moveJoystick.position.x;
			}
			if((moveJoystick.position.x>-0.25f)&&(moveJoystick.position.x<0.25f)){
				Horizontal = 0f;
			}
		}else{
			Vertical = 0f;
			Horizontal = 0f;
			Pressed = false;
		}

		
	}
}
