using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerJoc : MonoBehaviour
{
    public void IncearcaDinNou()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void InchideJocul()
    {
        Application.Quit();
    }
}
