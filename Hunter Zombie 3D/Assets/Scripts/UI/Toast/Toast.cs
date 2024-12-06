using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Toast : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] string id_Toast__Label = "";
    [SerializeField] string id_Toast__Container = "";

    [SerializeField] float fadeSpeed = 1f; 

    private VisualElement m_Root;
    private Label m_Toast__Label;
    private VisualElement container;

    [SerializeField]
    private bool isActive = false;
    private float opacity = 1f; 

    private void OnEnable()
    {
        GetElement();
    }
    private void Start()
    {
        container.style.opacity = 0;
    }

    private void Update()
    {
        if (isActive)
        {
            opacity = Mathf.Lerp(opacity, 0f, fadeSpeed * Time.deltaTime);
            container.style.opacity = opacity;

            if (opacity <= 0.01f)
            {
                opacity = 0f;
                isActive = false;
                container.style.opacity = opacity; 
            }
        }
    }

    private void GetElement()
    {
        if (document == null)
            document = GetComponent<UIDocument>();
        m_Root = document.rootVisualElement;
        m_Toast__Label = m_Root.Query<Label>(id_Toast__Label);
        container = m_Root.Query<VisualElement>(id_Toast__Container);
    }

    public void SetToast(string text)
    {
        m_Toast__Label.text = text;
        opacity = 1f;
        container.style.opacity = opacity;
        isActive = true;
    }
}
