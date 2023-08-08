using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// controles the bullet movement and collision
/// </summary>
public class bullletControl : MonoBehaviour
{
    public float speed;
    public AudioClip hitSound;
    public AudioClip missSound;
    public Texture2D hitTexture;
    public Texture2D normalTexture;
    private int damage = 1;

    /// <summary>
    /// destroy the bullet
    /// </summary>
    private void Die()
    {
        
        Destroy(gameObject);
    }
    /// <summary>
    /// Sets the cursor back to normal after a hit
    /// </summary>
    private IEnumerator SetCursorBack()
    {
        yield return new WaitForSeconds(0.1f);
        Cursor.SetCursor(normalTexture, Vector2.zero, CursorMode.Auto);
    }
    /// <summary>
    /// Controles the collision of the bullet with the enemy.
    /// makes the correct sound and changes the cursor to a hit texture
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {

        float al;
        if (collision.gameObject.tag != "Enemy")
        {  

            GetComponent<AudioSource>().clip = missSound;
            al= missSound.length;
           
        }
        else
        {
            Cursor.SetCursor(hitTexture, Vector2.zero, CursorMode.Auto);
            GetComponent<AudioSource>().clip = hitSound;
            al = hitSound.length;
            StartCoroutine(SetCursorBack());
        }
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Invoke("Die", al);

        //Destroy(gameObject);
    }
    public void SetDamage(int d)
    {
        damage = d;
    }
    public int GetDamage()=>damage;
    void Start()
    {
        //moves the bullet forward with a force of speed
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

    }

    
}
