using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWalls : WorldRules
{
    

    public ObjectMaterial myMaterial;
    public Transform leftCheck;
    public Transform rightCheck;
    public LayerMask Walls;
    public float checkRadius;
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    bool leftCollide;
    bool rightCollide;
    PlayerController player;
    int timesPressed;
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<PlayerController>();
        gameObject.layer = LayerMask.NameToLayer(myMaterial.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        timesPressed = player.timesPressed;
        leftCollide = Physics2D.OverlapCircle(leftCheck.position, checkRadius, Walls);
        rightCollide = Physics2D.OverlapCircle(rightCheck.position, checkRadius, Walls);

        
        canMoveLeft = !leftCollide;

        canMoveRight = !rightCollide;
        
        switch (timesPressed)
        {
            case 0:
                leftCheck.position = gameObject.transform.position + new Vector3(-0.5f, 0);
               rightCheck.position = gameObject.transform.position +  new Vector3(0.5f, 0);
                break;
            case 1:
                leftCheck.position = gameObject.transform.position +  new Vector3(0, 0.5f);
                rightCheck.position = gameObject.transform.position +  new Vector3(0, -0.5f);
                break;
            case 2:
                leftCheck.position = gameObject.transform.position +  new Vector3(0.5f, 0);
                rightCheck.position = gameObject.transform.position +  new Vector3(-0.5f, 0);
                break;
            case 3:
                leftCheck.position = gameObject.transform.position +  new Vector3(0, -0.5f);
                rightCheck.position = gameObject.transform.position +  new Vector3(0, 0.5f);
                break;

        }

    }
}
