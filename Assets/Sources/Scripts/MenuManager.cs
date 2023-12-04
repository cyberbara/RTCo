using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool Isopened = true;
    [SerializeField] GameObject Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Isopened == true)
        {
            Menu.SetActive(Isopened);
            Isopened = false;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Isopened == false)
        {
            Menu.SetActive(Isopened);
            Isopened = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        Menu.SetActive(Isopened);
        Isopened = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
