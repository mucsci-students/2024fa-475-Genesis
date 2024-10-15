using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    string HealthKey = "Health";
    public int CurrentHealth { get; set; }

    string HeartsKey = "Hearts";
    public int CurrentHearts { get; set; }

    private void Awake()
    {
        CurrentHealth = PlayerPrefs.GetInt(HealthKey);
        CurrentHearts = PlayerPrefs.GetInt(HeartsKey);
    }

    public void SetHealth(int hp)
    {
        PlayerPrefs.SetInt(HealthKey, hp);
    }

    public void SetHearts(int hearts)
    {
        PlayerPrefs.SetInt(HeartsKey, hearts);
    }



}
