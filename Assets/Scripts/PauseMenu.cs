using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Exit;
    [SerializeField] private GameObject HighScores;
    [SerializeField] private GameObject Resumebtn;
    [SerializeField] private GameObject Logo;
    [SerializeField] private Button pausebtn;
    [SerializeField] private Button resumebtn;

    void Start(){
        pausebtn.onClick.AddListener(Pause);
        resumebtn.onClick.AddListener(Resume);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Exit.SetActive(false);
        HighScores.SetActive(false);
        Resumebtn.SetActive(false);
        Logo.SetActive(false);
        Player.GetComponent<roll>().isPaused = false;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        Exit.SetActive(true);
        HighScores.SetActive(true);
        Resumebtn.SetActive(true);
        Logo.SetActive(true);
        //Time.timeScale = 0f;
        Player.GetComponent<roll>().isPaused = true;
        GameIsPaused = true;
    }
}
