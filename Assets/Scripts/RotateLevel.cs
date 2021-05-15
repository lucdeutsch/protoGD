using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateLevel : MonoBehaviour
{
    public static event Action Rotate;
    public static event Action RotateOver;
    public GameObject grid;
    public int timesPressed;
    float rotatespeed = 40f;
    public bool rotate;
    public bool enableRotation;
    [HideInInspector]
    public Quaternion target;
    Vector3 prevPos;
    Transform cameraPos;
    int rotateOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!rotate && enableRotation)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (timesPressed > 0)
                {
                    timesPressed -= 1;
                }
                else
                {
                    timesPressed = 3;
                }
                Rotate?.Invoke();
                rotate = true;
                prevPos = grid.transform.position;
                rotateOffset = 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (timesPressed < 3)
                {
                    timesPressed += 1;
                }
                else
                {
                    timesPressed = 0;
                }
                Rotate?.Invoke();
                rotate = true;
                prevPos = grid.transform.position;
                rotateOffset =-1;
            }


        }

        switch (timesPressed)
        {
            case 0:
                target = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 1:
                target = Quaternion.Euler(new Vector3(0, 0, 270));
                break;
            case 2:
                target = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case 3:
                target = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            default:
                break;
        }

        if (rotate)
        {
            //grid.transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotatespeed * Time.deltaTime);
            grid.transform.RotateAround(new Vector3(cameraPos.position.x,cameraPos.position.y,grid.transform.position.z),
            new Vector3(0,0,1),rotatespeed*Time.deltaTime* rotateOffset);
        }

        if (Mathf.Abs(grid.transform.rotation.eulerAngles.z - target.eulerAngles.z) <= .5f && rotate)
        {
            grid.transform.rotation = target;
            rotate = false;
            RotateOver?.Invoke();
        }





    }

    


}
