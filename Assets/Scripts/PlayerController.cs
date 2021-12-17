using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody rb;
    public float forwardInput;
    public float horizontalInput;
    public GameObject focalPoint;//kameranýn hareketi ile topu x de harelet ettircez
    public bool hasPowerUp;
    public float powerUpStrenght;//enemy i uygulanacak þiddet
    public GameObject powerUpIndýcator;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");//kameraya ulaþdýk
        
    }

    
    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

        rb.AddForce(Vector3.forward*forwardInput * playerSpeed);
        rb.AddForce(Vector3.right * horizontalInput * playerSpeed);
        powerUpIndýcator.transform.position = transform.position + new Vector3(0,-0.5f, 0);//ýndýcator playarýn altýnda gözüksün diye pozisyonunu playera eþitledik.birde offset koyduk altta olsun diye.
        
    }
    //power up alma algoritmasý
    private void OnTriggerEnter(Collider other)//on trigger kullanmak böyle þeylerde daha mantýklý
    {
        if (other.CompareTag("PowerUp"))//eðer player tagý powerup olan birþeyle karþýlaþýrsa
        {
            hasPowerUp = true;//bunu true ya çevir.yukarýda tanýmladýk.
            Destroy(other.gameObject);//poweer up ý yok et.çünkü aldýk artýk görünmesin.
            StartCoroutine(PowerUpCountDownRoutine());//aþaðýda oluþturudpumuz zaman methodu power up için baþlýyýr.startcourutine bu iþe yarýyor.
            powerUpIndýcator.gameObject.SetActive(true);//power up adlýðýmýzda ortaya çýkan ýndýcator ü aktif edip gözükmesini saðlýyoruz

        }

    }
    IEnumerator PowerUpCountDownRoutine()//poweer up'ý aldýðýmýzda belirli bir saniye sonra power up ýn yok olmasýný istiyoruz.Çünkü hep durursa mantýksýz olur. 
    {
        yield return new WaitForSeconds(6);//6saniye sahip olma süresi power up a
        hasPowerUp = false;//ardýndan false olup powerup kapanýyor.
        powerUpIndýcator.gameObject.SetActive(false); //ýndýcator 6 saniye bitince kapanýcak.
        
            

    }
    //power up aldýðýmýzda enemyye daha çok güç uyullama algoritmasý-yani power up almýþolma koþulu  var ve enemy ile çarpýþcaz.
    private void OnCollisionEnter(Collision collision)//fizikle birþey edilirken oncollisionenter çok daha iyi bir methoddur.
    {
        if(collision.gameObject.CompareTag("Enemy")&&hasPowerUp)//playerýmýz enemy tagý ile çarpýþdýðýnda ve eðer haspowerup true ise yani power up almýþsak
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();//enemy rigidbodye ulaþdýk.
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;//çarpýþdýðýnda enemynin gidiceði yeri belirledik.çarpýþýlan yer den current positionu çýkararak.
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);//çarpýþýldýðýnda enemyiye uygulanacak kuvvet bu.O kadar uzaða gitmesini saðlýcaz yani.
            Debug.Log("collided with" + collision.gameObject.name + "with powerup set to" + hasPowerUp);  
        }
    }
}
