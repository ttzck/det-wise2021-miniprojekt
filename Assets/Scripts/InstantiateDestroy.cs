using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDestroy : MonoBehaviour
{
    [SerializeField] private GameObject @object;
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Instantiate(@object,transform.position,transform.rotation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
