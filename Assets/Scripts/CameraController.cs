using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;

    private float tamaņoCamara;
    private float alturaPantalla; 
    // Start is called before the first frame update
    void Start()
    {
        //tamaņoCamara = Camera.main.ortographicSize;
        //alturaPantalla = tamaņoCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        float ypromedio = (personaje.position.y / 2);
        Debug.Log(ypromedio);
        Vector3 newPosition = new Vector3(personaje.position.x, personaje.position.y - ypromedio, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 2f);
    }
}
