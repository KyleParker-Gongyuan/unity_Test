using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum Interaction_Type{
        Click,
        Hold

    }
    float holdTime;
    public Interaction_Type interaction_Type;

    public abstract string GetDescription();
    public abstract void Interact();
    

    

}
