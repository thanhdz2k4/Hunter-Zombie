using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopGunScreen : MenuScreen
{
    [Header("ID ELEMENTS IN SCREEN")]
    [SerializeField] string id_ScrollView;
    [SerializeField] VisualTreeAsset m_Item__Component;
    [SerializeField] string id_Back__Button = "Back_Gun_Shop--Button";

    
    VisualElement m_ScrollView;
    Button m_Back__Button;

    [SerializeField] List<GunSO> data;

    protected override void Awake()
    {
        base.Awake();
        GunsController.FilterGunsEvent += Load_Data_Into_List;
    }

    public void Load_Data_Into_List(List<GunSO> list)
    {
        this.data = list;
        LoadDataIntoScrollView(list);
        
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_ScrollView = m_Root.Q<VisualElement>(id_ScrollView);
        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m_Back__Button.RegisterCallback<ClickEvent>(ShowMainScreen);
    }

    private void ShowMainScreen(ClickEvent evt)
    {
        m_UIController.ShowMainScreen();
    }

    private void LoadDataIntoScrollView(List<GunSO> data)
    {
        m_ScrollView?.Clear();

        foreach(GunSO gunSO in data)
        {
            if(gunSO!= null)
            {
                CreateItemElement(gunSO, m_ScrollView);
            }
        }
    }

    private void CreateItemElement(GunSO gunSO, VisualElement parentTab)
    {
        if (parentTab == null)
        {
            Debug.LogError("Parent tab (ScrollView) is null. Cannot add elements.");
            return;
        }

        if (gunSO == null)
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
        GunTemplate playerTemplate = new GunTemplate(gunSO);
        playerTemplate.SetVisualElements(templateContainer);
        playerTemplate.SetGameData(templateContainer);
        playerTemplate.RegisterCallbacks();
        playerTemplate.InforItemClicked += HandleShowInforGunEvent;
        playerTemplate.BuyItemClicked += HandleBuyGunEvent;

        parentTab.Add(templateContainer);


    }

    private void HandleBuyGunEvent(GunSO sO)
    {
        throw new NotImplementedException();
    }

    private void HandleShowInforGunEvent(GunSO gunSO)
    {
        m_UIController.ShowInforGunScreen(gunSO);
    }
}
