using UnityEngine;
using System.Collections;

// Stick this on something with a HingeJoint
// For the Hinge Joint on the flipper, you want to make the axis of the
// anchor (the orange thing) perpendicular to the table

public class FlipperController : MonoBehaviour
{
	public float restPosition = 0F;
	public float _MaxAngle = 80f;
	public float flipperSpring = 200f;
	public float florce = 20f;
	public float flipperDamper = .5F;
	public enum _ControlFlipper{Left,Rigth};
	public _ControlFlipper _side;
	private HingeJoint hingeJoing;
//	public string inputButtonName = "LeftFlipper";

	JointSpring spring = new JointSpring(); 

	void Awake ()
	{
		

	}
	private void Start()
	{
		hingeJoing = GetComponent<HingeJoint> ();
		hingeJoing.useSpring = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		spring.spring = flipperSpring;
		spring.damper = flipperDamper;
		
		if (_side == _ControlFlipper.Rigth && Input.GetKey(KeyCode.X)
			||_side == _ControlFlipper.Left && Input.GetKey(KeyCode.M))
			spring.targetPosition = _MaxAngle;
		else
			spring.targetPosition = restPosition;


		hingeJoing.spring = spring;


	
		}
}
