using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool Isopened = true;
    [SerializeField] private bool locked = false;
    [SerializeField] GameObject Menu, All, All2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Isopened == true)
        {
            Menu.SetActive(Isopened);
            Isopened = false;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E) && Isopened == false)
        {
            Menu.SetActive(Isopened);
            Isopened = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
    private void Start()
    {
        if (locked == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
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
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        All2.SetActive(true);
        Destroy(All);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
