using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score = default;
    [SerializeField] int currentscore = 0;
    [SerializeField] int lastscore=0;
    public static bool newhighscoreb;

        
    public Camera gamecam;
    public Color colorblack;
    public Image blackfade;
    public Color newHighscoreColor;

    
    // Start is called before the first frame update
    void Start()
    {
        score.text = currentscore.ToString();
        PlayerPrefs.SetFloat("Score", currentscore);
        blackfade.canvasRenderer.SetAlpha(0.0f);
        newhighscoreb = false;

}

    private void Update()
    {
       
        perscoreupgradedificult();
        
     
    }

    public void countScore()
    {
        currentscore++;
        score.text = currentscore.ToString();
        PlayerPrefs.SetFloat("Score", currentscore);
        if (PlayerPrefs.GetFloat("Highscore") < currentscore)
        {
            newhighscoreb = true;
            PlayerPrefs.SetFloat("Highscore", currentscore);
            score.color = newHighscoreColor;
        }
    }

 

    private void perscoreupgradedificult()
    {
        if (currentscore == 21 || currentscore == 60 || currentscore == 100)
        {
            blackfade.CrossFadeAlpha(1, 1, false);

        }
        if(currentscore== 31 || currentscore == 70 || currentscore == 110)   
        {
            blackfade.CrossFadeAlpha(0, 1, false);
        }
    }
}
