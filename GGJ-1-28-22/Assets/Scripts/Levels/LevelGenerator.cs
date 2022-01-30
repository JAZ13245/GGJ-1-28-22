using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    public PlayerInput playerOne;
    public PlayerInput playerTwo;


    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                //Debug.Log(x + " " + y);
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.Equals(Color.white))
        {
            //If pixel is white
            return;
        }
        //Debug.Log(x + " " + y);
        //Debug.Log(pixelColor);
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            float newX = (float)(.4 * x + .2);
            float newY = (float)(.4 * y + .2);
            Vector3 position = new Vector3(newX - 4, newY - 3, 0);
            
            //Debug.Log(colorMapping.color);
            if (!(colorMapping.prefab.name == "PlayerOne" || colorMapping.prefab.name == "PlayerTwo"))
            {
                if (colorMapping.color.Equals(pixelColor))
                {
                    Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                }
            }
            else
            {
                if (colorMapping.color.Equals(pixelColor))
                {
                    if(colorMapping.prefab.name == "PlayerOne")
                    {
                        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
                        playerTwoPrefab.transform.position = position;
                    }
                    else
                    {
                        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
                        playerTwoPrefab.transform.position = position;
                    }
                }
            } 
            
        }
    }
}
