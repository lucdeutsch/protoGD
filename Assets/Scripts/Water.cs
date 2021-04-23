using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask delimitations;
    public LayerMask floatables;
    public Collider2D currentEllement;
    RotateLevel rotateRef;
    float verticalRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rotateRef = FindObjectOfType<RotateLevel>();
        movePoint.parent = rotateRef.grid.transform;
        transform.parent = rotateRef.grid.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateRef.rotate)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            currentEllement = Physics2D.OverlapCircle(movePoint.position + new Vector3(0, verticalRange, 0f), .2f, floatables);

            if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalRange, 0f), .2f, floatables))
            {
                if (currentEllement != null)
                {
                    
                    if (currentEllement.GetComponent<Movement>() != null)
                    {
                        if (!currentEllement.GetComponent<Movement>().floating)
                        {
                            
                            currentEllement.GetComponent<Movement>().floating = true;
                            currentEllement.GetComponent<Movement>().movePoint.position += new Vector3(0f, 1f, 0f);
                        }

                    }
                    if (currentEllement.GetComponent<Wood>() != null)
                    {

                    }
                }
            }
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f)
            {
                
                movePoint.position += new Vector3(0f, -1, 0f);
            }
        }





    }
}
