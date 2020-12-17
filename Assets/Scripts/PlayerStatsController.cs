using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float exp;
    public int[] levels;
    public HealthBar healthBar;
    public CharacterStats damage;
    public CharacterStats armor;
    public static PlayerStatsController instance;
    public GameObject bloodSpray;
    // Start is called before the first frame update
    public void Awake(){
        instance=this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        Instantiate(bloodSpray, transform.position,Quaternion.identity );
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log("Took " + damage + " damage");
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
