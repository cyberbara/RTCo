using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{   
    [Header("____________ALL____________")]
    [SerializeField] private AudioSource PlrAudio;
    [SerializeField] private string scense;
    private float timer;
    [SerializeField] private bool FLcamera = true;
    [SerializeField] private TMP_Text NameOfTest;
    [SerializeField] private GameObject PassedTesting;
    [SerializeField] private Slider Slimer;
    private float Volume = 1f;

    [Header("____________Stels____________")]
    [SerializeField] private Animator Door;
    [SerializeField] private AudioClip Tips, DoorSound, Keyboard, Stealing, IfSteal, Deathwords, GoAWAY, TookSound, KeyboardSound, UseSound, OpenDoorSound;
    [SerializeField] private GameObject Card, StealObj;
    private int count = 0, IsStealed = 0, IsOpened = 0, count2 = 0;
    private bool HadCard = false;

    [Header("____________Parkour____________")]
    [SerializeField] private float FlyingCameraTimer;
    [SerializeField] private AudioClip Passed, unPassed;
    [SerializeField] private GameObject Controller, FLCamera;
    

    [Header("____________FinalWar____________")]
    private bool HadWood = false;
    [SerializeField] private bool FinalWar = false;
    [SerializeField] private AudioClip UHaveWood, Clip1, Clip3, Clip5, Clip6, LightSound, FinalStart;
    [SerializeField] private GameObject Wood, Part1, Part2, Part3, Part4, Part5, Part6, FirstLight, SecondLight, ThirdLight, FirstScene, SecondScene;
    private int WoodCounter = 0;
    [SerializeField] private float Timer;
    [SerializeField] private Animator Glow;

    public void SliderChg()
    {
        Volume = Slimer.value;
    }




    private void Start()
    {
        if (FLcamera)
        {
            StartCoroutine(FlyingCamera());
        }
        if (FinalWar)
        {
            StartCoroutine(FinalWar1());
        }
    }
    
    public void Glowing()
    {
        Glow.enabled = true;
    }

    public void Raft()
    {
        Controller.SetActive(false);
        FirstScene.SetActive(false);
        SecondScene.SetActive(true);
        StartCoroutine(finality());
    }
    private IEnumerator finality()
    {
        yield return new WaitForSeconds(17);
        SceneManager.LoadScene(scense);
    }
    private IEnumerator FinalWar1()
    {
        yield return new WaitForSeconds(1);
        PlrAudio.PlayOneShot(LightSound);
        PlrAudio.PlayOneShot(FinalStart);
        FirstLight.SetActive(true);
        StartCoroutine(FinalWar2());
    }
    private IEnumerator FinalWar2()
    {
        yield return new WaitForSeconds(4);
        PlrAudio.PlayOneShot(LightSound);
        SecondLight.SetActive(true);
        StartCoroutine(FinalWar3());
    }
    private IEnumerator FinalWar3()
    {
        yield return new WaitForSeconds(4.5f);
        PlrAudio.PlayOneShot(LightSound);
        ThirdLight.SetActive(true);
        StartCoroutine(FinalWar4());
    }
    private IEnumerator FinalWar4()
    {
        yield return new WaitForSeconds(4);
        PlrAudio.PlayOneShot(LightSound);
        SecondLight.SetActive(false);
        ThirdLight.SetActive(false);
    }


    public void TakeWood(GameObject Plank)
    {
        if (HadWood == false)
        {
            PlrAudio.PlayOneShot(TookSound);
            Wood.SetActive(true);
            HadWood = true;
            Plank.SetActive(false);
        }
        else
        {
            Audios(UHaveWood);
        }
    }

    public void UseWood()
    {
        if (HadWood == true)
        {
            Wood.SetActive(false);
            PlrAudio.PlayOneShot(UseSound);
            HadWood = false;
            
            switch (WoodCounter)
            {
                case 0:
                    Part1.SetActive(true);
                    WoodCounter++;
                    Audios(Clip1);
                    break;
                case 1:
                    Part2.SetActive(true);
                    WoodCounter++;
                    break;
                case 2:
                    Part3.SetActive(true);
                    WoodCounter++;
                    PlrAudio.PlayOneShot(Clip3);
                    break;
                case 3:
                    Part4.SetActive(true);
                    WoodCounter++;
                    break;
                case 4:
                    Part5.SetActive(true);
                    WoodCounter++;
                    PlrAudio.PlayOneShot(Clip5);
                    break;
                case 5:
                    Part6.SetActive(true);
                    WoodCounter++;
                    PlrAudio.PlayOneShot(Clip6);
                    break;
            } 
        }
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
        PlrAudio.volume = Volume;

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
