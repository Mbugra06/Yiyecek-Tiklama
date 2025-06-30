using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.2f;
    public TextMeshProUGUI oyunBittiYazisi;
    public TextMeshProUGUI SkorText;
    public Button YenidenBaslatButonu;
    private int skor;
    public bool isGameActive;
    public GameObject AnaBaslik;
    void Start()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }
    public void UpdateSkor(int EklenecekSkor)
    {
        skor += EklenecekSkor;
        SkorText.text = "Skor: " + skor;
    }

    public void OyunBitti()
    {
        oyunBittiYazisi.gameObject.SetActive(true);
        YenidenBaslatButonu.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void YenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OyunBaslat(int zorluk)
    {
        AnaBaslik.gameObject.SetActive(false);
        skor = 0;
        spawnRate = spawnRate / zorluk;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateSkor(0);
    }

}
