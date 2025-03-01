using System.Collections;
using UnityEngine;
using TMPro;

public class GameCountdown : MonoBehaviour
{
    public int gameCountdown = 3;
    public TMP_Text countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        while (gameCountdown > 0)
        {
            countdownDisplay.text = gameCountdown.ToString();
            yield return new WaitForSeconds(1f);
            gameCountdown--;
        }

        countdownDisplay.text = "GO!!!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
