using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script includes:
Movement, dash, walking sound
*/

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Fps Input")]
public class FpsInput : MonoBehaviour {

    public float speed = 6.0f, dash, gravity; //Normal speed, dash speed, gravity force;
    public int maxDashCD; //Dash cooldown counter set in inspectorM
    [SerializeField]private float currentSpeed; //Calculated speed and true speed of character
    
    public AudioClip dashSound;
    
    
    
    private CharacterController _charController;

	// Use this for initialization
	void Start () {
        
        _charController = GetComponent<CharacterController>();
        currentSpeed = speed; //Sets speed to normal
        
        //source = GetComponent<AudioSource>();//Init Audio Source
	}
	
	// Update is called once per frame
	void Update () {

        
        //Movement
        float deltaX = Input.GetAxis("Horizontal") * currentSpeed;
        float deltaZ = Input.GetAxis("Vertical") * currentSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, currentSpeed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);


	}
 
}
