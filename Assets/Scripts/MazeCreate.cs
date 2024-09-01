using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MazeCreate : MonoBehaviour
{
    public string file_name;
    public Vector3 start_coardinate = new Vector3(-4.5f, 0f, -4.5f);

    public Text timetext;
    public float time;
    public Image win;

    private GameObject element;
    private Vector3 coardinate;
    private string[] maze_map = new string[30];
    void Start()
    {
        Time.timeScale = 1;
        file_name = Application.dataPath + "/StreamingAssets/maze1.txt";
        ReadMapFromFile();
        BuildMaze();
        GetComponent<NavMeshSurface>().BuildNavMesh();
        win.gameObject.SetActive(false);
        
    }
    void ReadMapFromFile()
    {

        StreamReader file = new StreamReader(file_name);

        for (int i=0;i<maze_map.Length;i++)
        {
            maze_map[i] = file.ReadLine();
        }

        file.Close();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timetext.text = "Время: " + (int)time;
        if (time >= 30f)
        {
            Time.timeScale = 0;
            win.gameObject.SetActive(true);
            Cursor.visible = true;
           
        }
    }


    void BuildMaze()
    {
        for (int z = 0; z < 30; z++)
        {
            for (int x = 0; x < 30; x++)
            {
                switch (maze_map[z][x])
                {
                    case '0':
                        break;

                    case '1':
                        coardinate = start_coardinate + new Vector3(x, 0f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().wall, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '2':
                        coardinate = start_coardinate + new Vector3(x, -0.5f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().box, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '3':
                        coardinate = start_coardinate + new Vector3(x, 0f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().column, coardinate, Quaternion.Euler(270f, 0f, 0f));
                        element.transform.parent = gameObject.transform;
                        break;

                    case '4':
                        coardinate = start_coardinate + new Vector3(x, -0.49f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().grass, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '5':
                        coardinate = start_coardinate + new Vector3(x, 0.5f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().portal_colonna, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '6':
                        coardinate = start_coardinate + new Vector3(x, -0.5f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().barrels, coardinate, Quaternion.Euler(270f, 0f, 0f));
                        element.transform.parent = gameObject.transform;
                        break;

                    case '7':
                        coardinate = start_coardinate + new Vector3(x, 0f, z+0.5f) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().portal, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '8':
                        coardinate = start_coardinate + new Vector3(x, 0f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().goplayer, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case '9':
                        coardinate = start_coardinate + new Vector3(x, -0.5f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().lamppost, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case 'A':
                        coardinate = start_coardinate + new Vector3(x, -0.5f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().tree, coardinate, Quaternion.Euler(270f, 0f, 0f));
                        element.transform.parent = gameObject.transform;
                        break;

                    case 'B':
                        coardinate = start_coardinate + new Vector3(x, 1f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().enemy, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;

                    case 'C':
                        coardinate = start_coardinate + new Vector3(x, -0f, z) + transform.localPosition;
                        element = Instantiate(GetComponent<MazeElements>().turrets, coardinate, Quaternion.identity);
                        element.transform.parent = gameObject.transform;
                        break;
                }
            }
        }
    }
}
