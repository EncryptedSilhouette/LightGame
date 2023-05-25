using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.5f;
    private GameControls _gameControls;
    private Rigidbody2D _rigidbody;

    private Vector2 movement => _gameControls.PlayerControls.Movement.ReadValue<Vector2>();

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameControls = new();
        _gameControls.PlayerControls.Enable();
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = movement * _speed;
    }
}
