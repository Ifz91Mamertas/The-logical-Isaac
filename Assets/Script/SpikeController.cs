using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private GameObject Spike;

    [Min(0)] [SerializeField] private int count = 3;

    [SerializeField] private Vector3 size = new Vector3(16f, 0f, 16f);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i <= count; i++)
        {
            CreateSpike();
        }
    }

    public void CreateSpike()
    {
        Instantiate(
            Spike,
            GetRandomPosition(),
            Spike.transform.rotation,
            gameObject.transform
        );
    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(
            Random.Range(0, size.x),
            Random.Range(0, size.y),
            Random.Range(0, size.z)
        );
        return transform.position
               + volumePosition
               - size / 2;
    }
    /*/ Update is called once per frame
    void Update()
    {
        
    }*/
}
