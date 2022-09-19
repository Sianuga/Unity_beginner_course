using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle_movement paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] AudioClip[] ball_sounds;
    [SerializeField] float randomness_of_movement;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
 lockBallToPaddle();
            launchBall();
        }
           
    }
    private void launchBall()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            hasStarted = true;
            myRigidBody.velocity = new Vector2(xPush, yPush);
            
        }
    }
    private void lockBallToPaddle()
    {
Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomness_of_movement),Random.Range(0f,randomness_of_movement));
        AudioClip clip = ball_sounds[UnityEngine.Random.Range(0,ball_sounds.Length)];
        if(hasStarted)
        {
 myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
           
    }
}
