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
    
    public LayerMask delimitations;
    bool hitFloor;
    // Start is called before the first frame update
    void Start()
    {
        Spread();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spread()
    {
        for (var i = 0; i < roomSize; i++)
        {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, -(i), 0f), .2f, delimitations) && !hitFloor)
            {
                Debug.Log("space down");
                GameObject waterClone = Instantiate(waterCubePrefab,transform.position+new Vector3(0,-(i),0),Quaternion.identity);
                waterClones.Add(waterClone); 
            }
            else
            {  
                hitFloor = true;
            }
            if (Physics2D.OverlapCircle(transform.position + new Vector3(0, -(i+1), 0f), .2f, delimitations) && !hitFloor)
            {
                for (int j = 0; j < spreadRange; j++)
                {
                   GameObject waterSideClone = Instantiate(waterSourcePrefab,transform.position + new Vector3(j+1,-(i),0),Quaternion.identity);
                   waterClones.Add(waterSideClone);
                   GameObject waterSideClone1 = Instantiate(waterSourcePrefab,transform.position + new Vector3(-(j+1),-(i),0),Quaternion.identity); 
                   waterClones.Add(waterSideClone1);
                }
                
            }
        }
        
    }
}
