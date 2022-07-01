using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect_stuff : MonoBehaviour
{
    [SerializeField]
    public Text Money_text, upgrade;
    public GameObject tower;
    public GameObject ecranJocTerminat;

    public GameObject tancLv3;
    public int a = 0;
    void Update()
    {
        Money_text.text = "Cheite: " + a;
        upgrade.text = "Cheite necesare: " + a + " / 10";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Cheite_script>())
        {
            a++;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Cheie_final>())
        {
            ecranJocTerminat.SetActive(true);
            Destroy(collision.gameObject);
            tancLv3.GetComponent<PlayerStats>().PlayCongrats();
        }
        if (collision.GetComponent<Munitie>())
        {
            if (tower.GetComponent<Shooting>().bullets < tower.GetComponent<Shooting>().maxBullets)
            {
                tower.GetComponent<Shooting>().bullets += 10;
                if(tower.GetComponent<Shooting>().bullets > tower.GetComponent<Shooting>().maxBullets)
                {
                    tower.GetComponent<Shooting>().bullets = tower.GetComponent<Shooting>().maxBullets;
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
