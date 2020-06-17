using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    //Nombre del Objetivo de la Quest
    public string questName;
    private AudioSource theAudio;
    private SpriteRenderer theRenderer = null;
    private Collider2D theCollider = null;


    void Awake()
    {
        theAudio = GetComponent<AudioSource>();
        theRenderer = GetComponent<SpriteRenderer>();
        theCollider = GetComponent<Collider2D>();
    
    }



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //Si la quest esta solo asignada, devuelve el objeto a true
        if (QuestManager.GetQuestStatus(questName) == Quest.QUEST_STATUS.ASSIGNED)
            gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto no choca con el jugador...
        if (!collision.CompareTag("Player"))
            return;
        //Si el objeto no se activa asi mismo...
        if (!gameObject.activeSelf)
            return;
        //Manda a la "QuestManager" el estado de "COMPLETED" del questName
        QuestManager.SetQuestStatus(questName, Quest.QUEST_STATUS.COMPLETED);

        //Desactiva el renderizado y el collider del objeto con la quest
        theRenderer.enabled = theCollider.enabled = false;
        theCollider.enabled = false;
        //Si el audio es diferente de null realiza el metodo Play() del objeto
        if (theAudio != null)
            theAudio.Play();

    }


}
