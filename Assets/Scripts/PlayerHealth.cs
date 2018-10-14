using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int health = 25;

    [SerializeField]
    private Text txtHealth;

    [SerializeField]
    private AudioClip sfxPlayerDamage;

    private void Start() {
        txtHealth.text = health.ToString();
    }

    public void BaseHit() {
        health -= 1;
        txtHealth.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(sfxPlayerDamage);
        if (health <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        print("You Lost!");
    }
}
