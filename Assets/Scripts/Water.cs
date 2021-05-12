using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    int roomSize = 10;
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask delimitations;
    public LayerMask floatables;
    public Collider2D currentEllement;
    RotateLevel rotateRef;
    float verticalRange = 0f;
    bool checkedSides;

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
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f)
            {

                movePoint.position += new Vector3(0f, -1, 0f);
                
            }
            if (transform.position == movePoint.position && !checkedSides)
            {
                CheckSides();
                checkedSides = true;
            }
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
                        //do smth
                    }
                }
            }
            
        }
    }

    void CheckSides()
    {
        Debug.Log("running");
        bool bumpedRight = false;
        bool bumpedleft = false;
        int x = 0;
        int y = 0;
        for (int i = 0; i < roomSize; i++)
        {
            
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(i+.5f, 0, 0f), .2f, delimitations) && !bumpedRight)
            {
                Debug.Log("space right");
                transform.localScale += new Vector3(1f, 0, 0);
                
            }
            else
            {
                if(!bumpedRight)
                    x = i;
                bumpedRight = true;
            }
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-(i+.5f), 0, 0f), .2f, delimitations)&& !bumpedleft)
            {
                Debug.Log("space left");
                transform.localScale += new Vector3(1f, 0, 0);
               
            }
            else
            {
                if(!bumpedleft)
                    y = i;
                bumpedleft = true;
            }
        }

        movePoint.position += new Vector3(.5f*(x-y), 0, 0);
        //transform.localScale -= new Vector3(0,(float)(x+y+1)/10, 0);
    }
}
