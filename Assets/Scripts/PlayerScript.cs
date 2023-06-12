using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    bool isJump = false; 
    bool canJump = true;

    public Rigidbody2D rb;
    public float velocidad;
    public float salto;
    public float waitJump;
    public AudioManager audioManager;
    public AudioClip sonidoSalto;

    public void clickLeft()
    {
        isLeft = true;
    } 
    public void releaseLeft()
    {
        isLeft = false;
    } 
    public void clickRight()
    {
        isRight = true;
    }
    public void releaseRight()
    {
        isRight = false;
    }

    public void ClickJump()
    {
        isJump = true;
    }

    private void FixedUpdate()
    {
        if (isLeft) 
        {
            rb.AddForce(new Vector2(-velocidad, 0) * Time.deltaTime);
        }
        if (isRight)
        {
            rb.AddForce(new Vector2(velocidad, 0) * Time.deltaTime);
        }
        if (isJump && canJump)
        {
            isJump = false;
            rb.AddForce(new Vector2(0, salto));
            canJump = false;
            Invoke("waitToJump", waitJump);
            audioManager.ReproducirSonido(sonidoSalto);
        }
    }
    void waitToJump()
    {
        canJump = true;
    }
}