using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector3 dir;
    public bool pushed;
    public bool performed;
    public Transform movePoint;
    float myAxis;
    public LayerMask delimitations;
    RotateLevel refRotate;

    
    // Start is called before the first frame update
    void Start()
    {
        
        movePoint.parent = FindObjectOfType<RotateLevel>().grid.transform;
        transform.parent = FindObjectOfType<RotateLevel>().grid.transform;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (transform.position == movePoint.position)
        {
            pushed = false;
        }


        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f)
        {
            movePoint.position += new Vector3(0f, -1, 0f);
        }
    }

    public void Push(Vector3 direction)
    {
        performed = false;
        dir = direction;
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, delimitations))
        {
            movePoint.position += dir;
            performed = true;
        }
    }
}
