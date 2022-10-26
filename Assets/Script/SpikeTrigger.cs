using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D),typeof(Player))]
public class SpikeTrigger : MonoBehaviour
{
    
    [SerializeField] private string SpikeTag = "Spike";

    [SerializeField, Min(0f)] private float minPushForce = 3f;

    [SerializeField, Min(0f)] private float maxPushForce = 5f;

    private SpikeController SpikeController;

    private Rigidbody2D rb;

    private Player player;

    private void Awake()
    {
        SpikeController = FindObjectOfType<SpikeController>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject != null && IsSpike(otherGameObject) && otherGameObject.activeSelf)
        {
            AddPushForce();
            otherGameObject.SetActive(false);
            player.TakeDamage();
            SpikeController.CreateSpike();
            Destroy(otherGameObject);
        }
    }

    private bool IsSpike(GameObject obj)
    {
        return obj.CompareTag(SpikeTag);
    }

    private void AddPushForce()
    {
        var force = Random.Range(minPushForce, maxPushForce);
        rb.AddForce(Vector2.up * force,ForceMode2D.Impulse);
    }
    /*/ Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
