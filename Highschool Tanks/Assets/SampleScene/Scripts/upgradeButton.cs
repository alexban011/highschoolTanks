using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeButton : MonoBehaviour
{
    public GameObject upgradeStage2;
    public GameObject upgradeStage3;

    public GameObject usaLevel2;
    public GameObject usaLevel3;

    public GameObject Player;
    public int nrStageTerminat = 0;

    public GameObject pozeLevel2;
    public GameObject pozeLevel3;

    public int numarUpgrade = 1;

    public void upgarde()
    {
        if (numarUpgrade == 1 && nrStageTerminat == 1)
        {
            numarUpgrade++;
            UpgradeStage2();
        }
        if (numarUpgrade == 2 && nrStageTerminat == 2)
        {
            numarUpgrade++;
            UpgradeStage3();
        }
    }

    private void UpgradeStage2()
    {
        //rb.bodyType.ToString("Dynamic");
        //this.gameObject.SetActive(false);
        if (Player.GetComponent<collect_stuff>().a >= 10)
        {
            Player.GetComponent<collect_stuff>().a -= 10;

            upgradeStage2.SetActive(true);
            upgradeStage2.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

            Destroy(Player);

            pozeLevel2.SetActive(false);
            pozeLevel3.SetActive(true);

            Destroy(usaLevel2);
            //Destroy(this.gameObject);
        }

    }

    private void UpgradeStage3()
    {
        //rb.bodyType.ToString("Dynamic");
        //this.gameObject.SetActive(false);
        upgradeStage3.SetActive(true);
        upgradeStage3.transform.position = new Vector3(upgradeStage2.transform.position.x, upgradeStage2.transform.position.y, upgradeStage2.transform.position.z);

        Destroy(upgradeStage2);
        //upgradeStage2.SetActive(false);

        Destroy(usaLevel3);

        pozeLevel3.SetActive(false);
        //Destroy(this.gameObject);

    }
}
