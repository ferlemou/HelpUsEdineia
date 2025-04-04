using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;
    private Vector2 moveDirection = Vector2.zero;
    private bool isGrounded;
    public bool horizontal;

    //InputActions
    private PlayerInputActions playerControls;
    private InputAction move;
    private InputAction jump;


    //Componentes
    private Rigidbody2D rig;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }
    private void OnDisable() {
        move.Disable();
        jump.Disable();
    }
    private void Start() {
        GetComps();
    }
    private void GetComps(){
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        Moviment();
        Rotation();
    }
    private void Moviment(){
        moveDirection = move.ReadValue<Vector2>();
        rig.velocity = new Vector2(moveDirection.x *speed, rig.velocity.y);
    }
    private void Rotation(){
        Vector2 direction = move.ReadValue<Vector2>();
        switch (direction.x){
            case >0.1f:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                horizontal = true;
            break;
            case <-0.1f:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                horizontal = false;
            break;
        }
    }
    private void Jump(InputAction.CallbackContext context){
        if (isGrounded){
            
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        switch(other.gameObject.tag){
            case "Ground":
                isGrounded = true;
            break;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        switch(other.gameObject.tag){
            case "Ground":
                isGrounded = false;
            break;
        }
    }
}
