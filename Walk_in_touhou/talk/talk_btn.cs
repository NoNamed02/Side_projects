using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public NPCManager NPCManager;
    public DialogueManager dialogueManager;
    public Reimu Reimu;

    public void OnButtonClick()
    {
        string[] sentences = new string[] { "뭐? 나하고 이야기하고 싶다고?",
                                            "그렇게 재미있는 이야기는 없는데 말이야"};
            NPCManager.like++;                  
            dialogueManager.StartDialogue(sentences);
    }
}
