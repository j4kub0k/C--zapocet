using DG.Tweening;
using System.Collections;
using UnityEngine;


/// <summary>
/// Manages the player's health, damage, and invincibility mechanics.
/// </summary>
public class PlayerKill : MonoBehaviour
{
    private int health = 3;
    private bool invincible=false;
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy")
            {
                if (health > 0)
                {
                    if (!invincible)
                          health--;
                    Camera.main.DOShakePosition(0.1f, 1, 10, 90, true);
                    if (other.gameObject.tag == "Enemy")
                    {
                        other.gameObject.GetComponent<Die>().die();
                    }
                    invincible = true;
                    StartCoroutine(CountDown(other.gameObject));
                    Debug.Log(health);
                }
                else if (health <= 0)
                    KillMyself();
            }
     
    }
    /// <summary>
    /// Counts down before allowing the player to take damage again and re-enables enemy attacks.
    /// </summary>
    /// <param name="enemy">The enemy GameObject that caused the damage.</param>
    private IEnumerator CountDown(GameObject enemy)
    {
        yield return new WaitForSeconds(2);
        invincible = false;
        if (enemy != null)
        {
            if (enemy.tag.Equals("Enemy") && enemy != null)
                enemy.GetComponent<Attack>().enabled = true;
        }
    }
    /// <summary>
    /// Ending the game and loading the GameOver scene.
    /// </summary>
    public void KillMyself()
    {
        Camera.main.DOKill();
        save.Delete();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
     public int GetHealth()=>health;
    public void SetHealth(int x)=>health+=x;
    
    public void ChangeHealth(int x)=>health=x;
    public void Start()
    {
        health= GetComponent<controller>().MaxHealth;
    }
    public void ChangeInvincible()=>invincible=!invincible;

}
