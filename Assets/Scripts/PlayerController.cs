using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody rb;
    public float forwardInput;
    public float horizontalInput;
    public GameObject focalPoint;//kameran�n hareketi ile topu x de harelet ettircez
    public bool hasPowerUp;
    public float powerUpStrenght;//enemy i uygulanacak �iddet
    public GameObject powerUpInd�cator;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");//kameraya ula�d�k
        
    }

    
    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

        rb.AddForce(Vector3.forward*forwardInput * playerSpeed);
        rb.AddForce(Vector3.right * horizontalInput * playerSpeed);
        powerUpInd�cator.transform.position = transform.position + new Vector3(0,-0.5f, 0);//�nd�cator playar�n alt�nda g�z�ks�n diye pozisyonunu playera e�itledik.birde offset koyduk altta olsun diye.
        
    }
    //power up alma algoritmas�
    private void OnTriggerEnter(Collider other)//on trigger kullanmak b�yle �eylerde daha mant�kl�
    {
        if (other.CompareTag("PowerUp"))//e�er player tag� powerup olan bir�eyle kar��la��rsa
        {
            hasPowerUp = true;//bunu true ya �evir.yukar�da tan�mlad�k.
            Destroy(other.gameObject);//poweer up � yok et.��nk� ald�k art�k g�r�nmesin.
            StartCoroutine(PowerUpCountDownRoutine());//a�a��da olu�turudpumuz zaman methodu power up i�in ba�l�y�r.startcourutine bu i�e yar�yor.
            powerUpInd�cator.gameObject.SetActive(true);//power up adl���m�zda ortaya ��kan �nd�cator � aktif edip g�z�kmesini sa�l�yoruz

        }

    }
    IEnumerator PowerUpCountDownRoutine()//poweer up'� ald���m�zda belirli bir saniye sonra power up �n yok olmas�n� istiyoruz.��nk� hep durursa mant�ks�z olur. 
    {
        yield return new WaitForSeconds(6);//6saniye sahip olma s�resi power up a
        hasPowerUp = false;//ard�ndan false olup powerup kapan�yor.
        powerUpInd�cator.gameObject.SetActive(false); //�nd�cator 6 saniye bitince kapan�cak.
        
            

    }
    //power up ald���m�zda enemyye daha �ok g�� uyullama algoritmas�-yani power up alm��olma ko�ulu  var ve enemy ile �arp��caz.
    private void OnCollisionEnter(Collision collision)//fizikle bir�ey edilirken oncollisionenter �ok daha iyi bir methoddur.
    {
        if(collision.gameObject.CompareTag("Enemy")&&hasPowerUp)//player�m�z enemy tag� ile �arp��d���nda ve e�er haspowerup true ise yani power up alm��sak
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();//enemy rigidbodye ula�d�k.
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;//�arp��d���nda enemynin gidice�i yeri belirledik.�arp���lan yer den current positionu ��kararak.
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);//�arp���ld���nda enemyiye uygulanacak kuvvet bu.O kadar uza�a gitmesini sa�l�caz yani.
            Debug.Log("collided with" + collision.gameObject.name + "with powerup set to" + hasPowerUp);  
        }
    }
}
