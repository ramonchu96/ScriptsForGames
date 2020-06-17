using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiveQuest : MonoBehaviour
{
    //--------Panel canva de texto--------
    public GameObject NPC_talk;
    //---Texto de nuestro panel canvas
    public Text messageText = null;
    //-----Diferentes mensajes que iran en nuestro texto
    public string[] message;

    //Objeto de acceso al siguiente nivel
    public GameObject doorLevel;

    //Le damos el valor string de nuestra quest(objetivo)
    public string questName = string.Empty;


    //Collision con nuestro Quest
    void OnTriggerEnter2D(Collider2D other)
    {
        //Activa el objeto del panel canva
       
        //Llama al estado de la quest que se encuentra en la "questName"
        //Escribe el mensaje segun el estado que tenga en la "QuestManager"
        if (!other.CompareTag("Player"))
            return;
        NPC_talk.SetActive(NPC_talk);
        
        Quest.QUEST_STATUS status = QuestManager.GetQuestStatus(questName);
        messageText.text = message[(int)status];

        

    }

    //Salida de nuestra Quest
    void OnTriggerExit2D(Collider2D other)
    {
        NPC_talk.SetActive(NPC_talk == false);
        Quest.QUEST_STATUS status = QuestManager.GetQuestStatus(questName);

        //Si el estado de nuestra ques es "UNASSIGNED"
        if (status == Quest.QUEST_STATUS.UNASSIGNED)
        {
            //Envia el estado a "ASSIGNED"
            QuestManager.SetQuestStatus(questName, Quest.QUEST_STATUS.ASSIGNED);
        }

        //Si el estado es "COMPLETED"
        if (status == Quest.QUEST_STATUS.COMPLETED)
        {
            //Realiza la acion sobre la quest "COMPLETED"
            doorLevel.SetActive(true);
        }
    
    }



}
