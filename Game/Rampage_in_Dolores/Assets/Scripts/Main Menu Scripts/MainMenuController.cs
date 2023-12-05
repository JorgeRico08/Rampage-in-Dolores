using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    //public GameObject GamePanel;
    //public GameObject ControlsPanel;
    //public GameObject GfxPanel;
    //public GameObject LoadGamePanel;
    public GameObject ReglasInGame;
    public GameObject AcerdaDe;

    private Session _session;
    public GameObject alerta;
    public GameObject sesionTrue;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
        _session = Session.Sessioninstance;
    }

    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
       
    }

    public void openStartGameOptions()
    {
        if (_session.isSesion == true)
        {
            //enable respective panel
            MainOptionsPanel.SetActive(false);
            StartGameOptionsPanel.SetActive(true);

            //play anim for opening main options panel
            anim.Play("buttonTweenAnims_on");

            //play click sfx
            playClickSound();

            //enable BLUR
            //Camera.main.GetComponent<Animator>().Play("BlurOn");
        }
        else
        {
            alerta.SetActive(true);
        }

        
    }

    public void openReglas()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        ReglasInGame.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }

    public void openAcercaDe()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        AcerdaDe.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }




    public void newGame()
    {
        if (!string.IsNullOrEmpty(newGameSceneName))
            SceneManager.LoadScene(newGameSceneName);
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }
    #endregion

    #region Back Buttons

    public void back_options()
    {
        if (_session.isSesion == true)
        {
            sesionTrue.SetActive(true);

            //simply play anim for CLOSING main options panel
            anim.Play("buttonTweenAnims_off");

            //disable BLUR
            // Camera.main.GetComponent<Animator>().Play("BlurOff");

            //play click sfx
            playClickSound();
        }
        else
        {
            sesionTrue.SetActive(false);
            //simply play anim for CLOSING main options panel
            anim.Play("buttonTweenAnims_off");

            //disable BLUR
            // Camera.main.GetComponent<Animator>().Play("BlurOff");

            //play click sfx
            playClickSound();
        }
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");
        
        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
       
    }

    void playClickSound() {

    }


    #endregion
}
