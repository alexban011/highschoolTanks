using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close_Upgrade : MonoBehaviour
{
    public GameObject Upgrade_panel;
    public GameObject tank;
    public GameObject Tower;
    public SpriteRenderer turela;
    public SpriteRenderer turela1;
    public string KeyOpenPanel;
    //public GameObject 

    void Update()
    {
        if (Input.GetKeyDown(KeyOpenPanel))
        {
            Upgrade_panel.SetActive(true);
            Tower.GetComponent<Shooting>().enabled = false;
        }

    }

    public void upgrade()
    {
        int t = 2;
        if (tank.GetComponent<Collect_Money>().a >= t)
        {
            turela.sprite = turela1.sprite;
            tank.GetComponent<Collect_Money>().a = tank.GetComponent<Collect_Money>().a - 2;
            tank.GetComponent<BulletDamage>().attackDamage = tank.GetComponent<BulletDamage>().attackDamage + 50;
            tank.GetComponentInChildren<Shooting>().bullets = tank.GetComponentInChildren<Shooting>().bullets + 20;
            t = 999999;
        }
    }

    public void Open()
    {
        Upgrade_panel.SetActive(true);
    }

    public void Close()
    {
        Upgrade_panel.SetActive(false);
        Tower.GetComponent<Shooting>().enabled = true;
    }

    public void CloseApplicaton()
    {
        Application.Quit();
    }
}
