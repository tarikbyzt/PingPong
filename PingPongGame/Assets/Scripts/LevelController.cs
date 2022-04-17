using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public bool gameActive = false;
    public GameObject startMenu, gameMenu, gameOverMenu, finishMenu;
    public Text scoreText, finishScoreText, currentLevelText, nextLevelText;

    public Slider levelProgressBar;
    public float maxDistance;
    public GameObject finishLine;


    int currentLevel;
    public float score;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
    void Start()
    {
        Current = this;
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        //currentLevelText.text = (currentLevel + 1).ToString();
        //nextLevelText.text = (currentLevel + 2).ToString();
        Debug.Log("else");

        Debug.Log("dfsdfsd");

    }


    void Update()
    {
        //PlayerController player = PlayerController.Current;
        //float distance = finishLine.transform.position.z - PlayerController.Current.transform.position.z;
        //levelProgressBar.value = 110 - ScaleScript.Current.bodySkinnedMeshRenderer.GetBlendShapeWeight(0);
        ////= 110 - ScaleScript.Current.bodySkinnedMeshRenderer.GetBlendShapeWeight(0);


        //scoreText.text = score.ToString();
    }

    public void StartLevel()
    {
        //maxDistance = finishLine.transform.position.z - PlayerController.Current.transform.position.z;

        //PlayerController.Current.ChangeSpeed(PlayerController.Current.runningSpeed);
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        gameActive = true;
        //PlayerController.Current.playerAnimator.SetBool("Running", true);
        Debug.Log("oyun ba�lat");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //LevelLoader.Current.ChangeLevel(this.gameObject.scene.name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level " + (currentLevel + 1));

        if (currentLevel == 2)
        {

            PlayerPrefs.SetInt("currentLevel", currentLevel - 2);
            SceneManager.LoadScene("Level 0");
        }

    }

    public void GameOver()
    {
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameActive = false;
    }

    public void FinishMenu()
    {

        PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
        //finishScoreText.text = score.ToString();
        gameMenu.SetActive(false);
        finishMenu.SetActive(true);
        gameActive = false;
    }

    public void ChangeScore(int increment)
    {
        score += increment;

        scoreText.text = score.ToString();
    }

    public void ChangeMultiplicationScore(float ScoreX)
    {

        score *= ScoreX;
        score = (int)score;
        scoreText.text = score.ToString();


    }
}
