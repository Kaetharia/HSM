using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turret : MonoBehaviour {

    private Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float timeBetweenAttacks = 0.8f;
    public int attackDamage = 20;
    ennemy health;
    GameObject Ennemy;


    private void Awake()
    {
        Ennemy = GameObject.FindGameObjectWithTag("Enemy");
        health = GetComponent<ennemy>();
    }

    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

	}
	
	void UpdateTarget() // visée
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //détecte le tag

        float shortestDistance = Mathf.Infinity;  
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            /*if (attaque_active == false) //check si l'attaque est en cours
            {
                attaque_active = true;
                Attaque();

            }*/
        } else
        {
            target = null;
        }
    }


	void Update ()
    {

        if (target == null)
            return;

        //Target Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime* turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;

        }

        fireCountdown -= Time.deltaTime;

        


	}
     void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Scr_Bullet bullet = bulletGo.GetComponent<Scr_Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected() // range visuelle
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }



    /*private void Attaque()
    {

        attaque_en_cours = Random.Range(attaque_min, attaque_max); //randomise la valeur d'attaque
        //attaque_en_cours = attaque_en_cours - défense_ennemi;
        attaque_text.text = attaque_en_cours.ToString(); //texte d'attaque
        StartCoroutine("Cooldown_Attaque");
        



    }

    IEnumerator Cooldown_Attaque ()
    {
        yield return new WaitForSecondsRealtime(cooldown_attaque);
        attaque_active = false;

    }*/

}
