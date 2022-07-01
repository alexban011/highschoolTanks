using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageTerminat : MonoBehaviour
{
    public Collider2D col;
    public upgradeButton scriptUpgradeButton;
    public int numarStageTerminat = 1;


    public void OnTriggerEnter2D(Collider2D col)
    {
        scriptUpgradeButton.nrStageTerminat = numarStageTerminat;
    }
}
