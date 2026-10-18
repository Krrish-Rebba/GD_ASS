using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Practical 6: Interactive Dialogue & Story System
/// Displays sequential dialogue, typewriter text animations, and handles branching player choices.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        [TextArea(2, 5)] public string sentence;
        public string choiceAText;
        public string choiceBText;
        public Action onChoiceA;
        public Action onChoiceB;
    }

    [Header("UI References")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text speakerText;
    [SerializeField] private Text dialogueBodyText;
    [SerializeField] private GameObject choicesContainer;
    [SerializeField] private Button choiceAButton;
    [SerializeField] private Button choiceBButton;
    [SerializeField] private Text choiceATextUI;
    [SerializeField] private Text choiceBTextUI;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.03f;

    [Header("Animator Integration")]
    [SerializeField] private Animator characterAnimator;

    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();
    private bool isTyping = false;
    private string currentFullSentence = "";
    private Coroutine typingCoroutine;
    private DialogueLine currentLine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Hide panel at start if no dialogue is queued
        if (dialoguePanel != null && dialogueQueue.Count == 0)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogueQueue.Clear();
        foreach (var line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            // If currently typing, clicking advances immediately to full text
            StopCoroutine(typingCoroutine);
            dialogueBodyText.text = currentFullSentence;
            isTyping = false;
            ShowChoicesIfPresent();
            return;
        }

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        currentLine = dialogueQueue.Dequeue();
        speakerText.text = currentLine.speakerName;
        currentFullSentence = currentLine.sentence;

        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isTalking", true);
        }

        if (choicesContainer != null) choicesContainer.SetActive(false);
        typingCoroutine = StartCoroutine(TypeSentence(currentFullSentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueBodyText.text = "";
        isTyping = true;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBodyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isTalking", false);
        }

        ShowChoicesIfPresent();
    }

    private void ShowChoicesIfPresent()
    {
        if (!string.IsNullOrEmpty(currentLine.choiceAText) && !string.IsNullOrEmpty(currentLine.choiceBText))
        {
            if (choicesContainer != null) choicesContainer.SetActive(true);
            choiceATextUI.text = currentLine.choiceAText;
            choiceBTextUI.text = currentLine.choiceBText;

            choiceAButton.onClick.RemoveAllListeners();
            choiceBButton.onClick.RemoveAllListeners();

            choiceAButton.onClick.AddListener(() => SelectChoice(true));
            choiceBButton.onClick.AddListener(() => SelectChoice(false));
        }
    }

    private void SelectChoice(bool choseA)
    {
        if (choicesContainer != null) choicesContainer.SetActive(false);

        if (choseA)
        {
            Debug.Log($"[Story Choice] Player chose: {currentLine.choiceAText}");
            currentLine.onChoiceA?.Invoke();
        }
        else
        {
            Debug.Log($"[Story Choice] Player chose: {currentLine.choiceBText}");
            currentLine.onChoiceB?.Invoke();
        }

        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        if (characterAnimator != null) characterAnimator.SetBool("isTalking", false);
        Debug.Log("[Dialogue System] Dialogue completed.");
    }
}
