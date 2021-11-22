using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Interact : MonoBehaviour
{
    public float interaction_Distance;
    public TMPro.TextMeshProUGUI interaction_Text;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>(); // might need cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f)); // this should be centered
        RaycastHit hit;
        bool hitobj = false;

        if (Physics.Raycast(ray, out hit, interaction_Distance)){
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null){ //not == nothing

            handle_Interaction(interactable);
            interaction_Text.text = interactable.GetDescription();
            hitobj = true;

            }
        }
        if (!hitobj) interaction_Text.text = "";
    }

    void handle_Interaction(Interactable interactable){
        KeyCode key = KeyCode.E; // same as keyboardCheckPress(ord("E"))
        switch(interactable.interaction_Type){
            case Interactable.Interaction_Type.Click: // using upercase and lowercase of the same word gonna be hard change
                if (Input.GetKeyDown(key)){
                    interactable.Interact();
                    
                }
                break; 
            case Interactable.Interaction_Type.Hold:
            if (Input.GetKey(key)){
                    interactable.Interact();
                }
                break;

            default:
                throw new System.Exception("Unsupported interact (what did you do?)");
        }
    }
}
