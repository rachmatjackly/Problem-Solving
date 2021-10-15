using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
      // Rigidbody bola
    private Rigidbody2D rigidBody;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidBody.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
 
        // Mulai game
        RestartGame();
    }
}
