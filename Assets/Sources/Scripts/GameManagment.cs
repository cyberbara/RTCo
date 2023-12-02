using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    
    [SerializeField] private Animator Door;
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private AudioClip Tips, DoorSound, KeyboardSound, Stealing, Deathwords, GoAWAY;
    [SerializeField] private GameObject Card, StealObj;
    [SerializeField] private string scense;
    private float timer;
    private int count = 0, IsStealed = 0, IsOpened = 0;
    private bool HadCard = false;
    public void TakeCard()
    {
        HadCard = true;
        Destroy(Card);
    }
    public void UseCard()
    {
        if (HadCard == true)
        {
            Door.enabled = true;
            Audios(DoorSound);
            HadCard = false;
        }
        else if (count == 0)
        {
            Audios(Tips);
            count++;
        }
        else
        {
            StartCoroutine(Counter());
        }
    }

    public void Audios(AudioClip Words)
    {
        timer = 0.5f + Words.length - PlrAudio.time;


        if (PlrAudio.isPlaying == false)
        {
            PlrAudio.PlayOneShot(Words);
        }
        else if (PlrAudio.isPlaying == true)
        {
            StartCoroutine(Replay(Words));
        }
    }
    public void Steal()
    {
        if (IsStealed <= 0)
        {
            Audios(Stealing);
            Destroy(StealObj);
        }     
    }
    public void UseKeyboard()
    {
        if (IsOpened <= 0) 
        { 
            Audios(KeyboardSound);
        }   
    }

    public void GoAway()
    {
        if (IsOpened > 0 && IsStealed > 0)
        {
            Audios(GoAWAY);
            StartCoroutine(Go());
        }
    }


    private IEnumerator Replay(AudioClip clipmaker)
    {
        yield return new WaitForSeconds(timer);
        PlrAudio.PlayOneShot(clipmaker);
    }
    private IEnumerator Counter()
    {
        yield return new WaitForSeconds(5f);
        count = 0;
    }
    private IEnumerator Go()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scense);
    }
}
