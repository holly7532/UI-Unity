using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(HandleResume);
        restartButton.onClick.AddListener(HandleRestart);
        quitButton.onClick.AddListener(HandleQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleResume()
    {
        GameManager.Instance.TogglePause();
    }

    public void HandleRestart()
    {
        GameManager.Instance.RestartGame();
    }

    public void HandleQuit()
    {
        GameManager.Instance.QuitGame();
    }
}
