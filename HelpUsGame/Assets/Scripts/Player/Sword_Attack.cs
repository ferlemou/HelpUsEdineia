using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Attack : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HitDamage());
    }
    private IEnumerator HitDamage(){
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
    }
}
