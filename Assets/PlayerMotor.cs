using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpForce = 10;
    public float max_speed = 10;
    public float stoppingForce = 5;
    public float maxjump = 2;
    public float mulltijump = 2;
    private Animator animator;
    private bool canDash = true;
    public float dashForce = 5;
    public float dashAmmount = 1;
    public float maxDash = 1;
    private bool isDashing = false;
    public float dashtime = 0.5f;


    private float initXScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initXScale = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMove();
        HandleMaxSpeed();
        PlayerStopping();
        if (direction.x != 0)
        {

            animator.SetBool("is moving", true);
        }
        else
        {
            animator.SetBool("is moving", false);
        }
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(initXScale, transform.localScale.y,transform.localScale.z );
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector3(-initXScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void PlayerMove()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void HandleMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= max_speed)
        {

            rigidbody2D.linearVelocityX = max_speed;

        }

        else if (rigidbody2D.linearVelocityX <= -max_speed)
        {

            rigidbody2D.linearVelocityX = -max_speed;

        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX, 0) * stoppingForce);
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();

    }


    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (mulltijump > 0)
            {
                mulltijump--;
            }
            else if (mulltijump == 0)
            {
                canJump = false;
            }
            
        }
    }
    private void OnDash()
    {
        if (isDashing)
        
        {
            return;  
        }
        isDashing = true;   
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0 ), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashtime));

        if (direction.x == 0)
        {
            rigidbody2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);  
        }
    }

    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);    
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        mulltijump = maxjump;
    }
}
    