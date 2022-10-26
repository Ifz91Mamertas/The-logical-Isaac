using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Player))]
public class CollectibleTrigger : MonoBehaviour
{
    [SerializeField] private CollectibleController collectibleController;
    [SerializeField] private string potionTag = "Potion";
    [SerializeField] private string cardTag = "Card";
    private Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherGameObject = other.gameObject;
        if (IsPotion(otherGameObject) || IsCard(otherGameObject))
        {
            
            if (otherGameObject!=null&&IsPotion(otherGameObject))
            {
                player.AddLives(1);
            }
            else
            {
                int getR = Random.Range(0, 5);
                if (getR == 0)
                {
                    player.TakeDamage();
                }
                else if (getR == 1)
                {
                    player.AddLives(1);
                }
                else if (getR==2)
                {
                    player.AddCard(1);
                }
                else if (getR==3)
                {
                    player.IncreaseSize();
                }
                else if (getR == 4)
                {
                    player.DecreaseSize();
                }

            }
            collectibleController.OnCollectibleDestroyed(otherGameObject);
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            
        }
    }

    private bool IsPotion(GameObject obj)
    {
        return obj.CompareTag(potionTag);
    }

    private bool IsCard(GameObject obj)
    {
        return obj.CompareTag(cardTag);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
