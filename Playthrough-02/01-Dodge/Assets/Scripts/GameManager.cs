using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    private void Start() {
        surviveTime = 0f;
        isGameover = false;
    }

    private void Update() {
        if(!isGameover) {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void EndGame() {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTIme", bestTime);
        }
        recordText.text = "Best TIme : " + (int)bestTime;
    }
}
