using UnityEngine;
using UnityEngine.UI;

public class HuntedRecord : MonoBehaviour
{
    int huntedNumber = 0;
    [SerializeField] Text huntedText;

    private void Start()
    {
        UpdateTheText();
    }
    public void AddTheNumber()
    {
        huntedNumber++;
        UpdateTheText();
    }

    private void UpdateTheText()
    {
        huntedText.text = "Hunted Zombie: " + huntedNumber.ToString();
    }

    public int ReturnTheNumber()
    {
        return huntedNumber;
    }

}