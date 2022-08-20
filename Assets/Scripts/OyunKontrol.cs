using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject gokyuzuBir;
    public GameObject gokyuzuIki;
    public float ArkaPlanHiz = 1.5f;
    public GameObject engel;
    public int kacAdetEngel;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;

    GameObject[] engeller;
    float Uzunluk = 0;
    float degisimzaman = 0;
    int sayac = 0;

    void Start()
    {
        fizikBir = gokyuzuBir.GetComponent<Rigidbody2D>();
        fizikIki = gokyuzuIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(-ArkaPlanHiz, 0);
        fizikIki.velocity = new Vector2(-ArkaPlanHiz, 0);

        Uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;

        Debug.Log(Uzunluk);

        engeller = new GameObject[kacAdetEngel];

        for (int i = 0; i < engeller.Length;i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, 20),Quaternion.identity);
            Rigidbody2D fizikengel = engeller[i].AddComponent<Rigidbody2D>();   // Daha önceden hep Getcomponent yapýyorduk bunuda görmemiz için bir örnek olarak addcomponent diyerek bir rigidbody2D ekledik.
            fizikengel.gravityScale = 0;
            fizikengel.velocity = new Vector2(-ArkaPlanHiz,0);
        }
    }

    void Update()
    {
        if (gokyuzuBir.transform.position.x <= -Uzunluk)
        {
            gokyuzuBir.transform.position += new Vector3(Uzunluk * 2, 0);
        }
        if (gokyuzuIki.transform.position.x <= -Uzunluk)
        {
            gokyuzuIki.transform.position += new Vector3(Uzunluk * 2, 0);
        }


        //-------------------------------------------------------------------------------

        degisimzaman += Time.deltaTime;
        if (degisimzaman>2f)
        {
            degisimzaman = 0;
            float Yekseni = Random.Range(1.75f, 2.90f);  // Y ekseni sýnýrlarýný ayarladýk.
            engeller[sayac].transform.position = new Vector3(9.38f, Yekseni); // konumunu ayarlýyoruz
            sayac++;

            if (sayac>=engeller.Length)
            {
                sayac = 0;
            }
        }

    }
    public void oyunbitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
    }
}
