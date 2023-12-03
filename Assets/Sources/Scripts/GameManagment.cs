using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{   
    [SerializeField] private bool ____________All____________;
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private string scense;
    private float timer;

    [SerializeField] private bool ____________Stels____________;
    [SerializeField] private Animator Door;
    [SerializeField] private AudioClip Tips, DoorSound, Keyboard, Stealing, IfSteal, Deathwords, GoAWAY, TookSound, KeyboardSound, UseSound, OpenDoorSound;
    [SerializeField] private GameObject Card, StealObj;
    private int count = 0, IsStealed = 0, IsOpened = 0, count2 = 0;
    private bool HadCard = false;

    [SerializeField] private bool ____________Parkour____________;
    [SerializeField] private AudioClip Passed, unPassed;
    [SerializeField] private GameObject Controller, FLCamera;
    [SerializeField] private float FlyingCameraTimer;

    private void Start()
    {
        StartCoroutine(FlyingCamera());
    }
    public void TakeCard()
    {
        HadCard = true;
        Destroy(Card);
        PlrAudio.PlayOneShot(TookSound);
    }
    public void UseCard()
    {
        if (HadCard == true)
        {
            Audios(DoorSound);
            PlrAudio.PlayOneShot(UseSound);
            HadCard = false;
            StartCoroutine(OpenDoor());
            count2++;
        }
        else if (count == 0 && count2 == 0)
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
        if (IsStealed == 0)
        {
            Audios(Stealing);
            Destroy(StealObj);
            IsStealed++;
            PlrAudio.PlayOneShot(TookSound);
        }     
    }
    public void UseKey()
    {
        if (IsOpened == 0) 
        {
            Audios(Keyboard);
            IsOpened++;
            PlrAudio.PlayOneShot(KeyboardSound);
        }   
    }

    public void GoAway()
    {
        if (IsOpened > 0 && IsStealed > 0)
        {
            Audios(GoAWAY);
            StartCoroutine(Go());
        }
        else if(IsStealed > 0 && count == 0)
        {
            Audios(IfSteal);
        }
        else
        {
            StartCoroutine(Counter());
        }
    }


    public void PassedTest()
    {
        if (count == 0)
        {
            Audios(Passed);
            StartCoroutine(Go());
            count++;
        }
    }
    public void UnPassedTest()
    {
        if (count == 0)
        {
            Audios(unPassed);
            StartCoroutine(Counter());
            StartCoroutine(Go());
            count++;
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
    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1);
        PlrAudio.PlayOneShot(OpenDoorSound);
        Door.enabled = true;
    }
    private IEnumerator FlyingCamera()
    {
        yield return new WaitForSeconds(FlyingCameraTimer);
        Controller.SetActive(true);
        Destroy(FLCamera);
    }
}
