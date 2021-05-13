using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool pressed;
    public WaterSource[] linkedSources;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" || other.tag == "Prop")
        {
            Press();
        }
        
    }

    void Press()
    {
        if (!pressed)
        {
            pressed = true;
            transform.position -= new Vector3(0,.25f,0);
            foreach (WaterSource item in linkedSources)
            {
                item.activated = true;
                item.Spread();
            }
        }
    }
}
