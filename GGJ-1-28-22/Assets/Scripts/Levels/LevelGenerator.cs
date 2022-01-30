using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;


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
            Debug.Log(colorMapping.color);
            if (colorMapping.color.Equals(pixelColor))
            {
                Debug.Log("Equals");
                float newX = (float)(.4 * x + .2);
                float newY = (float)(.4 * y + .2);
                Vector3 position = new Vector3(newX - 4, newY - 3, 0);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
