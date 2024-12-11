using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class ListPlayerScreen : MenuScreen
{
    [Header("ID ELEMENTS IN SCREEN")]
    [SerializeField] string id_ScrollView__Containter;
    [SerializeField] string id_Input__TextField;
    [SerializeField] string id_Search__Button;
    [SerializeField] string id_Back__Button;

    [Header("Template")]
    [SerializeField] VisualTreeAsset m_Item__Component;

    [SerializeField] List<PlayerSO> listOfPlayer;

    TextField m_Input__TextField;
    Button m_Search__Button, m_Back__Button;
    VisualElement m_ScrollView__Containter;

    private void Start()
    {
        PlayerTemplateController.fillPlayersEvent += Load_Data_Into_List;
        
    }

    private void Load_Data_Into_List(List<PlayerSO> listOfPlayer)
    {
        this.listOfPlayer = listOfPlayer;
        LoadDataIntoScrollView(listOfPlayer);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_ScrollView__Containter = m_Root.Q<VisualElement>(id_ScrollView__Containter);
        m_Input__TextField = m_Root.Q<TextField>(id_Input__TextField);
        m_Search__Button = m_Root.Q<Button>(id_Search__Button);
        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m_Back__Button.RegisterCallback<ClickEvent>(HandExitScreenEvent);
        
    }

    private void HandExitScreenEvent(ClickEvent evt)
    {
        m_UIController.ShowMainScreen();
    }

    private void LoadDataIntoScrollView(List<PlayerSO> data)
    {
        m_ScrollView__Containter?.Clear();

        foreach(PlayerSO player in data)
        {
            if(player!= null)
            {
                CreateItemElement(player, m_ScrollView__Containter);
            }
        }
    }

    private void CreateItemElement(PlayerSO player, VisualElement parentTab)
    {
        if (parentTab == null)
        {
            Debug.LogError("Parent tab (ScrollView) is null. Cannot add elements.");
            return;
        }

        if (player == null)
        {
            Debug.LogError("Player is null.");
            return;
        }

        if (m_Item__Component == null)
        {
            Debug.LogError("VisualTreeAsset (m_Item__Component) is null. Assign it in the Inspector.");
            return;
        }

        // Instantiate a new visual element from the UXML template
        TemplateContainer templateContainer = m_Item__Component.Instantiate();

        if (templateContainer == null)
        {
            Debug.LogError("Failed to instantiate TemplateContainer from VisualTreeAsset.");
            return;
        }

        // setup data into ui
        PlayerTemplate playerTemplate = new PlayerTemplate(player);
        playerTemplate.SetVisualElements(templateContainer);
        playerTemplate.SetGameData(templateContainer);
        playerTemplate.ResigterEvent();
        playerTemplate.Add_Friend_Event += HandleAddFriendEvent;
        playerTemplate.Show_More_Information_Event += ShowInformationPlayerEvent;

        parentTab.Add(templateContainer);


    }

    private void ShowInformationPlayerEvent(PlayerSO playerSO)
    {
        m_UIController.ShowInforPlayerScreen(playerSO);
        HideScreen();
    }

    private void HandleAddFriendEvent(string obj)
    {
        throw new NotImplementedException();
    }
}
