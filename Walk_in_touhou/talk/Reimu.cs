using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public NPCManager NPCManager;
    public GameObject btn_talk;
    public GameObject btn_out;
    public int text_check;
    public bool talk_last_text = false;

    void Start()
    {
        text_check = 0;
        if(NPCManager.like == 0){
            string[] sentences = new string[] { "넌 누구야", "여행자?", "그래서 왜 왔어?" };
            dialogueManager.StartDialogue(sentences);
            text_check ++;
        }
        else if(NPCManager.like >= 1){
            string[] sentences = new string[] { "어, 왔어?", "오늘은 날씨가 좋네", "뭔가 볼일 있어?" };
            dialogueManager.StartDialogue(sentences);
            text_check ++;
        }
    }

    // Update 함수에서 대화가 끝났는지를 확인하여 버튼을 활성화합니다.
    void Update()
    {
        if(talk_last_text == true && text_check == 1){
            btn_talk.SetActive(true);
            btn_out.SetActive(true);
        }
        else if(talk_last_text == false){
            btn_talk.SetActive(false);
            btn_out.SetActive(false);
        }
    }
}
