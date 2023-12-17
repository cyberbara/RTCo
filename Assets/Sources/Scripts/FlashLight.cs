using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]private bool IsOpened = true;
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
