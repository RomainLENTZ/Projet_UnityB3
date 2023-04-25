using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] float slowness = 10f;

    public bool scoreBonus = false;

    private bool isGameEnded = false;

    private float currentScore = 0;
    private float bonusScore = 0;

    void Update(){
        if(!isGameEnded){
            currentScore = Time.timeSinceLevelLoad * 10f;
            if(scoreBonus){
                bonusScore += 1000;
                scoreBonus = false;
            }
            scoreText.SetText((currentScore + bonusScore).ToString("0"));
        }
    }

    public void EndGame(){
        if(!isGameEnded){
            isGameEnded = true;
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel(){
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
