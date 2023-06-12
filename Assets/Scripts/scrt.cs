using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt : MonoBehaviour
{
    public float velocidad;
    public float salto;
    public LayerMask capaSuelo;
    public AudioManager audioManager;
    public AudioClip sonidoSalto;
    public AudioClip sonidoMovimiento;

    private Rigidbody2D rigibody;
    private BoxCollider2D BoxCollider;
    private bool mirandoDerecha;

    private void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoH();
        SaltarY();
    }

    bool EstaEnElSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center, new Vector2(BoxCollider.bounds.size.x, BoxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void SaltarY()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnElSuelo())
        {
            rigibody.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            audioManager.ReproducirSonido(sonidoSalto);
        }
    }

    void MovimientoH()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            rigibody.velocity = new Vector2(inputMovimiento * velocidad, rigibody.velocity.y);

            Orientacion(inputMovimiento);

            audioManager.ReproducirSonido(sonidoMovimiento);
        }
    }

    void Orientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == false && inputMovimiento < 0) || (mirandoDerecha == true && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}