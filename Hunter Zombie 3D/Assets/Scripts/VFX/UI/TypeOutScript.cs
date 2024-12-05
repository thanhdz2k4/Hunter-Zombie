using System;
using System.Text;
using UnityEngine;

public class TypeOutScript : MonoBehaviour
{
    bool IsTyping = true;

    public bool isTyping;
    public bool ResetTyping = false;

    [SerializeField] private string[] conversationLines;
    [SerializeField] private float totalTypeTime = 2f;
    [SerializeField] private float randomCharChangeRate = 0.1f;
    [SerializeField] private float timerDelayBetweenLines;
    private float timer;
    private int currentLineIndex = 0;
    private int charIndex = 0;
    private string currentLine;
    private float typeRate;
    private float lastTypeTime;
    private string randomCharacter;
    private float lastRandomCharTime;

    public event Action<string> OnTextTyped;
    public event Action OnConversationFinished;

    private void Start()
    {
        if (conversationLines.Length > 0)
        {
            currentLine = conversationLines[currentLineIndex];
            typeRate = totalTypeTime / currentLine.Length;
        }
    }

    public void SetData(string[] data) 
    {
        this.conversationLines = data;
    }

    private void Update()
    {
        if (IsTyping)
        {
            TypeLine();
        }
    }

    private void TypeLine()
    {
        if (currentLine == null || currentLine.Length == 0) return;

        if (Time.time - lastRandomCharTime >= randomCharChangeRate)
        {
            isTyping = true;
            randomCharacter = GetRandomCharacter();
            lastRandomCharTime = Time.time;
        }

        if (charIndex < currentLine.Length)
        {
            if (Time.time - lastTypeTime >= typeRate)
            {
                charIndex++;
                lastTypeTime = Time.time;
            }

            string displayText = currentLine.Substring(0, charIndex);

            if (charIndex < currentLine.Length)
            {
                displayText += randomCharacter;
            }

            OnTextTyped?.Invoke(displayText);

            while (charIndex < currentLine.Length && currentLine[charIndex] == ' ')
            {
                charIndex++;
            }
        }
        else
        {
        timer += Time.deltaTime;
        isTyping = false;
        if (timer >= timerDelayBetweenLines) {
            timer = 0;
            IsTyping = false;
            OnTextTyped?.Invoke(currentLine);
            currentLineIndex++;
            if (currentLineIndex < conversationLines.Length)
            {
                PrepareNextLine();
            }
            else
            {
                OnConversationFinished?.Invoke();
            }

        }
        
        }
        if (ResetTyping)
        {  
            ResetConversation();
        }
    }

    private void Delay()
    {
    
    }

    private void PrepareNextLine()
    {
        charIndex = 0;
        IsTyping = true;
        isTyping = true;
        currentLine = conversationLines[currentLineIndex];
        typeRate = totalTypeTime / currentLine.Length;
    }

    private string GetRandomCharacter()
    {
        byte value = (byte)UnityEngine.Random.Range(41, 128);
        return Encoding.ASCII.GetString(new byte[] { value });
    }

    public void SetConversationLines(string[] lines)
    {
        conversationLines = lines;
        ResetConversation();
    }

    private void ResetConversation()
    {
        currentLineIndex = 0;
        charIndex = 0;
        IsTyping = true;
        ResetTyping = false;
        if (conversationLines.Length > 0)
        {
            currentLine = conversationLines[currentLineIndex];
            typeRate = totalTypeTime / currentLine.Length;
        }
    }

    public void SkipCurrentLine()
    {
        IsTyping = false;
        OnTextTyped?.Invoke(currentLine);
        currentLineIndex++;
        if (currentLineIndex < conversationLines.Length)
        {
            PrepareNextLine();
        }
        else
        {
            OnConversationFinished?.Invoke();
        }
    }
}
