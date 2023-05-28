using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null && instance != this) Destroy(gameObject);
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
