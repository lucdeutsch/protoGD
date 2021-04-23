using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushElements : MonoBehaviour
{
    public Transform leftCheck;
    public Transform rightCheck;
    public LayerMask propsLayer;
    public float checkRadius;
    Collider2D currentEllementLeft;
    Collider2D currentEllementRight;
    public GameObject leftObject;
    public GameObject rightObject;
    PlayerController player;

    public bool isLeft;
    public bool isRight;
    Vector3 leftPush;
    Vector3 rightPush;
    int timesPressed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timesPressed = player.timesPressed;
        isLeft = Physics2D.OverlapCircle(leftCheck.position, checkRadius, propsLayer);
        currentEllementLeft = Physics2D.OverlapCircle(leftCheck.position, checkRadius, propsLayer);
        isRight = Physics2D.OverlapCircle(rightCheck.position, checkRadius, propsLayer);
        currentEllementRight = Physics2D.OverlapCircle(rightCheck.position, checkRadius, propsLayer);

        if (isLeft)
        {
            leftObject = currentEllementLeft.gameObject;
            if (Input.GetKeyDown(KeyCode.Q) && !player.isMoving && leftObject.GetComponent<DetectWalls>().canMoveLeft)
            {
                leftObject.transform.position += leftPush;
                //leftObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(leftObject.transform.position.x - 1, leftObject.transform.position.y));
            }
            else if (Input.GetKeyDown(KeyCode.Q) && !player.isMoving && !leftObject.GetComponent<DetectWalls>().canMoveLeft)
            {
                player.GetComponent<DetectWalls>().canMoveLeft = false;
            }
        }
        if (isRight)
        {
            rightObject = currentEllementRight.gameObject;
            if (Input.GetKeyDown(KeyCode.D) && !player.isMoving && leftObject.GetComponent<DetectWalls>().canMoveRight)
            {
                rightObject.transform.position += rightPush;
                //rightObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(rightObject.transform.position.x + 1, rightObject.transform.position.y));
            }
            else if (Input.GetKeyDown(KeyCode.D) && !player.isMoving && !leftObject.GetComponent<DetectWalls>().canMoveRight)
            {
                player.GetComponent<DetectWalls>().canMoveRight = false;
            }
        }



        switch (timesPressed)
        {
            case 0:
                leftPush = new Vector3(-1, 0);
                rightPush = new Vector3(1, 0);
                break;
            case 1:
                leftPush = new Vector3(0, 1);
                rightPush = new Vector3(0, -1);
                break;
            case 2:
                leftPush = new Vector3(1, 0);
                rightPush = new Vector3(-1, 0);
                break;
            case 3:
                leftPush = new Vector3(0, -1);
                rightPush = new Vector3(0, 1);
                break;

        }

    }
    

}
