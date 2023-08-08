using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the range attack of the enemy
/// </summary>
public class RangeAttack : MonoBehaviour
{

    public Transform target; 
    public float within_range;
    public float speed;
    Patrol patrol;
    public GameObject gun;
    bool canShoot = true;
    public int Damage = 1;


    private void Shoot()
    {
        
        canShoot = true;
       
    }
      
        /// <summary>
        /// Checking if the player is in range and if the enemy can see the player
        /// </summary>
    public void Update()
    {
       
        float dist = Vector3.Distance(target.position, transform.position);

        //check if the player is in range
        if (dist <= within_range)
        {
            Vector3 toTarget = target.position - transform.position;
            RaycastHit hit;
            //check if the enemy can see the player with field of view of 60 degrees
            if (Vector3.Angle(transform.forward, toTarget) <= 60)
            {
                if ((Physics.Raycast(transform.position, toTarget, out hit, within_range)))
                {
                    Debug.DrawLine(transform.position, hit.point);


                    if (hit.transform.gameObject.tag == "Player")
                    {
                        //attacks the player if he is in range and the enemy can see him
                        Debug.Log("Attack");
                        transform.LookAt(target.transform);
                        if (canShoot)
                        {

                            gun.GetComponent<Fires>().fire(Damage, null);
                            canShoot = false;
                            Invoke("Shoot", speed);

                        }





                    }

                }
                if (patrol != null)
                {
                    patrol.enabled = false;
                }


            }
            else if (patrol != null && !patrol.isActiveAndEnabled)
            {
                patrol.enabled = true;

            }
        }
    }
    private void Start()
    {
        canShoot= true;
        patrol = GetComponent<Patrol>();
       
    }
}
