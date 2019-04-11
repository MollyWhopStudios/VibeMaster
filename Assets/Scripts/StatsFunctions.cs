using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsFunctions : MonoBehaviour
{
    [SerializeField] public PlayerManager data;
    public TextMeshProUGUI clickTotalText;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<PlayerManager>();
        clickTotalText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        clickTotalText.text = "Total little kids: " + data.player.clickTotal;
    }
}
