using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    float myAxis;
    public LayerMask delimitations;
    public LayerMask pushables;
    public Collider2D currentEllement;
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

            if (transform.position == movePoint.position)
            {
                floating = false;
            }
            myAxis = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
            currentEllement = Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, pushables);
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (myAxis == 1f)
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

                }

            }
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f)
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
