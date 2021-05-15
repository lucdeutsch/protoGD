using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour
{
    public GameObject mainGroup;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


    public void SelectLevel(GameObject SelectGroup)
    {
        SelectGroup.SetActive(true);
        mainGroup.SetActive(false);
        
    }

    public void SpecificLevelPicker(int Level)
    {
        SceneManager.LoadScene(Level);
        Time.timeScale = 1;
    }
    
    public void SelectLevelReturn(GameObject SelectGroup)
    {
        mainGroup.SetActive(true);
        SelectGroup.SetActive(false);
    }
}
