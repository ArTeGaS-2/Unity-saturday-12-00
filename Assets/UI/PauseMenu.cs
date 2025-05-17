using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // ���� ��������� ������� �� ���
    public GameObject pauseMenuObject; // ³��� ����� � ���� ����������

    private void Awake()
    {
        Instance = this; // ����'���� ������� � ����� �� �����
        pauseMenuObject.SetActive(false); //�������� ���� ����� �� �������
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
        pauseMenuObject.SetActive(false); //�������� ���� ����� �� �������
        Time.timeScale = 1; //³��������� ���
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1; // ³��������� ���
        SceneManager.LoadScene(0); // ������������ ����� � �������� ����
    }
}
