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
        transform.Rotate(Vector3.up,horizontalInput * rotateSpeed * Time.deltaTime);//kameran�n arrow keylere g�re hareeketi i�in yazd�k bunu.vector3.up dan sonra virg�l koumam�z�n sebebi o vectorde sabit dursun diye �arparak daha da yukar� ��ks�n istemiyoruz.
    }
}
