using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winfuture : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask whatwin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, whatwin))
        {
            SceneManager.LoadScene("Victory!");
        }
    }
}
