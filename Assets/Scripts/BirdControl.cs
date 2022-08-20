using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdControl : MonoBehaviour
{

    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ForwardAndBackward = true;
    int KusSayac = 0;
    float KusAnimasyonZaman = 0;
    Rigidbody2D Fizik;
    int puan = 0;
    public Text puanText;
    bool oyunbitti = true;
    OyunKontrol OyunKontrol;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Fizik = GetComponent<Rigidbody2D>();
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& oyunbitti )
        {
            Fizik.velocity = new Vector2(0,0); // Hizi Sifirladik
            Fizik.AddForce(new Vector2(0,200)); // Ondan Sonra Kuvvet Uyguladik
        }

        if (Fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }


        Animasyon();
    }

    void Animasyon()
    {
        KusAnimasyonZaman += Time.deltaTime;
        if (KusAnimasyonZaman > 0.2f)
        {
            KusAnimasyonZaman = 0;

            if (ForwardAndBackward)
            {
                spriteRenderer.sprite = KusSprite[KusSayac];
                KusSayac++;
                if (KusSayac == KusSprite.Length)
                {
                    KusSayac--;
                    ForwardAndBackward = false;
                }
            }
            else
            {
                KusSayac--;
                spriteRenderer.sprite = KusSprite[KusSayac];
                if (KusSayac == 0)
                {
                    KusSayac++;
                    ForwardAndBackward = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Puan")
        {
            puan++;
            puanText.text = "Puan = " + puan;
            Debug.Log(puan);
        }
        if (col.gameObject.tag=="Engel")
        {
            oyunbitti = false;
            OyunKontrol.oyunbitti();
        }
    }
}
