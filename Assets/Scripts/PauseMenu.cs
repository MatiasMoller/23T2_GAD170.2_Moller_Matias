using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] GameObject pauseMenu;




    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ResumeMusic();
    }







    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        DontDestroyAudio music = FindObjectOfType<DontDestroyAudio>();
        if (music != null)
        {
            music.StopAudio();
        }

    }
      


        public void ResumeMusic()
    {
        DontDestroyAudio music = FindObjectOfType<DontDestroyAudio>();
        if (music != null)
        {
            music.PlayAudio();
        }
    }

    public void MainMenu()
    {
        Debug.Log("Quit");
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu");
    }
}
