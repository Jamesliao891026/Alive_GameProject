using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private float lastVaccineNum;
    private float damage_non;
    private float damage_sli;
    private float damage_mid;
    private float damage_ser;
    private float countdown = 1f;
    public float maxHealth = 1000f;
    public Image healthBar;
    void Awake()
    {
        Player.nowHealth = maxHealth;
        Player.vaccineNum = 0;

        lastVaccineNum = 0;
        damage_non = 1f;
        damage_sli = 5f;
        damage_mid = 7f;
        damage_ser = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.vaccineNum != lastVaccineNum)
        {
            changeDamage();
            lastVaccineNum = Player.vaccineNum;
        }
        if (countdown <= 0)
        {
            BloodDeduct();
            healthBar.fillAmount = Player.nowHealth / maxHealth;
        }
        if (Player.nowHealth <= 0)
        {
            //Die();
        }
        countdown -= Time.deltaTime;
    }
    void BloodDeduct()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name[1])
        {
            case '0'://B0
                Player.nowHealth -= damage_non;
                Debug.Log(Player.nowHealth);
                countdown = 1;
                break;
            case '3'://B3
                Player.nowHealth -= damage_sli;
                Debug.Log(Player.nowHealth);
                countdown = 1;
                break;

            case '2'://B2
                Player.nowHealth -= damage_mid;
                Debug.Log(Player.nowHealth);
                countdown = 1;
                break;
            case '1'://B1
                Player.nowHealth -= damage_ser;
                Debug.Log(Player.nowHealth);
                countdown = 1;
                break;
        }
    }
    void changeDamage()
    {
        switch (Player.vaccineNum)
        {
            case 1:
                damage_sli = 1f;
                damage_mid = 5f;
                damage_ser = 7f;
                break;
            case 2:
                damage_sli = 1f;
                damage_mid = 1f;
                damage_ser = 5f;
                break;

            case 3:
                damage_sli = 1f;
                damage_mid = 1f;
                damage_ser = 1f;
                break;
        }
    }
    // use health potion
    public void Heal(float amount)
    {
        Player.nowHealth += amount;
        if (Player.nowHealth > maxHealth)
        {
            Player.nowHealth = maxHealth;
        }
    }
    // check for nowHealth
    public bool HealthEnough(float amount)
    {
        float healing = Player.nowHealth + amount;
        if (healing > maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
