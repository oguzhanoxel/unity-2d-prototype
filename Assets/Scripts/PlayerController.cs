using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private float _speed = 1.5f;
    
    private bool _jump;
    private bool _grounded;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSpriteRenderer;
    private Animator _playerAnim;

    private void Awake()
    {
         _playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * _speed, _playerRigidbody.velocity.y);

        if(_jump)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jump = false;
            _grounded = false;
            _playerAnim.SetTrigger("jump");
            _playerAnim.SetBool("grounded", false);
        }

        _playerAnim.SetBool("grounded", _grounded);
    }

    private void Update()
    {
        if (_grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            _playerAnim.SetFloat("speed", Mathf.Abs(horizontalInput));

            if (horizontalInput < 0)
            {
                _playerSpriteRenderer.flipX = true;
            } 
            else if (horizontalInput > 0) 
            {
                _playerSpriteRenderer.flipX = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }
}
