using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private CharacterController CharacterController;
    private Transform camara;
    //public Rigidbody rb;
    [SerializeField]
    private float rotationSpeed=700f;
    [SerializeField]
    private float speed = 200f;
    public void Start()
    {
        joystick = FindFirstObjectByType<Joystick>();
        CharacterController = GetComponent<CharacterController>();
        camara = FindFirstObjectByType<Camera>().GetComponent<Transform>();
    }
    void Move()
  {
        /*rb.velocity = new Vector3( joystick.Horizontal * speed, joystick.Vertical * speed, rb.velocity.z);
        if (joystick.Horizontal !=0 || joystick.Vertical!=0) {
                transform.rotation = Quaternion.LookRotation(rb.velocity);

            }*/
        if (joystick.Horizontal != 0 || joystick.Vertical!=0) {
            
            Vector3 direction = new Vector3(joystick.Horizontal,0f,joystick.Vertical);
            direction.Normalize();
            float targetRad = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,targetRad,0f);
            CharacterController.Move(direction*speed*Time.deltaTime);
        }
        
       
        /*Vector3 movementDirection = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        movementDirection.Normalize();
            transform.position = transform.position + movementDirection * speed * Time.deltaTime;
            if (movementDirection != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
            }
            */

        //transform.Translate(movementDirection* speed * Time.deltaTime,Space.Self);

        /*if (movementDirection != Vector3.zero)
        {
          Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
          transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }*/
    }

  private void FixedUpdate()
  {
    Move();
  }
}
