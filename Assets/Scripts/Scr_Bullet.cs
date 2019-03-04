using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Scr_Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;


    public void Seek (Transform _target)
    {
        target = _target;
    }
    

    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;

        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }

    void HitTarget()
    {
        Debug.Log("HIT YOU BRO");
    }

}


