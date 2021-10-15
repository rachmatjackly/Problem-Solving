using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallControll : MonoBehaviour
{
      // Rigidbody bola
    private Rigidbody2D rigidBody;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    // Tombol untuk menggerakkan ke atas
    public KeyCode upButton = KeyCode.W;
 
    // Tombol untuk menggerakkan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Tombol untuk menggerakkan ke kiri
    public KeyCode leftButton = KeyCode.A;
 
    // Tombol untuk menggerakkan ke kanan
    public KeyCode rightButton = KeyCode.D;
 
    // Kecepatan gerak
    public float speed = 5.0f;

    

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidBody.velocity = Vector2.zero;
    }

    
    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
 
        // Mulai game
        RestartGame();
    }

    void Update()
    {
        // Problem 4
        Vector2 velocity = rigidBody.velocity;

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
 
        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        else if (Input.GetKey(leftButton))
        {
            velocity.x = -speed;
        }

        else if (Input.GetKey(rightButton))
        {
            velocity.x = speed;
        }
 
        // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else
        {
            velocity.y = 0.0f;
        }
 
        // Masukkan kembali kecepatannya ke rigidBody2D.
        rigidBody.velocity = velocity;
    }
}
