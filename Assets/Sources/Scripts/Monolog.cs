using System.Collections;
using UnityEngine;

public class Monolog : MonoBehaviour
{
    [SerializeField] private GameManagment GMT;
    [SerializeField] private AudioClip MMonolog;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            GMT.Audios(MMonolog);
            count++;
        }
    }
}
