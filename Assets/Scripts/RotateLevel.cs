using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            grid.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            grid.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
        }
    }
}
