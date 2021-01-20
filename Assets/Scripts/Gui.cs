using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{

    [SerializeField]
    private Text TrueText;
    [SerializeField]
    private Text FalseText;

    private void Start()
    {
        TrueText.text = "0";
        FalseText.text = "0";
    }
    public void AddScore(bool right)
    {
        if (right)
        {
            TrueText.text = (int.Parse(TrueText.text) + 1).ToString();
        }
        else
        {
            FalseText.text = (int.Parse(FalseText.text) + 1).ToString();
        }

    }


}
