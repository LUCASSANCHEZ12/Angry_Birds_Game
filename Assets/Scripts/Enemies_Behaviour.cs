using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies_Behaviour : MonoBehaviour
{
    //public Sprite[] sprites;
    public float resistance;
    public GameObject explosionprefab;
    SpriteRenderer spriteRenderer;   

    Animator anim;

    public Sprite[] sprites;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void ChangeSprite(Sprite sprite){
        spriteRenderer.sprite = sprite;
    }
    int act_animation = 0;
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

            if (act_animation < sprites.Length && sprites != null &&resistance <= old_resistance*90/100 )
            {
                //anim.SetBool(animations[act_animation], true);
                ChangeSprite(sprites[act_animation]);
                act_animation +=1 ;
            }
        }  
    } 
     
}
