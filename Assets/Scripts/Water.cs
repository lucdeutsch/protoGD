using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    int roomSize = 10;
    public float moveSpeed = 5f;

    public LayerMask delimitations;
    public LayerMask floatables;
    public Collider2D currentEllement;
    RotateLevel rotateRef;
    float verticalRange = 0f;
    bool checkedSides;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rotateRef = FindObjectOfType<RotateLevel>();
        
        transform.parent = rotateRef.grid.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateRef.rotate)
        {
            currentEllement = Physics2D.OverlapCircle(transform.position + new Vector3(0, verticalRange, 0f), .2f, floatables);

            if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, verticalRange, 0f), .2f, floatables))
            {
                currentEllement.GetComponent<PropsMovement>().movePoint.position = transform.position + new Vector3(0,1,0);
                
            }

        }
    }


}
