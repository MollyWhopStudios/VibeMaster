using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsFunctions : MonoBehaviour
{
    [SerializeField] public PlayerManager data;
    public TextMeshProUGUI clickTotalText;
    public TextMeshProUGUI passiveDamageText;
    public TextMeshProUGUI screenClicksText;
    public TextMeshProUGUI critChanceText;
    public TextMeshProUGUI totalTicketText;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<PlayerManager>();
        clickTotalText.GetComponent<TextMeshProUGUI>();
        passiveDamageText.GetComponent<TextMeshProUGUI>();
        screenClicksText.GetComponent<TextMeshProUGUI>();
        critChanceText.GetComponent<TextMeshProUGUI>();
        totalTicketText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        clickTotalText.text = "Total vibes earned \n" + data.player.clickTotal;
        passiveDamageText.text = "Total passive damage \n" + data.player.passiveDamage;
        screenClicksText.text = "Total times clicked \n" + data.player.screenClicks;
        critChanceText.text = "Critical Chance \n" + data.player.critChance + "%";
        totalTicketText.text = "Total tickets earned \n" + data.player.ticketTotal;
    }
}
