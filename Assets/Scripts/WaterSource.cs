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

    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        rotateRef = FindObjectOfType<RotateLevel>();

        RotateLevel.Rotate += ResetSpread;
        RotateLevel.RotateOver += Spread;
        Spread();

    }

    // Update is called once per frame


    public void Spread()
    {
        if (activated)
        {
            for (var i = 1; i < roomSize; i++)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, -(i), 0f), .2f, delimitations) && !hitFloor)
                {

                    GameObject waterClone = Instantiate(waterCubePrefab, transform.position + new Vector3(0, -(i), 0), Quaternion.identity);
                    waterClone.name = "Clone " + i.ToString();
                    waterClones.Add(waterClone);
                    waterClone.transform.parent = this.transform;
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
                            waterSideClone.transform.parent = this.transform;
                        }
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(-(j + 1), -(i), 0f), .2f, delimitations))
                        {
                            GameObject waterSideClone1 = Instantiate(waterSourcePrefab, transform.position + new Vector3(-(j + 1), -(i), 0), Quaternion.identity);
                            waterClones.Add(waterSideClone1);
                            waterSideClone1.transform.parent = this.transform;
                        }

                    }

                }
            }
            hitFloor = false;
        }


    }

    void ResetSpread()
    {
        for (int i = 0; i < waterClones.Count; i++)
        {
            Destroy(waterClones[i]);
        }
    }
}
