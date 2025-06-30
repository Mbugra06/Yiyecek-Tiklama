using UnityEngine;
using UnityEngine.UI;
public class ZorlukButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int zorluk;
    
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(ZorlukAyarla);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ZorlukAyarla()
    {
        Debug.Log(button.gameObject.name + " tikladi");
        gameManager.OyunBaslat(zorluk);
    }

}
