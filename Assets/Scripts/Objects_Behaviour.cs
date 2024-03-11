using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objects_Behaviour : MonoBehaviour
{
    public Sprite[] sprites;
    public float resistance;
    public GameObject explosionprefab;
    SpriteRenderer spriteRenderer;   
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void ChangeSprite(Sprite sprite){
        Debug.Log("Sprite changed: "+ sprite.name.ToString());
        spriteRenderer.sprite = sprite;
    }
    int act_sprite = 0;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > resistance)
        {
            if (explosionprefab != null)
            {
                var go = Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(go,3);
            }
            
            Destroy(gameObject, 0.1f);
        }
        else
        {  
            float old_resistance = resistance;
            resistance -= col.relativeVelocity.magnitude;

            if (act_sprite < sprites.Length && resistance <= old_resistance*90/100 && sprites != null)
            {
                Debug.Log("Resistance : "+ resistance.ToString());
                ChangeSprite(sprites[act_sprite]);
                act_sprite +=1 ;
            }
        }  
    } 
     
}
