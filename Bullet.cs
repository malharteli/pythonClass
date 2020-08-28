using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int power = 1;

    // OnCollisionEnter2D is fired every single time your gameObject hits another gameObject in the game
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D other = col.collider;
        if (other.tag == "Player"){
            Debug.Log("Player Hit");
            other.GetComponent<PlayerController>().Hit(power);
        }
        if (other.tag == "Enemy"){
            Debug.Log("Enemy Hit!");
            other.GetComponent<EnemyController>().Hit(power);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}
