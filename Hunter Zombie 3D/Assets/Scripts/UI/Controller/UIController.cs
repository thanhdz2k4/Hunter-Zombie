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
    [SerializeField] ShopCashScreen cashShop_Screen;
    [SerializeField] ListPlayerScreen listPlayer_Screen;
    [SerializeField] InforPayerScreen inforPayer_Screen;
    [SerializeField] ShopGunScreen gunShop_Screen;
    [SerializeField] InforGunScreen inforGun_Screen;
    [SerializeField] SettingsScreen settings_Screen;

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
        if(cashShop_Screen != null) listOfScreens.Add(cashShop_Screen);
        if(listPlayer_Screen != null) listOfScreens.Add(listPlayer_Screen);
        if(inforPayer_Screen != null) listOfScreens.Add(inforPayer_Screen);
        if(gunShop_Screen != null) listOfScreens.Add(gunShop_Screen);
        if(inforGun_Screen != null) listOfScreens.Add(inforGun_Screen);
        if(settings_Screen != null) listOfScreens.Add(settings_Screen);

        //ShowSettingsScreen();
         
    }

    public void ShowSettingsScreen() 
    {
        ShowModalScreen(settings_Screen, listOfScreens);
    }

    public void ShowInforGunScreen(GunSO gunSO) {
        ShowModalScreen(inforGun_Screen, listOfScreens);
        inforGun_Screen.SetData(gunSO);
    }

    public void ShowGunShopScreen() 
    {
        ShowModalScreen(gunShop_Screen, listOfScreens);
    }

    public void ShowInforPlayerScreen(PlayerSO playerSO)
    {
        ShowModalScreen(inforPayer_Screen, listOfScreens);
        inforPayer_Screen.SetData(playerSO);
    }

    public void ShowCashScreen()
    {
        ShowModalScreen(cashShop_Screen, listOfScreens);
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

    public void ShowListPlayerScreen()
    {
        ShowModalScreen(listPlayer_Screen, listOfScreens);
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
