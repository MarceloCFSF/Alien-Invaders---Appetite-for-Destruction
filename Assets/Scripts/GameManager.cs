using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject loseGame;
    public GameObject winGame;
    public bool isEndgame = false;

    public void Die() {
        if (!isEndgame) {
            loseGame.SetActive(true);
            isEndgame = true;
        }
    }

    public void Win() {
        if (!isEndgame) {
            winGame.SetActive(true);
            isEndgame = true;
        }
    }
}
