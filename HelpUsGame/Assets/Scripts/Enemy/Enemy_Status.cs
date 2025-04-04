using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    [SerializeField]
    private int health;

    //Componentes
    private Rigidbody2D rig;

    private void Start() {
        GetComp();
    }
    private void GetComp(){
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        switch(other.gameObject.tag){
            case "Hit":
                float enemyPosX = other.gameObject.transform.position.x;
                float distanceEnemy = transform.position.x - enemyPosX;
                bool pos = distanceEnemy > 0;
                Damage(1, pos);
            break;
        }
    }
    private void Damage(int value, bool pos){
        health = health - value;
        
        float knockback = (pos ? 1.5f : -1.5f) * Mathf.Abs(1);
        rig.AddForce(new Vector2(knockback, knockback), ForceMode2D.Impulse);
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}
