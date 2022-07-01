using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect_Money : MonoBehaviour
{
    [SerializeField]
    public Text Money_text;
    public int a = 0;
    void Update()
    {
        Money_text.text = "Money: " + a;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Money>())
        {
            a++;
            Destroy(collision.gameObject);
        }
    }
}