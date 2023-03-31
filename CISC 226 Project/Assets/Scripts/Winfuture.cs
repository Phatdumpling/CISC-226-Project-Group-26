using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winfuture : LastScene
{
    // Start is called before the first frame update
    public LayerMask whatwin;
    void Start()
    {
        lastScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position + Vector3.down/2, 0.2f, whatwin))
        {
            SceneManager.LoadScene("Victory!");
        }
    }
}
