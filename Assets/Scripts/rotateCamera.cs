using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float rotateSpeed;
    public float horizontalInput;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up,horizontalInput * rotateSpeed * Time.deltaTime);//kameranýn arrow keylere göre hareeketi için yazdýk bunu.vector3.up dan sonra virgül koumamýzýn sebebi o vectorde sabit dursun diye çarparak daha da yukarý çýksýn istemiyoruz.
    }
}
