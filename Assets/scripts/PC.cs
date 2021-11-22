using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : Interactable 
{
    public GameObject story_Text;
    public bool is_Show;

    // Start is called before the first frame update
    
    private void Start(){
        Update_Story();
    }

    
    
    void Update_Story(){
        story_Text.SetActive(is_Show); // will this work?
        //story_Text.enabled = is_Show;
        
    }

    public override string GetDescription(){
        //return "Press [E] to interact with the <color=red>computer</color> "; // should make "E" a vars
        // could also do >>> 
        if (is_Show) return "";
        return "Press [E] to interact with the <color=red>computer</color> ";
        // dont want to show ^^^ when has text
        
    }
    public override void Interact(){
        is_Show = !is_Show;
        Update_Story();
    }

    
        
        
    
    
}

