using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject atkHitboxPrefab;

    //Input Actions
    private PlayerInputActions playerControls;
    private InputAction fire;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void Fire(InputAction.CallbackContext context){
        Instantiate(atkHitboxPrefab, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
