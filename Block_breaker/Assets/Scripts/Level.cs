using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    int Block_number,player_score;
    [SerializeField] Text Player_score;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Level>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    
        player_score = 0;
        Player_score.text = "Score: 0";
    }

 
    public void block_count()
    {
        Block_number++;
    }
   
    public void block_broken()
    {
        Block_number--;
        player_score++;
            Player_score.text = "Score: "+ player_score;
    }
    public void next_level()
    {
        if (Block_number==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Reset_game()
    {
        Destroy(gameObject);
    }
}
