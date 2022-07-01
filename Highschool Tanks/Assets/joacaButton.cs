using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class joacaButton : MonoBehaviour
{
    public void IncarcaJocul()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void InchideJocul()
    {
        Application.Quit();
    }
}
