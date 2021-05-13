using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    public LayerMask delimitations;
    public LayerMask floatables;
    public LayerMask player;
    public Collider2D currentEllement;
    RotateLevel rotateRef;
    float verticalRange = 0f;
    bool checkedSides;
    Transform target;
    Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
        rotateRef = FindObjectOfType<RotateLevel>();

        transform.parent = rotateRef.grid.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateRef.rotate)
        {
            currentEllement = Physics2D.OverlapCircle(transform.position + new Vector3(0, verticalRange, 0f), .2f, floatables);
            if (currentEllement != null)
            {
                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, verticalRange, 0f), .2f, floatables) && !Physics2D.OverlapCircle(transform.position + new Vector3(0f, verticalRange + 1, 0f), .2f, delimitations) && !Physics2D.OverlapCircle(transform.position + new Vector3(0f, verticalRange + 1, 0f), .2f, player))
                {
                    currentEllement.GetComponent<PropsMovement>().movePoint.position = transform.position + new Vector3(0, 1, 0);

                }
                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, verticalRange + 1, 0f), .2f, player) && currentEllement.GetComponent<PropsMovement>().floating)
                {
                    currentEllement.GetComponent<PropsMovement>().movePoint.position = transform.position + new Vector3(0, 1, 0);
                    playerMovement.movePoint.position = transform.position + new Vector3(0, 2, 0);
                }
            }


        }
    }


}
