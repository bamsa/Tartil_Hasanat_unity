using UnityEngine;
using TMPro;

public class HasanatMission : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip voiceClip; // Insert the sound "Help me, my son" or the sound of a cat here


    [Header("إعدادات التكرار")]
    // public float cooldownTime = 10f; // Waits 10 seconds before calling again

    //private float nextPlayTime = 0f;

    [Header("حركات الفوز")]
    public ParticleSystem winEffect; // The Star Effect or Celebration


    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private bool isPlayerNearby = false;
    private bool isMissionDone = false;

    void Start()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && !isMissionDone && Input.GetKeyDown(KeyCode.E))
        {
            CompleteMission();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // As soon as any object (the player) approaches, the screen opens and the text appears.
        isPlayerNearby = true;
        if (!isMissionDone)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = " to help (Press E)";
           
                audioSource.PlayOneShot(voiceClip);
            
                
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When you move away, the screen disappears automatically
        isPlayerNearby = false;
        
            if (dialoguePanel != null) dialoguePanel.SetActive(false);

        if (isMissionDone)
        { this.enabled = false;

          //  winEffect.Stop();
        }
    
        
    }

    void CompleteMission()
    {
        isMissionDone = true;

        // Text for task completion, displaying the verse in English along with its translation
        dialogueText.text = "Jazak Allah Khairan! You got +20 Hasanat.";
        winEffect.gameObject.SetActive(true); // The sound and the stars will both start automatically
        
                winEffect.Play();

        //Moving the old man as a gesture of assistance
        transform.position += new Vector3(1f, 0f, 0f);


        // Here, we will increment the actual counter in the next step!
        HasanatCounter.instance.AddHasanat(20);

        Invoke("HideCharacter", 3f); // Calls the hide function after 3 s.
        
    }

    void HideCharacter()
    {
        gameObject.SetActive(false); // Hides the old man or the cat from the scene

        winEffect.gameObject.SetActive(false); // The sound and the stars will both start automatically
       

    }
}

