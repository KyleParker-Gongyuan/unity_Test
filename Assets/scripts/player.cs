using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   /*  
    public speed
    public def_speed = 15f;
    public spr_speed = 35f;

    public Jump_height = 5f;

    public max_health = 200;
    private health = max_health;
 */


    float player_height = 2f; // should find player height this works for now

    [Header("Movement")]
    
    

    public float sprintSpeed = 4f;
    public float walk_Speed = 2f; // using acceleration is not a good idea for this 
    float move_Multi = 4f; // use this for sprint
    public float mouseSensitivity = 2f;
    
    private bool isMoving = false;
    private bool isSprinting =false;
    float moveH;
    float moveV;
 
    bool onflor;

    [Header("jumping")]
    public float jump_Height = 3f;

    [Header("Keybinds")]
    [SerializeField]
    KeyCode jump_Key = KeyCode.Space;

    [Header("Drag")]
    float rb_Drag_Flor = 2f;
    float rb_Drag_Air = 2f;

    Vector3 move_dir;
    Rigidbody rb;
 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
 
    }
 
    // Update is called once per frame
    void Update () {

        onflor = Physics.Raycast(transform.position, Vector3.down, player_height / 2 + 0.1f); // was having problem with just player_height / 2

        print(onflor);
        
        my_input();
    
        if (Input.GetKeyDown(jump_Key) && onflor){
            Jump();
        }
    }
    /* 
    void control_Drag(){
        if (onflor){
            rb.drag = rb_Drag_Flor;
        }
        else{

            rb.drag = rb_Drag_Air;
        }
    }
 */
    void my_input(){
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
        move_dir = transform.forward * moveV + transform.right * moveH;
    }
    private void FixedUpdate(){ // fixed update is faster  (for phyiscs things (acceleration and stuff) i think)

    move_Player();
    
    }
    void move_Player(){
        //rb.AddForce(move_dir * walkSpeed * move_Multi, ForceMode.Acceleration);
        transform.position += move_dir * walk_Speed * move_Multi * Time.deltaTime;
    }
    void Jump(){
        //rb.AddForce(transform.up * jump_Height, ForceMode.Impulse);
        transform.position += transform.up * jump_Height;
    }
    
}


