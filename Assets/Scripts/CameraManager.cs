using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float incrementValue = 0.2f;

    bool invert = false;
    private float colorVal;
    Color color = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        colorVal += incrementValue * Time.deltaTime * (invert ? -1 : 1);

        if (colorVal >= 1) invert = true;
        else if (colorVal <= 0) invert = false;

        Mathf.Clamp(colorVal, 0, 1);

        color.r = color.g = color.b = colorVal;

        Camera.main.backgroundColor = color;
    }
}
