using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{

    public int viata = 1;
    public int currentLife = 0;
    public GameObject upgrade;
    public GameObject Player;

    void Start()
    {
        currentLife = viata;
    }

    public void TakeDamage(int a)
    {
          currentLife -= a;

            if (currentLife <= 0)
            {
                Die();
            }
    } 

    public void Die()
    {
        
        Destroy(this.gameObject);

    }
}
