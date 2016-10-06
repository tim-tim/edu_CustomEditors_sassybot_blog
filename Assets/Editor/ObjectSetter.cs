using UnityEngine;
using UnityEditor;
using System.IO;

public class ObjectSetter : EditorWindow
{
    public static ObjectSetter window;
    private static GameObject obj;

    [MenuItem ("Toolbox/ObjectSetter")]
    static void OpenWindow()
    {
        // create a window and set its title
        window = (ObjectSetter)EditorWindow.GetWindow(typeof(ObjectSetter));
        window.titleContent = new GUIContent("Utilities", Resources.Load("icon") as Texture);
    }

    void OnGUI()
    {
        if (window == null)
        {
            OpenWindow();
        }

        if(Selection.activeGameObject != null)
        {
            // yum tests           
            obj = Selection.activeGameObject;
            GUI.Label(new Rect(5, 5, position.width - 10, 25), "Active object: " + Selection.activeGameObject.name);
            DataHolder dataComponent = obj.GetComponent<DataHolder>();

            if(dataComponent != null)
            {
                dataComponent.health = EditorGUI.IntField(
                    new Rect(5, 30, position.width - 10, 16),
                    "Health",
                    dataComponent.health
                    );
                dataComponent.username = EditorGUI.TextField(
                    new Rect(5, 50, position.width - 10, 16),
                    "Name",
                    dataComponent.username
                    );
                // deprecated from original blogpost
                dataComponent.cam = (GameObject) EditorGUI.ObjectField(
                    new Rect(5, 70, position.width - 10, 16),
                    "Main Camera",
                    dataComponent.cam,
                    typeof(GameObject),
                    false
                    );
            }
            else
            {
                if(GUI.Button(new Rect(5,30, position.width-10, position.height -40), "Add DataHolder"))
                {
                    obj.AddComponent<DataHolder>();
                }
            }

           

            //GUI.Label(new Rect(0, 25, position.width, 25), "Position: " + obj.transform.position);
        }   
        
        //if(GUI.Button(new Rect(0,0, 30, 30), "F"))
        //{
        //    Debug.Log("DONE");
        //    AssetDatabase.CreateFolder("Assets", "MyFolder");
        //}       
    }

    void Update()
    {
        Repaint();
    }

	
}
