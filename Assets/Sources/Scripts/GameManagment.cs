using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagment : MonoBehaviour
{   
    [SerializeField] private bool ____________All____________;
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private string scense;
    private float timer;
    [SerializeField] private TMP_Text NameOfTest;
    [SerializeField] private GameObject PassedTesting;

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

    [SerializeField] private bool ____________FinalWar____________;
    private bool HadWood = false;
    [SerializeField] private AudioClip UHaveWood, Clip1, Clip3, Clip5;
    [SerializeField] private GameObject Wood, Part1, Part2, Part3, Part4, Part5, Part6;
    private int WoodCounter = 0;
    


    public void TakeWood(GameObject Tooked)
    {
        if (HadWood == true)
        {
            Audios(UHaveWood);
        }
        else
        {
            PlrAudio.PlayOneShot(TookSound);
            Wood.SetActive(true);
            Tooked.SetActive(false);
            HadWood = true;
        }
    }

    public void UseWood()
    {
        if (HadWood == true)
        {
            Wood.SetActive(false);
            PlrAudio.PlayOneShot(UseSound);
            switch (WoodCounter)
            {
                case 0:
                    Part1.SetActive(true);
                    Audios(Clip1);
                    break;
                case 1:
                    Part2.SetActive(true);
                    break;
                case 2:
                    Part3.SetActive(true);
                    Audios(Clip3);
                    break;
                case 3:
                    Part4.SetActive(true);
                    break;
                case 4:
                    Part5.SetActive(true);
                    Audios(Clip5);
                    break;
                case 5:
                    Part6.SetActive(true);
                    Part5.SetActive(false);
                    Part4.SetActive(false);
                    Part3.SetActive(false);
                    Part1.SetActive(false);
                    Part2.SetActive(false);

                    break;
            }
            HadWood = false;
            Wood.SetActive(false);
            WoodCounter++;
        }
    }



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
        if (IsOpened > 0 && IsStealed > 0 && count == 0)
        {
            Audios(GoAWAY);
            StartCoroutine(Go());
            PassedTesting.SetActive(true);

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
            PassedTesting.SetActive(true);
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
            PassedTesting.SetActive(true);
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
        
        Destroy(FLCamera);
        NameOfTest.enabled = false;
        Controller.SetActive(true);
    }   
}
