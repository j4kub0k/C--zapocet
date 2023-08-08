
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Controls the death of the enemy
/// </summary>
public class Die : MonoBehaviour
{
    private GameObject Player; 
   public GameObject particle;
    public int maxHealth = 2;

    private void enable()=> this.GetComponent<Attack>().enabled = true;

    /// <summary>
    /// Playes the death animation and destroys the enemy
    ///  </summary>
     public void die()
    {
        Player.GetComponentInChildren<Pistol>().AddAmmo(2);
        GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
        p.GetComponent<ParticleSystem>().Play();
        Camera.main.DOShakePosition(0.1f, 1, 10, 90, true);
        Destroy(p, 2);
        Destroy(gameObject);
    }
    /// <summary>
    /// checkes if the enemy is hit by a bullet or the player
    /// and controls the health of the enemy
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
       
        if(collision.gameObject.tag == "Bullet" ) // if the enemy is hit by a bullet decrease the health
        {
            maxHealth-=collision.gameObject.GetComponent<bullletControl>().GetDamage();
            if (maxHealth <= 0)
            {
                die();
            }
            else
            {
                var x = this.GetComponent<Attack>();
                if (x != null)
                {
                    x.enabled = false;
                    Invoke("enable", 1);
                }

            }
        }
        if (collision.gameObject.transform.position == Player.transform.position) // if the the enemy hits the player the enemy dies
        {
            die();
        }
    }
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
