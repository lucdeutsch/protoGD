using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] rocks;
    public Transform groundCheck;
    public LayerMask ground;
    public float checkRadius;
    Rigidbody2D rb;
    public Camera cam;
    public bool isMoving;
    DetectWalls detectWalls;
    public int timesPressed;
    float baseGravity;
    Vector3 dirRight;
    Vector3 dirLeft;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        detectWalls = GetComponent<DetectWalls>();
        
        baseGravity = -10;
        rocks = GameObject.FindGameObjectsWithTag("Rock");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            if (timesPressed<3)
            {
                timesPressed += 1;
            }
            else
            {
                timesPressed = 0;
            }
            Rotate();
            
            
        }
        if (Input.GetKeyDown(KeyCode.A) && isGrounded)
        {
            if (timesPressed>0)
            {
                timesPressed -= 1;
            }
            else
            {
                timesPressed = 3;
            }


            Rotate();
        }
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            if (timesPressed<2)
            {
                timesPressed += 2;
            }
            else
            {
                timesPressed -=2;
            }


            Rotate();
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && detectWalls.canMoveLeft && isGrounded)
        {

            isMoving = true;
            transform.position += dirRight;
            //rb.MovePosition(new Vector3(transform.position.x - 1, transform.position.y));
            Invoke("StopMoving", .1f);
        }
        if (Input.GetKeyDown(KeyCode.D) && detectWalls.canMoveRight && isGrounded)
        {

            isMoving = true;
            transform.position += dirLeft;
            //rb.MovePosition(new Vector3(transform.position.x + 1, transform.position.y));
            Invoke("StopMoving", .1f);
        }
        
        
        

    }

    void StopMoving()
    {
        isMoving = false;
    }

    private void FixedUpdate()
    {
        switch (timesPressed)
        {
            case 0:
                dirLeft = new Vector3(1, 0);
                dirRight = new Vector3(-1, 0);
                break;
            case 1:
                dirLeft = new Vector3(0, -1);
                dirRight = new Vector3(0, 1);
                break;
            case 2:
                dirLeft = new Vector3(-1, 0);
                dirRight = new Vector3(1, 0);
                break;
            case 3:
                dirLeft = new Vector3(0, 1);
                dirRight = new Vector3(0, -1);
                break;

        }
    }
    void Rotate()
    {
        switch (timesPressed)
        {
            case 0:
                Physics2D.gravity = new Vector2(0, baseGravity);
                cam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                foreach (GameObject item in rocks)
                {
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                    
                }
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                groundCheck.transform.position = transform.position + new Vector3(0, -0.5f);
                break;
            case 1:
                Physics2D.gravity = new Vector2(baseGravity, 0);
                cam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                foreach (GameObject item in rocks)
                {
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation| RigidbodyConstraints2D.FreezePositionY;
                    
                }
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                groundCheck.transform.position = transform.position + new Vector3(-0.5f,0);
                break;
            case 2:
                Physics2D.gravity = new Vector2(0, -baseGravity);
                cam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                foreach (GameObject item in rocks)
                {
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                    
                }
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                groundCheck.transform.position = transform.position + new Vector3(0, 0.5f);
                break;
            case 3:
                Physics2D.gravity = new Vector2(-baseGravity, 0);
                cam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                foreach (GameObject item in rocks)
                {
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    item.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                    
                }
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                groundCheck.transform.position = transform.position + new Vector3(0.5f, 0);
                break;
            default:
                break;
        }
    }
    
}
