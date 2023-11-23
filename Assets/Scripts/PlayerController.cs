using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D _playerRigidbody;
    private Animator _animator;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ( Input.GetKey(KeyCode.Space))
        {
            Speed = 1.0f;
        }
        else
        {
            Speed = 0.0f;
        }

        _playerRigidbody.velocity = new Vector2(Speed, 0.0f);
        _animator.SetFloat("speed", Speed);
    }
}
