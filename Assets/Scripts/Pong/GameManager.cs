using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;

    public Text _computerScoreText;
    public Text _playerScoreText;

    public Square _square;
    public Paddle _playerPaddle;
    public Paddle _computerPaddle;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _gameOver;

    private void Update()
    {
        // Use R key to reset game
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1); // Scene 1 == Game, Scene 0 == Main Menu
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _pauseMenu.SetActive(true);
            // Freezes game to pause
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _pauseMenu.SetActive(false);
            // Unfreezes game 
            Time.timeScale = 1;   
        }
    }

    public void PlayerScore()
    {
        _playerScore++;
        this._playerScoreText.text = _playerScore.ToString();
        Reset();
        if (_playerScore == 5 || _computerScore == 5)
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ComputerScore()
    {
        _computerScore++;
        this._computerScoreText.text = _computerScore.ToString();
        Reset();
        if (_playerScore == 5 || _computerScore == 5)
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Reset()
    {
        this._playerPaddle.ResetPosition();
        this._computerPaddle.ResetPosition();
        // FX found in Square.cs
        this._square.ResetPosition();
        this._square.AddStartingForce();
    }
}
