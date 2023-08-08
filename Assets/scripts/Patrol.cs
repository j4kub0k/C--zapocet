
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// makes the enemy patrol between waypoints
/// </summary>
public class Patrol : MonoBehaviour
{
    public List<GameObject> wayPoint; // the waypoints the enemy will go to
    public bool back_forth; // if true, the enemy will go back and forth between the waypoints
    public bool loop; // if true, the enemy will go back to the first waypoint after reaching the last one
    public float speed;
    private int index = 0;
    public GameObject ps;
    private bool puff = true;


    /// <summary>
    /// makes the enemy puff smoke
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator Puff()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject p = Instantiate(ps, transform.position, Quaternion.identity);
        p.GetComponent<ParticleSystem>().Play();
        Destroy(p, 2f);
        puff = true;
    }

    void Update()
    {
        if (index == wayPoint.Count && !(back_forth || loop))
        {
            return;

        }
        else if (back_forth && index == wayPoint.Count)
        {
            // makes the enemy go back and forth between the waypoints
            index = 0;
            wayPoint.Reverse();
        }
        else if (loop && index == wayPoint.Count)
        {
            // makes the enemy go back to the first waypoint after reaching the last one
            index = 0;
        }
        if (puff)
        {
            StartCoroutine(Puff());
            puff = false;
        }
        // makes the enemy move towards the waypoints at a certain speed
        Vector3 a = Vector3.MoveTowards(transform.position, wayPoint[index].transform.position, speed * Time.deltaTime);
        transform.LookAt(a); // makes the enemy look at the waypoint it's going to
        transform.position = a;
      
        if (wayPoint[index].transform.position == transform.position)
        {
            index++;

        }



    }
}
