using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy : MonoBehaviour
{

    public float speed = 10f;
    public int health = 20;
    public int currentHealth;
    bool damaged;
    bool isDead;
    private Transform target;
    private int wavepointIndex = 0;

    private void Awake()
    {
        currentHealth = health; 
    }

    private void Start()
    {
        target = Waypoints.points[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
            Debug.Log("il est mort");
        }

        void Death()
        {
            isDead = true;

            Destroy(gameObject);
        }

    }

}