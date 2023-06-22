using UnityEngine;
using System.Collections;


public class PlataformaMovil : MonoBehaviour
{
    public Transform puntoA; // Punto de inicio de la plataforma
    public Transform puntoB; // Punto de destino de la plataforma
    public float velocidad = 1f; // Velocidad de movimiento de la plataforma

    private bool moviendoseHaciaPuntoB = false;

    void Start()
    {
        StartCoroutine(MoverPlataforma());
    }

    IEnumerator MoverPlataforma()
    {
        while (true)
        {
            Vector3 targetPosition = moviendoseHaciaPuntoB ? puntoB.position : puntoA.position;
            float distancia = Vector3.Distance(transform.position, targetPosition);

            while (distancia > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidad * Time.deltaTime);
                distancia = Vector3.Distance(transform.position, targetPosition);
                yield return null;
            }

            yield return new WaitForSeconds(1f); // Espera de 1 segundo antes de invertir la dirección

            moviendoseHaciaPuntoB = !moviendoseHaciaPuntoB;
        }
    }
}
