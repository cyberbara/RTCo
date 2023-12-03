using UnityEngine;

public class GreenZone : MonoBehaviour
{
    [SerializeField] private GameManagment GMT;
    private void OnTriggerEnter(Collider other)
    {
        GMT.UseWood();
    }
}

