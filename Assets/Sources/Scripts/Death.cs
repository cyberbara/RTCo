using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameManagment GMT;
    [SerializeField] private AudioClip Deathwords;
    [SerializeField] private float time = 10f;
    [SerializeField] private string scense;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Respawn());
            GMT.Audios(Deathwords);
        }
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scense);
    }
}   
