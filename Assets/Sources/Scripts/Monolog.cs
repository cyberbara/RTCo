using System.Collections;
using UnityEngine;

public class Monolog : MonoBehaviour
{
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private AudioClip Deathwords;
    private int count = 0;
    private float timer;
    
    private void OnTriggerEnter(Collider other)
    {
        timer = 0.5f + Deathwords.length - PlrAudio.time;


        if (count == 0 && PlrAudio.isPlaying == false)
        {
            PlrAudio.PlayOneShot(Deathwords);
            count++;
        }
        else if(count == 0 && PlrAudio.isPlaying == true)
        {
            StartCoroutine(Replay());
            count++;
        }
    }
    private IEnumerator Replay()
    {
        yield return new WaitForSeconds(timer);
        PlrAudio.PlayOneShot(Deathwords);
    }
}
