using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    string HealthKey = "Health";
    public int CurrentHealth;

    string HeartsKey = "Hearts";
    public int CurrentHearts;

    public string scene;

    public void SetHealth(int hp)
    {
        CurrentHealth = hp;
        PlayerPrefs.SetInt(HealthKey, CurrentHealth);
    }

    public void SetHearts(int hearts)
    {
        CurrentHearts = hearts;
        PlayerPrefs.SetInt(HeartsKey, CurrentHearts);
    }



}
