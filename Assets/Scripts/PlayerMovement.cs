using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_JumpForce;

    private bool m_FacingRight = true; 

    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;
    

    private bool m_OnGround = false;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float calculatedHorizontalInput = Input.GetAxis("Horizontal");

        Vector2 calculatedVelocity = m_Rigidbody.velocity;
        calculatedVelocity.x = calculatedHorizontalInput * m_Speed;
        m_Rigidbody.velocity = calculatedVelocity;

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && m_OnGround == true)
        {
            m_Rigidbody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
            m_OnGround = false;
        }

        if(calculatedVelocity.magnitude > 0)
        {
            m_Animator.SetBool("IsRunning", true);
        }
        else
        {
            m_Animator.SetBool("IsRunning", false);
        }

        if (m_Rigidbody.velocity.y >= Mathf.Epsilon)
        {
            gameObject.layer = 6;
        }
        else
        {
            gameObject.layer = 3;
        }

        if(m_SpriteRenderer.flipX = calculatedHorizontalInput < 0 && m_FacingRight)
        {

            m_FacingRight = false;
        }
        if (m_SpriteRenderer.flipX = calculatedHorizontalInput > 0 && !m_FacingRight)
        {
            m_FacingRight = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {       
            m_OnGround = true;
        }
        
    }
}
