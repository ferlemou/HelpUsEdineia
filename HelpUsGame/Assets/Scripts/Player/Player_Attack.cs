using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject atkHitboxPrefab;
    private Vector2 moveDirection = Vector2.zero;

    //Input Actions
    private PlayerInputActions playerControls;
    private InputAction move;
    private InputAction fire;

    //Componentes
    private Player_Move player_Move;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void Start() {
        player_Move = GetComponent<Player_Move>();
    }
    private void OnEnable() {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable() {
        move.Disable();
    }
    private void Fire(InputAction.CallbackContext context){
        if (player_Move.horizontal){
            Instantiate(atkHitboxPrefab, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), Quaternion.identity);
        } else{
            Instantiate(atkHitboxPrefab, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), Quaternion.identity);
        }

    }
}
