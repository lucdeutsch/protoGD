using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldRules : MonoBehaviour
{
    
    public enum ObjectMaterial
    {
        Rock,
        Water,
        Wood,
        Player
    }

    public void SnapToGrid()
    {
        foreach (var item in FindObjectsOfType<WorldRules>())
        {
            int roundedPosX =(int)Mathf.Round(item.transform.position.x);
            int roundedPosY =(int)Mathf.Round(item.transform.position.y);
            if(item.transform.position.x  != roundedPosX)
            {
                item.transform.position  = new Vector2(roundedPosX,item.transform.position.y) ;
            }
            if(item.transform.position.y  != roundedPosY)
            {
                item.transform.position  = new Vector2(item.transform.position.x,roundedPosY) ;
            }
        }
        
        
    }
}
