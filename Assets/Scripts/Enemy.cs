using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyRb;
    public GameObject playerposition;//player position a ihtiyac�m�z var bu sebeple b�yle bir de�i�ken olu�turup bunu playera e�itliyoruz.
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerposition = GameObject.Find("Player");//player'a ula�d�k.
    }

   
    void Update()
    {
        
        enemyRb.AddForce((playerposition.transform.position - transform.position).normalized * speed);//amac�m�z enemyinin player'a s�rekli bi�imde gelip ona vurmaya �al��mas� bu sebeple player�n�n pozisyonundan-
                                                                                                      //enemynin pozisyonunu ��kar�yoruz ve vector 3 �m�z bu olucakyani enemy s�rekli buraya gelmeye �abal�cak.Bu nokdada-
                                                                                                      //normalize y�ntemi enemy playerden �rne�in �ok uzakla��rsa bizim verdi�imiz  h�z�n �st�ne ��k�cak ��nk� amac� belirlenen vecctor 3 e gitmek ama-
                                                                                                      //normalize yazd���m�zda hep sabit h�zla agelmeye �al��cak.
        
        

        if(transform.position.y<-10)//enemy ler a�a�� d��d�klerinde platformdan yok olsunlar.
        {
            Destroy(gameObject);
        }


    }
}
