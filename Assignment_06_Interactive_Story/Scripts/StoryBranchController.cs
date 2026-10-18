using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Practical 6: Narrative Branch Controller
/// Defines the story script, initiates dialogue sequences, and links choices to gameplay outcomes and cutscenes.
/// </summary>
public class StoryBranchController : MonoBehaviour
{
    [Header("Cutscene Integration")]
    [Tooltip("PlayableDirector component for Unity Timeline cutscene.")]
    [SerializeField] private PlayableDirector introCutscene;

    [Header("Audio")]
    [SerializeField] private AudioSource narrativeBgm;

    private void Start()
    {
        // If cutscene is assigned, play timeline at start, then trigger dialogue
        if (introCutscene != null)
        {
            introCutscene.stopped += OnCutsceneFinished;
            introCutscene.Play();
        }
        else
        {
            TriggerOpeningStory();
        }
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        TriggerOpeningStory();
    }

    public void TriggerOpeningStory()
    {
        List<DialogueManager.DialogueLine> storySequence = new List<DialogueManager.DialogueLine>
        {
            new DialogueManager.DialogueLine
            {
                speakerName = "Elder Gwydion",
                sentence = "Halt, traveler! The Ruins of Valdor are crumbling. A dark presence stirs in the depths below."
            },
            new DialogueManager.DialogueLine
            {
                speakerName = "Elder Gwydion",
                sentence = "You stand at a crossroads. Will you take the sacred Golden Amulet for protection, or forge ahead on your own steel?",
                choiceAText = "Accept Amulet (+Shield)",
                choiceBText = "Refuse (Brave Path)",
                onChoiceA = () => OnPlayerChoice(true),
                onChoiceB = () => OnPlayerChoice(false)
            }
        };

        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(storySequence);
        }
    }

    private void OnPlayerChoice(bool acceptedAmulet)
    {
        List<DialogueManager.DialogueLine> followUp = new List<DialogueManager.DialogueLine>();

        if (acceptedAmulet)
        {
            followUp.Add(new DialogueManager.DialogueLine
            {
                speakerName = "Elder Gwydion",
                sentence = "Wise choice! May the light of the amulet illuminate your steps and ward off hostile beasts."
            });
            // Apply gameplay bonus
            if (GameManager2D.Instance != null) GameManager2D.Instance.AddScore(100);
        }
        else
        {
            followUp.Add(new DialogueManager.DialogueLine
            {
                speakerName = "Elder Gwydion",
                sentence = "A bold soul! The path will be harsh, but true glory belongs to those who rely only on themselves."
            });
        }

        DialogueManager.Instance.StartDialogue(followUp);
    }
}
