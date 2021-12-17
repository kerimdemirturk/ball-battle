using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyRb;
    public GameObject playerposition;//player position a ihtiyacýmýz var bu sebeple böyle bir deðiþken oluþturup bunu playera eþitliyoruz.
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerposition = GameObject.Find("Player");//player'a ulaþdýk.
    }

   
    void Update()
    {
        
        enemyRb.AddForce((playerposition.transform.position - transform.position).normalized * speed);//amacýmýz enemyinin player'a sürekli biçimde gelip ona vurmaya çalýþmasý bu sebeple playerýnýn pozisyonundan-
                                                                                                      //enemynin pozisyonunu çýkarýyoruz ve vector 3 ümüz bu olucakyani enemy sürekli buraya gelmeye çabalýcak.Bu nokdada-
                                                                                                      //normalize yöntemi enemy playerden örneðin çok uzaklaþýrsa bizim verdiðimiz  hýzýn üstüne çýkýcak çünkü amacý belirlenen vecctor 3 e gitmek ama-
                                                                                                      //normalize yazdýðýmýzda hep sabit hýzla agelmeye çalýþcak.
        
        

        if(transform.position.y<-10)//enemy ler aþaðý düþdüklerinde platformdan yok olsunlar.
        {
            Destroy(gameObject);
        }


    }
}
