using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;//spawn edice�imiz neseneyi tan�mlay�p inspectorde tan�ml�caz.
    private float spawnRange = 9;//haritada nokda belirledik bu a�a��daki i�lemleri kolayla�t�r�cak.
    public int enemyCount;//amac�m�z platormdaki enemyler bitince yenisini eklemek bu y�zden bu variabl� olu�turduk a�a��da i�lemlerini edicez.
    public int waveNumber;//her wave  de enemy say�s� bir bir artarrak devam etsin istiyoruz.Onun i�in bunu olu�turduk a�a��da i�lemler var.
    public GameObject powerUpPrefab;
    void Start()
    {


        Instantiate(powerUpPrefab, generateSpawnPosition(), powerUpPrefab.transform.rotation);//yeni power uplar �retilmesi i�in random bi�imde
        spawnEnemyWave(waveNumber);//a�a��daki paremetreyi kullnarak i�ine rakam yazabildim.

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//ffind object bir method ve sahnedeki enemylere ula�mam�z� sa�lad� ayn� zamdna enght yazarak onalar�n say�s�na e�itledil count umuzu
        if(enemyCount==0)//yukarudak� e�itleme sayesinde sahnedeki enemy bitti�inde sahneye bir adet enemy daah gelicek.
        {
            waveNumber++;//vave number bir atraarak devam edicek.
            spawnEnemyWave(waveNumber);//a�a��daki for da �retilen spawn burada bir bir artacak paremetremizi wave ettik.
            Instantiate(powerUpPrefab, generateSpawnPosition(), powerUpPrefab.transform.rotation);//b�ylece her yeni dalgada yeni power up �retilecek.
        }
    }

    private Vector3 generateSpawnPosition()//spawn edilme i�lemleri i�in bu methodumuzu olu�turduk.
    {
        float spawnPozX = Random.Range(-spawnRange, spawnRange);//x de spawn olabilecepi yerler -9 ve 9 aras�.Rndom.range bu i�e yarar.
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);//z i�in yukar�dakinin ayn�s�.
        Vector3 randomPosition = new Vector3(spawnPozX, 0, spawnPosZ);//�nstantinate de gereeken vector 3 konumunu burada belirledik.

        return randomPosition;//bunu d�nd�r�cek method i�inde 
    }
    void spawnEnemyWave(int enemiesToSpawn)//spawn etmek i�in dalga dalga olmas� i�in method yazd�k ve i�ine for koyduk.--paremetrenin amac� da ka� adet spawn edilsin onu basit�e  belirlemek startta i�eri yaz�nca.
    {
        for(int i=1; i<=enemiesToSpawn; i++)//paremetremizi kullland�k for un i�inde ��nk� belirledi�imiz kadar olsun istiyoruz spawn say�s�
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);//spawn eden method bu-3 paremetere al�yor.1)spawn edilceek nesne.2-spawn edilcek vecto3 konumu.3-objenin rotasyounu
        }
    }

}
