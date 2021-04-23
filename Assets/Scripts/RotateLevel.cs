using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public GameObject grid;
    public int timesPressed;
    float rotatespeed = 40f;
    public bool rotate;
    bool right;
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
                rotate = true;
                timesPressed++;
                target = Quaternion.Euler(new Vector3(0, 0, 90 * Mathf.Abs(timesPressed)));
                right = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("???");
                rotate = true;
                timesPressed--;
                target = Quaternion.Euler(new Vector3(0, 0, -90 *Mathf.Abs(timesPressed) ));
                right = true;

            }

            
        }

        if (rotate)
        {
            if (!right)
            {
                grid.transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotatespeed * Time.deltaTime);
            }
            else
            {
                grid.transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotatespeed * Time.deltaTime);
            }
        }

        if (grid.transform.rotation == target)
        {
            rotate = false;
        }





    }


}
