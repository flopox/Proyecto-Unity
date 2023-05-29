using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;

    private float tamañoCamara;
    private float alturaPantalla; 
    // Start is called before the first frame update
    void Start()
    {
        //tamañoCamara = Camera.main.ortographicSize;
        //alturaPantalla = tamañoCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        float ypromedio = (personaje.position.x / 1000000);
        Vector3 newPosition = new Vector3(personaje.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 2f);
    }
}
