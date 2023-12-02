using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool IsOpened;
    [SerializeField] private GameObject FlashLight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLight.SetActive(IsOpened);
            IsOpened = !IsOpened;
        }
    }
}
