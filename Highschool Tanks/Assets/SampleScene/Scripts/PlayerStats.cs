using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float viata = 100;
    public float viataMaxPerTanc = 100;
    public float currentHealth = 0;
    public GameObject SliderViata;
    public Camera cam;
    public GameObject ecranMort;

    public AudioClip[] muzica;
    public AudioClip sunetExplozie;
    public AudioClip sunetImpuscare;
    public AudioClip sunetCongrats;
    public AudioSource sursaMuzica;
    public AudioSource sursaExplozie;
    public AudioSource sursaImpuscare;
    public AudioSource sursaCongrats;
    private int nrMelodie = 0;
    private int nrMelodieTrecuta = 0;
    private float timp = 190;


    void Start()
    {
        currentHealth = viata;
    }

    void PlayMuzica(int nrMuzica)
    {
        sursaMuzica.clip = muzica[nrMuzica];
        sursaMuzica.Play();
    }
    
    public void PlayExplozie()
    {
        sursaExplozie.clip = sunetExplozie;
        sursaExplozie.Play();
    }

    public void PlayImpuscare()
    {
        sursaImpuscare.clip = sunetImpuscare;
        sursaImpuscare.Play();
    }

    public void PlayCongrats()
    {
        sursaCongrats.clip = sunetCongrats;
        sursaCongrats.Play();
    }

    void Update()
    {
        SliderViata.transform.localScale = new Vector3((float)currentHealth / viataMaxPerTanc, 1, 1);

        //muzica
        if (timp >= 192)
        {
            nrMelodie = Random.Range(0, 4);
            while (nrMelodie == nrMelodieTrecuta)
            {
                nrMelodie = Random.Range(0, 4);
            }
            PlayMuzica((int)nrMelodie);
            timp = 0;
            nrMelodieTrecuta = nrMelodie;
        }
    }

    void FixedUpdate()
    {
        timp = timp + 0.02f;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ecranMort.SetActive(true);
        cam.transform.position = new Vector3(-8, -19, 6);
        //Destroy(this.gameObject);
        this.GetComponent<Tank>().enabled = false;
        this.GetComponent<Shooting>().enabled = false;
        this.enabled = false;
        
        
        ecranMort.SetActive(true);
    }
}
