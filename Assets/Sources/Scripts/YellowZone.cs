using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowZone : MonoBehaviour
{
    [SerializeField] private GameManagment GMT;
    [SerializeField] private AudioClip Deathwords;
    [SerializeField] private float time = 10f;
    [SerializeField] private string scense;
    private int count = 0;
    [SerializeField] private CharacterController controller;

    private void OnTriggerStay(Collider other)
    {
        if (controller.height > 0.8f && count == 0)
        {
            StartCoroutine(Respawn());
            GMT.Audios(Deathwords);
            count++;
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scense);
    }
}
