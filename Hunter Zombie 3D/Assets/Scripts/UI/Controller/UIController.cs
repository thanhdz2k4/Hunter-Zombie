using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("SCREEN ON IN SHOW ONE AT TIME")]
    [SerializeField] IntroScreen Intro_Screen;
    [SerializeField] OptionScreen option_Screen;
    [SerializeField] LoadingScreen loading_Screen;

    List<MenuScreen> menuScreens = new List<MenuScreen>();
    // Start is called before the first frame update
    void Start()
    {
        if(Intro_Screen != null) menuScreens.Add(Intro_Screen);;
        if(option_Screen != null) menuScreens.Add(option_Screen);
        if(loading_Screen != null) menuScreens.Add(loading_Screen);

        ShowIntroGame();
         
    }

    public void ShowIntroGame() 
    {
        ShowModalScreen(Intro_Screen, menuScreens);
    }

    public void ShowOptionScreen()
    {
        ShowModalScreen(option_Screen, menuScreens);
    }

    public void ShowLoadingScreen()
    {
        ShowModalScreen(loading_Screen, menuScreens);
        loading_Screen.TriggerTypeScreen();
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
