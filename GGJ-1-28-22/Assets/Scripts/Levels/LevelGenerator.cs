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

    public GameObject[] spawnOut = new GameObject[5];


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
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        float newX = (float)(.4 * x + .2);
        float newY = (float)(.4 * y + .2);

        Vector3 floorPosition = new Vector3(newX - 4, newY - 3, -1); // floor
        Vector3 position = new Vector3(newX - 4, newY - 3, -2); // wall
        Vector3 playerPosition = new Vector3(newX - 4, newY - 3, -9);

        //Debug.Log(x + " " + y);
        //Debug.Log(pixelColor);
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                if (!(colorMapping.prefab.name == "PlayerOne" || colorMapping.prefab.name == "PlayerTwo"))
                {
                    Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);

                    //Spawn out loop
                    for (int i = 0; i < spawnOut.Length; i++)
                    {
                        if (spawnOut[i] == null && colorMapping.color.Equals(colorMappings[0].color))
                        {
                            spawnOut[i] = colorMapping.prefab;
                            break;
                        }
                    }
                }

                else
                {
                    if (colorMapping.prefab.name == "PlayerOne")
                    {
                        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
                        playerOnePrefab.transform.position = playerPosition;
                    }
                    else if (colorMapping.prefab.name == "PlayerTwo")
                    {
                        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
                        playerTwoPrefab.transform.position = playerPosition;
                    }
                }
            }
        }



        if (pixelColor != colorMappings[3].color)
        {
            Instantiate(colorMappings[7].prefab, floorPosition, Quaternion.identity, transform);
            Instantiate(colorMappings[8].prefab, floorPosition, Quaternion.identity, transform);
        }
    }
}
