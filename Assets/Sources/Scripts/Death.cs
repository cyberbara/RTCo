using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private AudioClip Deathwords;
    [SerializeField] private float time = 10f;
    [SerializeField] private string scense;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Respawn());
            PlrAudio.PlayOneShot(Deathwords);
        }
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scense);
    }
}   
