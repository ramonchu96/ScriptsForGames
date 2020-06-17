using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //Una clase que debe persistir en memoria
public class Quest
{
    //Diferentes estados de nuestra quest
    public enum QUEST_STATUS  //cualquier estado puede estar:
    {
        UNASSIGNED = 0,
        ASSIGNED = 1,
        COMPLETED = 2
    };

    public QUEST_STATUS status = QUEST_STATUS.UNASSIGNED; //estado
    public string questName = string.Empty;                 //nombre



}


public class QuestManager : MonoBehaviour
{

    public Quest[] quest;  //Mantiene un array con un nombre y un estado
    private static QuestManager manager = null; //una instancia del questmanager

    public static QuestManager managerInstance
    {
        get
        {
            if(manager == null) //si no lo tenemos
            {
                GameObject questObject = new GameObject("Default"); //Creammos el objeto
                manager = questObject.AddComponent<QuestManager>(); //nuestro singleton se añadira a un componente
            }

            return manager;
        }

       
    }


    void Awake()
    {

        if (manager)
        {
            DestroyImmediate(gameObject);
            return;
        }
        manager = this;
        DontDestroyOnLoad(manager);
    }

    public static Quest.QUEST_STATUS GetQuestStatus(string questName) //Comprobar una QUEST conocido su nombre
    {
        foreach(Quest q in managerInstance.quest)
        {
            if (q.questName.Equals(questName))
            {
                return q.status;
            }
        }

        return Quest.QUEST_STATUS.UNASSIGNED;
    }

    public static void SetQuestStatus(string questName, Quest.QUEST_STATUS newQuestStatus) //O modificar el estado de la misma de --> sin asignar a asignar o completada
    {
        foreach (Quest q in managerInstance.quest)
        {
            if (q.questName.Equals(questName))
            {
                q.status = newQuestStatus;
                return;
            }
        }


    }


    public static void Reset()
    {
        if (managerInstance == null)
            return;

        foreach (Quest q in managerInstance.quest)
        {
            q.status = Quest.QUEST_STATUS.UNASSIGNED;
        }

    }

  
}


/*
 Esta clase gestionara que mensaje mostrar o no mostrar, en el cual cada perosnaje tendra su propia quest para su mision 

     
     
     */