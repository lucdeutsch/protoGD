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
    public LayerMask water;
    RotateLevel rotateRef;
    public bool floating;
    List<WaterSource> waterSources = new List<WaterSource>();

    public enum Type
    {
        Rock,
        Wood
    }

    public Type objectType;

    // Start is called before the first frame update
    void Start()
    {
        foreach (WaterSource item in FindObjectsOfType<WaterSource>())
        {
            waterSources.Add(item);
        }
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
            if (transform.position == movePoint.position)
            {
                pushed = false;
            }
            if ((Physics2D.OverlapCircle(movePoint.position, .2f, water) || Physics2D.OverlapCircle(movePoint.position + new Vector3(0, -1, 0), .2f, water))&&objectType != Type.Rock)
            {
                
                floating = true;
            }
            else
            {
                floating = false;
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1, 0f), .2f, delimitations) && Mathf.Abs(movePoint.position.x - transform.position.x) <= .05f && !floating)
            {
                movePoint.position += new Vector3(0f, -1, 0f);
            }
        }


    }

    public void Push(Vector3 direction)
    {
        
        performed = false;
        dir = direction;
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, delimitations)||!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0f), .2f, delimitations))
        {
            movePoint.position += dir;
            performed = true;
        }
        foreach (WaterSource item in waterSources)
        {
            if (item.canRefresh)
            {
                StartCoroutine(autoRefresh(item));
            }
        }
    }

    IEnumerator autoRefresh(WaterSource waterSource)
    {
        yield return new WaitForSeconds(.2f);
        waterSource.Refresh();
    }
}
