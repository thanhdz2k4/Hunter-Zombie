using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("SCREEN ON IN SHOW ONE AT TIME")]
    [SerializeField] IntroScreen Intro_Screen;
    [SerializeField] OptionScreen option_Screen;
    [SerializeField] LoadingScreen loading_Screen;
    [SerializeField] MainScreen main_Screen;

    [Header("TOOLBAR")]
    [SerializeField] Toolbar toolbar;
    [SerializeField] InforPlayer inforPlayer;

    List<MenuScreen> listOfScreens = new List<MenuScreen>();
    // Start is called before the first frame update
    void Start()
    {
        if(Intro_Screen != null) listOfScreens.Add(Intro_Screen);;
        if(option_Screen != null) listOfScreens.Add(option_Screen);
        if(loading_Screen != null) listOfScreens.Add(loading_Screen);
        if(main_Screen != null) listOfScreens.Add(main_Screen);

        ShowIntroGame();
         
    }

    public void ShowIntroGame() 
    {
        ShowModalScreen(Intro_Screen, listOfScreens);
    }

    public void ShowOptionScreen()
    {
        ShowModalScreen(option_Screen, listOfScreens);
    }

    public void ShowLoadingScreen()
    {
        ShowModalScreen(loading_Screen, listOfScreens);
    }

    public void ShowMainScreen()
    {
        ShowModalScreen(main_Screen, listOfScreens);
    }

    public void ShowToolbar()
    {
        toolbar.ShowScreen();
    }

    public void ShowInforPlayPanel()
    {
        inforPlayer.ShowScreen();
    }

    
    void ShowModalScreen(MenuScreen modalScreen, List<MenuScreen> menuScreens)
    {
        foreach (MenuScreen m in menuScreens)
        {
            if (m == modalScreen)
            {
                m?.ShowScreen();
            }
            else
            {
                m?.HideScreen();
            }
        }
    }


    
}
