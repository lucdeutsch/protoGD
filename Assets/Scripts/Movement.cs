using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    float myAxis;
    float vertAxis;
    public LayerMask delimitations;
    public LayerMask pushables;
    public LayerMask water;
    public Collider2D currentEllement;
    public Collider2D currentEllementVertical;
    RotateLevel rotateRef;
    public bool floating;


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


            myAxis = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
            vertAxis = Mathf.Abs(Input.GetAxisRaw("Vertical"));
            currentEllement = Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, pushables);
            currentEllementVertical = Physics2D.OverlapCircle(movePoint.position + new Vector3(0, 1, 0f), .2f, pushables);
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (myAxis == 1f || vertAxis == 1f)
                {

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, delimitations))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, pushables))
                    {

                        if (currentEllement != null)
                        {

                            if (currentEllement.gameObject.GetComponent<PropsMovement>().pushed == false)
                            {
                                currentEllement.gameObject.GetComponent<PropsMovement>().pushed = true;

                                currentEllement.gameObject.GetComponent<PropsMovement>().Push(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f));

                                if (currentEllement.gameObject.GetComponent<PropsMovement>().performed)
                                {
                                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                                }

                            }
                        }

                    }
                    if (Physics2D.OverlapCircle(movePoint.position, .2f, water) || Physics2D.OverlapCircle(movePoint.position + new Vector3(0, -1, 0), .2f, water))
                    {
                        floating = true;
                    }
                    else
                    {
                        floating = false;
                    }

                    if (floating)
                    {
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, delimitations))
                        {
                            movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0f);

                        }
                        if (currentEllementVertical != null && Physics2D.OverlapCircle(movePoint.position, .2f, water) )
                        {
                            if (currentEllementVertical.gameObject.GetComponent<PropsMovement>().pushed == false)
                            {
                                currentEllementVertical.gameObject.GetComponent<PropsMovement>().pushed = true;

                                currentEllementVertical.gameObject.GetComponent<PropsMovement>().Push(new Vector3(0, Input.GetAxisRaw("Vertical"), 0f));

                                if (currentEllementVertical.gameObject.GetComponent<PropsMovement>().performed)
                                {
                                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0f);
                                }

                            }
                        }

                    }

                }

            }
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, water))
            {
                movePoint.position += new Vector3(0f, -1, 0f);
            }
        }





    }


    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(movePoint.position + new Vector3(0f, -1, 0f), .2f);
    }
}
