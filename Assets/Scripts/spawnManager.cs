using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;//spawn ediceðimiz neseneyi tanýmlayýp inspectorde tanýmlýcaz.
    private float spawnRange = 9;//haritada nokda belirledik bu aþaðýdaki iþlemleri kolaylaþtýrýcak.
    public int enemyCount;//amacýmýz platormdaki enemyler bitince yenisini eklemek bu yüzden bu variablý oluþturduk aþaðýda iþlemlerini edicez.
    public int waveNumber;//her wave  de enemy sayýsý bir bir artarrak devam etsin istiyoruz.Onun için bunu oluþturduk aþaðýda iþlemler var.
    public GameObject powerUpPrefab;
    void Start()
    {


        Instantiate(powerUpPrefab, generateSpawnPosition(), powerUpPrefab.transform.rotation);//yeni power uplar üretilmesi için random biçimde
        spawnEnemyWave(waveNumber);//aþaðýdaki paremetreyi kullnarak içine rakam yazabildim.

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//ffind object bir method ve sahnedeki enemylere ulaþmamýzý saðladý ayný zamdna enght yazarak onalarýn sayýsýna eþitledil count umuzu
        if(enemyCount==0)//yukarudakþ eþitleme sayesinde sahnedeki enemy bittiðinde sahneye bir adet enemy daah gelicek.
        {
            waveNumber++;//vave number bir atraarak devam edicek.
            spawnEnemyWave(waveNumber);//aþaðýdaki for da üretilen spawn burada bir bir artacak paremetremizi wave ettik.
            Instantiate(powerUpPrefab, generateSpawnPosition(), powerUpPrefab.transform.rotation);//böylece her yeni dalgada yeni power up üretilecek.
        }
    }

    private Vector3 generateSpawnPosition()//spawn edilme iþlemleri için bu methodumuzu oluþturduk.
    {
        float spawnPozX = Random.Range(-spawnRange, spawnRange);//x de spawn olabilecepi yerler -9 ve 9 arasý.Rndom.range bu iþe yarar.
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);//z için yukarýdakinin aynýsý.
        Vector3 randomPosition = new Vector3(spawnPozX, 0, spawnPosZ);//ýnstantinate de gereeken vector 3 konumunu burada belirledik.

        return randomPosition;//bunu döndürücek method içinde 
    }
    void spawnEnemyWave(int enemiesToSpawn)//spawn etmek için dalga dalga olmasý için method yazdýk ve içine for koyduk.--paremetrenin amacý da kaç adet spawn edilsin onu basitçe  belirlemek startta içeri yazýnca.
    {
        for(int i=1; i<=enemiesToSpawn; i++)//paremetremizi kulllandýk for un içinde çünkü belirlediðimiz kadar olsun istiyoruz spawn sayýsý
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);//spawn eden method bu-3 paremetere alýyor.1)spawn edilceek nesne.2-spawn edilcek vecto3 konumu.3-objenin rotasyounu
        }
    }

}
