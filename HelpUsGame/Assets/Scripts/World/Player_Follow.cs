using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 pos;
    private void FixedUpdate() {
        pos = player.transform.position;
        pos.y = pos.y + 2f;
        transform.position = pos;
    }}
