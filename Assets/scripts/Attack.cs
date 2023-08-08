using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is used to make the enemy follow the player when the player is within a certain range
/// </summary>
public class Attack : MonoBehaviour
{

    public Transform target; // the enemy's target
    public float within_range; // range to attack player
    public float speed; //speed of enemy
    Patrol patrol; 

    public AudioClip enemyWalk;
    public AudioClip enemySee;
    private AudioSource audioSource_;
    private bool madeSound_ = false;

    /// <summary>
    /// Sets the audio back to the walking sound after the enemy has seen the player
    /// </summary>
    private void SetBack()
    {
        audioSource_.clip = enemyWalk;
        audioSource_.Play();
    }
    public void Update()
    {
        //get the distance between the player and enemy (this object)
        float dist = Vector3.Distance(target.position, transform.position);
        //check if it is within the range you set
        if (dist <= within_range)
        {
            
          
            //faces the enemy towards the player
            transform.LookAt(target.transform);
            RaycastHit hit;
            //checks if the enemy can see the player
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, within_range))
            {
              
                if (hit.transform.gameObject.tag == "Player")
                {
                    if (!madeSound_)
                    {
                        //plays the sound of the enemy seeing the player
                        audioSource_.clip = enemySee;
                        audioSource_.Play();
                        madeSound_ = true;
                        Invoke("SetBack", enemySee.length);
                    }
                    //moves the enemy towards the player
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }
                else
                    return;
            }
            if (patrol != null)
            {
                patrol.enabled = false;
            }
        
            
        }
        else if (patrol != null && !patrol.isActiveAndEnabled)
        {
            patrol.enabled = true;
            madeSound_ = false;

        }
    }
    private void Start()
    {
        patrol = GetComponent<Patrol>();
        audioSource_ = GetComponent<AudioSource>();
    }
}
