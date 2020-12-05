using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int coin;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI speedText;
 
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coin : " + coin;
        speedText.text = "Speed : " + PlayerMove.speed;

    }
}
