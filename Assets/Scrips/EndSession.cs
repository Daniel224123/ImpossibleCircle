using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texthighscore = default;
    [SerializeField] TextMeshProUGUI textscore = default;
    public GameObject highscore;

    public Color32 Highscore = new Color32(224, 97, 97, 255);
    public TextMeshProUGUI highscoretext;
    // Start is called before the first frame update
    void Start()
    {
        texthighscore.text = "" + (int)PlayerPrefs.GetFloat("Highscore");
        textscore.text = "" + (int)PlayerPrefs.GetFloat("Score");

        if (GameSession.newhighscoreb)
        {
            FindObjectOfType<Audiomanager>().Play("newhighscore");
            highscoretext.GetComponent<TextMeshProUGUI>().color = Highscore;
            texthighscore.GetComponent<TextMeshProUGUI>().color = Highscore;
            Instantiate(highscore, transform.position, transform.rotation);
        }
    }
}
