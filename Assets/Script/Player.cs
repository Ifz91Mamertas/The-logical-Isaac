using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform size;
    [SerializeField] private CollectibleTrigger collectible;
     [SerializeField] private SpikeTrigger spike;
    [Header("Player state")] 
    [SerializeField, Min(0)]
    private int lives = 6;

    

    [SerializeField, Min(0)] private int card = 0;

    [Header("UI")] 
    [SerializeField] 
    private Text livesText;

    [SerializeField] private Text cardText;

    [SerializeField] 
    private Text finalText;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        finalText.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    
    private void Start()
    {
        UpdateLivesText();
        UpdateCardText();
    }

    // Update is called once per frame
    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {lives}";
    }

    private void UpdateCardText()
    {
        cardText.text = $"Card: {card}";
    }

    public void TakeDamage()
    {
        lives--;
        UpdateLivesText();
        if (lives <= 0)
        {
            StopGame();
        }
    }

    public void IncreaseSize()
    {
        print("Sumažėjo");
        //size.localScale.x(-1) ;
        //size.localScale.y(-1);
        
    }

    public void DecreaseSize()
    {
        print("Padidėjo");
        //size.localScale.x(+1);
        //size.localScale.y(+1);
    }
    public void AddLives(int value)
    {
        lives += value;
        UpdateLivesText();
    }

    public void AddCard(int value)
    {
        card += value;
        UpdateCardText();
    }

    private void StopGame()
    {
        playerController.enabled = false;
        finalText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetAxis("Jump")>0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collectible.gameObject.CompareTag("Potion"))
        {
            AddLives(1);
        }

        if (collectible.gameObject.CompareTag("Card"))
        {
            print("iškviečiamas");
            AddCard(1);
        }

        if (spike.gameObject.CompareTag("Spike"))
        {
            print("iškviečiamas");
            TakeDamage();
        }
    }
}
