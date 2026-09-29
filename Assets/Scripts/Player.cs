using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;
    private Animator _animPlayer;

    private float xDir;
    private float xSpeed= 5f;
    private float jumpForce = 7f;

    private int jumpCount = 0;
    private const int maxJumps = 2;

    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _animPlayer = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Movimentar();
    }

    void OnMove(InputValue inputValue)
    {
        xDir = inputValue.Get<Vector2>().x;
    }

    void OnJump(InputValue inputValue)
    {
        if (jumpCount < maxJumps)
        {
            _rbPlayer.linearVelocityY = 7;

            jumpCount++;
        }
    }

    void Movimentar()
    {
        _rbPlayer.linearVelocityX = xDir * 5;

        bool isRunning =
            Mathf.Abs(_rbPlayer.linearVelocityX) > Mathf.Epsilon;

        _animPlayer.SetBool("IsRunning", isRunning);

        FlipSprite();
    }

    void FlipSprite()
    {
        if (Mathf.Abs(_rbPlayer.linearVelocityX) > Mathf.Epsilon)
        {
            float sinal = Mathf.Sign(_rbPlayer.linearVelocityX);

            transform.localScale = new Vector3(
                sinal,
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    public void ResetJump()
    {
        jumpCount = 0;
    }
}