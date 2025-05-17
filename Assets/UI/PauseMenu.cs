using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // Один екземпляр скрипта на гру
    public GameObject pauseMenuObject; // Вікно паузи з усіма елементами

    private void Awake()
    {
        Instance = this; // Прив'язка скрипта зі сцени до змінної
        pauseMenuObject.SetActive(false); //Вимикаємо вікно паузи на початку
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) 
            && pauseMenuObject.activeSelf == false)
        {
            OpenPauseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) 
            && pauseMenuObject.activeSelf == true)
        {
            ClosePauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); //Вимикаємо вікно паузи на початку
        Time.timeScale = 1; //Відновлюємо гру
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1; // Відновлюємо час
        SceneManager.LoadScene(0); // Завантаження сцени з головним меню
    }
}
