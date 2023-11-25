using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    public float Speed;

    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private float _cameraPosZ = -10.0f;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // _playerRigidbody.velocity = new Vector2(Speed, 0.0f);
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

        transform.position += transform.right * Speed * Time.deltaTime;
        _animator.SetFloat("speed", Speed);
    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _cameraPosZ);
    }
}
