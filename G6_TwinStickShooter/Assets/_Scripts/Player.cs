﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls controls;

	Vector2 move;
	Vector2 rotate;

    void Awake() 
    {
        controls = new PlayerControls();

        controls.Gameplay.Grow.performed += ctx => Grow();

		controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
		controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

		controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
		controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
		transform.Translate(m, Space.World);

		Vector2 r = new Vector2(rotate.y, rotate.x) * 100f * Time.deltaTime;
		transform.Rotate(r, Space.World);
    }

    // Called 50 times per second - if I remember right
    void FixedUpdate()
    {

    }

    // Increases the size of the player object
    void Grow()
    {
        transform.localScale *= 1.1f;
    }

    // Enables controls
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    // Disables controls
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
