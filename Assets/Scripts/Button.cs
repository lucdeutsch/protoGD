using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool pressed;
    public List<string> colliders = new List<string>();
    public WaterSource[] linkedSources;
    public GameObject[] Barrier;
    public Transform offset;
    public Vector3 basePos;
    public bool stayActive;

    private void Start()
    {
        basePos = transform.position;
        RotateLevel.RotateOver += RefreshPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (colliders.Contains(other.tag))
        {
            Press();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!stayActive)
        {
            if (colliders.Contains(other.tag))
            {
                ResetButton();
            }
        }


    }

    void RefreshPos()
    {
        if (this != null)
        {
            basePos = transform.position;
        }
        
    }

    void Press()
    {
        if (!pressed)
        {
            pressed = true;
            transform.position = offset.position;
            foreach (WaterSource item in linkedSources)
            {
                item.activated = true;
                item.Spread();
            }
            if (Barrier != null)
            {
                foreach (GameObject item in Barrier)
                {
                    item.SetActive(false);
                }

            }

        }
    }

    void ResetButton()
    {
        if (pressed)
        {
            pressed = false;
            transform.position = basePos;
            foreach (WaterSource item in linkedSources)
            {
                item.activated = false;
                item.ResetSpread();
            }
            if (Barrier != null)
            {
                foreach (GameObject item in Barrier)
                {
                    item.SetActive(true);
                }

            }

        }
    }


}
