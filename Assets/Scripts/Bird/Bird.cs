using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rd2d;
    private Animator ani;
    [SerializeField]
    private float JumpBird = 4f;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip fly, dead;

    GameManager gm;

    bool isAlive;
    bool isFly;

    private void Awake()
    {
        isAlive = true;
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }
   
    private void FixedUpdate()
    {
        _JumpByMounce();
    }

    void _JumpByMounce()
    {
        if (isAlive)
        {
            if (isFly)
            {
                isFly = false;
                rd2d.velocity = new Vector2(rd2d.velocity.x, JumpBird);
                audioSource.PlayOneShot(fly);
            }
        }

        if (rd2d.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 45, rd2d.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (rd2d.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rd2d.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -45, -rd2d.velocity.y / 3);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void FlyButton()
    {
        isFly = true;
    }


    // va cham voi cot 
    private void OnTriggerEnter2D(Collider2D col)
    {      
        if (col.CompareTag("Score"))
        {
            gm.UpScore();
            Debug.Log("Up");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Dead") || col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Dead");
            audioSource.PlayOneShot(dead);
            ani.SetTrigger("Die");
            gm.GameOver();

        }
    }
   
}
