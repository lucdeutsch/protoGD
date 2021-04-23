using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public GameObject grid;
    public int timesPressed;
    float rotatespeed = 40f;
    public bool rotate;
    
    Quaternion target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!rotate)
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
                rotate = true;
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
                rotate = true;
            }


        }

        switch (timesPressed)
        {
            case 0:
                target = Quaternion.Euler(new Vector3(0, 0, 0)); ;
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
            grid.transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotatespeed * Time.deltaTime);
        }

        if (grid.transform.rotation == target)
        {
            rotate = false;
        }





    }


}
