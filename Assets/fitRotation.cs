using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RotateLevel.RotateOver += Fit;
    }

    // Update is called once per frame
    void Fit()
    {
        if (this != null)
        {
            transform.rotation = Quaternion.identity;
        }
        
    }
}
