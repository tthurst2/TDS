using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    float collisionTimer = 0;
    float invulnAnimTimer = 0;
    private readonly float invulnFlashDelay = 0.2f; //5 flashes per second
    SpriteRenderer spriteRend;

    void Start() {
        correctLayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend == null) {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
        }
    }


    void OnTriggerEnter2D() {
        if(collisionTimer < 0) {
            collisionTimer = 0.5f;
            health--;
        }
        

        //Debug.Log("Trigger!");
        //Optimize this!
        if(invulnPeriod > 0) {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }  
    }

    void Update() {
        collisionTimer -= Time.deltaTime;
        if(invulnTimer > 0) {
            invulnTimer -= Time.deltaTime;


            if(invulnTimer <= 0) {
                gameObject.layer = correctLayer;
                if(spriteRend != null) {
                    spriteRend.enabled = true;
                }
            }
            else {
                invulnAnimTimer -= Time.deltaTime;
                //toggle sprite
                if(spriteRend != null && invulnAnimTimer <= 0) {
                    spriteRend.enabled = !spriteRend.enabled;
                    invulnAnimTimer = invulnFlashDelay;
                }
            }
        }

        if(health <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }


}
