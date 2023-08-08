
using DG.Tweening;
using System.Collections;
using UnityEngine;

/// <summary>
/// Defines the behavior of the player character, including movement, shooting, and interactions with weapons and health.
/// </summary>
public class controller : MonoBehaviour
{
    //Character stats
    public bool canMove = true;
    private CharacterController character;
    public float speed = 6;
    public GameObject gun;
    public int MaxHealth = 3;
    private bool infinit = false;
    public enum gunType { pistol, machinegun, shotgun};
    gunType currentGun = gunType.pistol;
    bool canShoot = true;



    public Transform cameraHolder;  
    public float mouseSensitivity = 3f;
    /// <summary>
    /// Heals the player's health by the specified amount.
    /// </summary>
    /// <param name="amount">Amount of health to heal.</param>
    public void Heal(int amount)
    {
        //checks if the player's health will be over the max health
        int x = GetComponent<PlayerKill>().GetHealth();
        if (x + amount <= MaxHealth)
        {
            GetComponent<PlayerKill>().SetHealth(amount);
        }
        else
        {
            GetComponent<PlayerKill>().ChangeHealth(MaxHealth);
        }
    }
    public gunType GetCurrentGun()=> currentGun;

    /// <summary>
    /// Sets ammo for the current gun.
    /// </summary>
    /// <param name="amount">Amount of ammo to set.</param>
    public void SetAmmo(int amount)
    {
        switch (currentGun)
        {
            case gunType.pistol:
                gun.GetComponent<Pistol>().SetAmmo(amount);
                break;
            case gunType.machinegun:
                gun.GetComponent<machinegun>().Ammo = amount;
                break;
            case gunType.shotgun:
                gun.GetComponent<Shotgun>().ammo = amount;
                break;
        }
    }
    /// <summary>
    /// Restores player health to max health.
    /// </summary>
    public void RestoreHealth()=>
        GetComponent<PlayerKill>().ChangeHealth(MaxHealth);
    public void ChangeInfinit()
    {
        infinit = !infinit;
    }

    /// <summary>
    /// Returns amount of ammo for the current gun.
    ///  </summary>
   public int GetAmmo()
    {
        switch(currentGun)
        {
            case gunType.pistol:
                return gun.GetComponent<Pistol>().GetAmmo();
            case gunType.machinegun:
                return gun.GetComponent<machinegun>().Ammo;
            case gunType.shotgun:
                return gun.GetComponent<Shotgun>().ammo;
            default:
                return 0;
        }
    }
    /// <summary>
    /// Sets the current gun.
    ///  </summary>
   public void SetGun(gunType gun)
           {
                currentGun = gun;
           }
    /// <summary>
    /// Coroutine for managing shooting cooldown.
    /// </summary>
    /// <returns>Coroutine enumerator.</returns>
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
            canShoot = true;

    }
   
    void Start()
    {
        character = GetComponent<CharacterController>();
        DOTween.Clear(true);
        save.Load(this.gameObject);
        
    }

    
    void Update()
    {
        Move();
        Rotate();
    }

    /// <summary>
    /// Handles all player movement and shooting.
    /// </summary>
    private void Move()
    {
       

        Vector3 moveVec = Vector3.zero;
        if (canMove)
        {
            // Logic to calculate character movement based on input and camera orientation
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float verticalMove = Input.GetAxisRaw("Vertical");
            moveVec = cameraHolder.transform.up * verticalMove + cameraHolder.transform.right * horizontalMove;
        }
        // Logic to handle shooting
        if(Input.GetMouseButton(0))
        {
               
                switch (currentGun)
                {
                    case gunType.pistol:

                        if (canShoot && Input.GetMouseButtonDown(0))
                        {
                            gun.GetComponent<Pistol>().fire(infinit);
                            canShoot = false;
                            StartCoroutine(Shoot());
                        }
                    break;
                    case gunType.machinegun:
                        gun.GetComponent<machinegun>().fire(infinit);
                        break;
                    case gunType.shotgun:
                        if(canShoot && Input.GetMouseButtonDown(0))
                        {
                            gun.GetComponent<Shotgun>().fire(infinit);
                            canShoot = false;
                            StartCoroutine(Shoot());
                        }
                        break;
                }
                
        }
        //moving player character based on calculated movement vector and speed value and deltaTime
        character.Move(speed * Time.deltaTime * moveVec);

    }
    /// <summary>
    /// Handles rotating the player to face the mouse.
    ///  </summary>
    private void Rotate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
       
        // Raycast from camera to mouse position to determine where the player should look
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float lenght;
        // If the raycast hits the plane, rotate the player to look at the hit point
        if (plane.Raycast(ray, out lenght))
        {
            Vector3 look = ray.GetPoint(lenght);
            Debug.DrawLine(ray.origin, look, Color.blue);
            transform.LookAt(new Vector3 (look.x, transform.position.y, look.z));

           
        }


    }
  
}

