using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private float sensitiveX;
    [SerializeField]
    private float sensitiveY;

    Camera cam;

    float mouseX;
    float mouseY;
    
    float multiplier = 0.1f; //just in case needed

    float rotX;
    float rotY;
    
    private void Start(){

        cam = GetComponentInChildren<Camera>(); // same as this onready var aimcas = $Head/Camera/AimCast (sorta)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    
    private void Update()
    {
        my_input();
        cam.transform.localRotation = Quaternion.Euler(rotX,0,0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    void my_input(){

        
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        rotY += mouseX * sensitiveX * multiplier;
        rotX -= mouseY * sensitiveY * multiplier;

        rotX = Mathf.Clamp(rotX, -90f, 90f); // cant just use clamp
        
    }
}
