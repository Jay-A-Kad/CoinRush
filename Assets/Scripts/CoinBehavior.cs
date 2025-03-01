using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBehavior : MonoBehaviour
{
    public static int coins = 0;
    public TMP_Text coinsCollected;
    public AudioClip coinSound;
    private AudioSource audioSource;
    public GameObject winnerPanel;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (winnerPanel)
        {
            winnerPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coins++;
            coinsCollected.text = coins.ToString();

            if (audioSource && coinSound)
            {
                audioSource.PlayOneShot(coinSound);
            }

            gameObject.SetActive(false);
            Debug.Log("coin counts " + coins);

            if (coins >= 10 && winnerPanel)
            {
                winnerPanel.SetActive(true);
                Debug.Log("Player Wins");
            }
        }
    }
}
