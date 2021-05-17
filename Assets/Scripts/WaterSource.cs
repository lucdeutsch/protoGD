using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    public GameObject waterCubePrefab;
    public GameObject waterSourcePrefab;
    List<GameObject> waterClones = new List<GameObject>();
    public int roomSize = 10;
    public int spreadRange = 1;
    RotateLevel rotateRef;
    public LayerMask delimitations;
    bool hitFloor;
    public Animator animator;
    public bool canRefresh;

    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rotateRef = FindObjectOfType<RotateLevel>();

        RotateLevel.Rotate += ResetSpread;
        RotateLevel.RotateOver += Spread;
        Spread();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canRefresh)
        {
            Refresh();
        }
    }
    public void Refresh()
    {
        ResetSpread();
        Spread();
    }

    private void OnDestroy() {
        ResetSpread();
    }

    public void Spread()
    {
        if (activated && this != null)
        {
            animator.enabled = true;


            for (var i = 1; i < roomSize; i++)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, -(i), 0f), .2f, delimitations) && !hitFloor)
                {

                    GameObject waterClone = Instantiate(waterCubePrefab, transform.position + new Vector3(0, -(i), 0), Quaternion.identity);
                    waterClone.name = "Clone " + i.ToString();
                    waterClones.Add(waterClone);

                }
                else
                {
                    hitFloor = true;
                }
                if (Physics2D.OverlapCircle(transform.position + new Vector3(0, -(i + 1), 0f), .2f, delimitations) && !hitFloor)
                {
                    for (int j = 0; j < spreadRange; j++)
                    {
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(j + 1, -(i), 0f), .2f, delimitations))
                        {
                            GameObject waterSideClone = Instantiate(waterSourcePrefab, transform.position + new Vector3(j + 1, -(i), 0), Quaternion.identity);
                            waterClones.Add(waterSideClone);

                        }
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(-(j + 1), -(i), 0f), .2f, delimitations))
                        {
                            GameObject waterSideClone1 = Instantiate(waterSourcePrefab, transform.position + new Vector3(-(j + 1), -(i), 0), Quaternion.identity);
                            waterClones.Add(waterSideClone1);

                        }

                    }

                }
            }
            hitFloor = false;
        }


    }

    public void ResetSpread()
    {

        if (animator != null)
        {
            animator.enabled = false;
        }

        for (int i = 0; i < waterClones.Count; i++)
        {
            Destroy(waterClones[i]);
        }
    }
}
