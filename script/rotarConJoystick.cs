
using UnityEngine;

public class rotarConJoystick : MonoBehaviour
{
    [SerializeField]
    private Joystick joystickGiro;
    float speed = 0.9f;
    [SerializeField]
    private Transform cam;
    float rotateY, rotateH;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Giro() {
        rotateH = joystickGiro.Horizontal * speed;
        rotateY = -(joystickGiro.Vertical * speed);
        //cam.Rotate(rotateY,0,0);
        cam.Rotate(0, rotateH, 0);
    }


    // Update is called once per frame
    void Update()
    {
        Giro();
    }
}
