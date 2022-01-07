using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public Text scoreTxT;
    void Start()
    {
        scoreTxT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxT.text = playerScore.score.ToString();
    }
}
