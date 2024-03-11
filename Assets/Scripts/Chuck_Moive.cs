using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuck_Move : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    public float maxVel;

    public GameObject explosionprefab;

    Rigidbody2D rb;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    bool canDrag = true, in_position = false;
    Vector3 dis;
    
    void OnMouseDrag()
    {
        if(in_position)
        {
            if(!canDrag)
                return;

            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dis = pos - pivot.position;
            dis.z = 0;

            if (dis.magnitude > springRange)
            {
                dis = dis.normalized * springRange;
            }
            transform.position = dis + pivot.position;
        }
    }

    void OnMouseUp()
    {
        if (in_position)
        {
            Debug.Log("OnMouseUp");
            if (!canDrag)
                return;
            canDrag = false;

            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
        }else{
            Debug.Log("In pivot position");
            transform.position = pivot.position;
            in_position = true;
        }
    }

    void Update() {
        if (rb.IsSleeping() && !canDrag)
        {
            if (explosionprefab != null)
            {
                var go = Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(go,3);
            }
            Destroy(gameObject, 0.1f);
        }
    }
}