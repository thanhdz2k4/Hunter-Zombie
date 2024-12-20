using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IInput))]
[RequireComponent(typeof(IMousePositionProvider))]
[RequireComponent(typeof(IGravityLocamotion))]
public class Movelocamotion : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private float accelerationRate = 0.2f;
    [SerializeField] private float targetSpeed = 2f;
    [SerializeField] private float stopDistance = 5f;

    private IInput inputASWD;
    private IMousePositionProvider mousePositionProvider;
    private IGravityLocamotion gravityLocamotion;
    private Vector3 rootMotion;
    private float currentSpeed;

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        characterController = characterController ?? GetComponent<CharacterController>();
        animator = animator ?? GetComponent<Animator>();
        inputASWD = GetComponent<IInput>();
        mousePositionProvider = GetComponent<IMousePositionProvider>();
        gravityLocamotion = GetComponent<IGravityLocamotion>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRoll();
    }

    private void FixedUpdate()
    {
        ApplyPhysicsMovement();
    }

    private void HandleRoll()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Roll");
        }
    }


    private void HandleMovement()
    {
        // Get input from keyboard
        Vector2 input = inputASWD.Data();
        animator.SetFloat("X", input.x);
        animator.SetFloat("Y", input.y);


        if(input.y > 0) AdjustSpeed(input.y);
        if(input.y == 0) StopMovement();
    }

    //private void Hand;e

    // make smooth speed
    private void AdjustSpeed(float targetSpeedMultiplier)
    {
        float maxSpeed = targetSpeedMultiplier * targetSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accelerationRate * Time.deltaTime);
        animator.SetFloat("Speed", currentSpeed);
    }

    // Make smooth stop moving
    private void StopMovement()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, 0, accelerationRate * Time.deltaTime);
        if (currentSpeed <= 0.1f)
        {
            currentSpeed = 0;
            animator.SetFloat("Y", 0);
        }
        animator.SetFloat("Speed", currentSpeed);
    }

    private void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition;
    }

    private void ApplyPhysicsMovement()
    {
        Vector3 movement = rootMotion;
        movement.y = gravityLocamotion.Gravity(characterController.isGrounded) * Time.fixedDeltaTime;

        characterController.Move(movement);
        rootMotion = Vector3.zero;
    }

    
}
