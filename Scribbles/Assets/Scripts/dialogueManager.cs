using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class dialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueData
    {
        public string[] lines;
    }

    public static dialogueManager Instance;
    public GameObject dialoguePanel;
    public float textSpeed;
    private List<string> currentLines;
    private int index;
    private bool isTyping;
    private bool dialogueActive;
    public TMP_Text dialogueBodyText;

    // dialogueManager.Instance.StartDialogue("mainMenuLines"); takhle se vyvolava dialog s jsonem

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!dialogueActive) return;

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueBodyText.text = currentLines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue(DialogueData data)
    {
        currentLines = new List<string>(data.lines);
        index = 0;
        dialogueActive = true;
        dialoguePanel.SetActive(true);

        dialogueBodyText.text = string.Empty;
        StartCoroutine(TypeText());
    }

    public void StartDialogue(string resourcePath)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(resourcePath);
        if (jsonFile == null)
        {
            Debug.Log($"DialogueManager: No JSON found at Resources/{resourcePath}");
            return;
        }
        DialogueData data = JsonUtility.FromJson<DialogueData>(jsonFile.text);
        StartDialogue(data);
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogueBodyText.text = string.Empty;

        foreach (char c in currentLines[index])
        {
            dialogueBodyText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < currentLines.Count - 1)
        {
            index++;
            StartCoroutine(TypeText());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueBodyText.text = string.Empty;
    }

}
