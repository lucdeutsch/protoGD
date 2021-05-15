using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject winText;
    public GameObject winPanel;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("xD");
            Win();
        }
    }


    void Win()
    {
        winText.SetActive(true);
        StartCoroutine(winPanelApparition());
    }

    IEnumerator winPanelApparition()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        winText.SetActive(false);
        winPanel.SetActive(true);
    }
}
