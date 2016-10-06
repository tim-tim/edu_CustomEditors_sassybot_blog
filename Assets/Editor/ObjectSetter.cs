using UnityEngine;
using UnityEditor;
using System.IO;

public class ObjectSetter : EditorWindow
{
    public static ObjectSetter window;
    private static GameObject obj;
    private static DataHolder data;

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
            
            data = obj.GetComponent<DataHolder>();
            if(data != null)
            {
                data.next = (DataHolder)EditorGUI.ObjectField(
                    new Rect(5, 30, position.width - 10, 16),
                    "Next Object",
                    data.next, typeof(DataHolder), true
                    );

                data.enableonload = EditorGUI.Toggle(
                    new Rect(5, 70, position.width - 10, 16),
                    "Enable On Load",
                    data.enableonload = true
                    );          
            }
            else
            {
                if(GUI.Button(new Rect(5,30, position.width-10, 70), "Add DataHolder"))
                {
                    obj.AddComponent<DataHolder>();
                }
            }
        }

        int i = 0;
        foreach (DataHolder dataobj in GameObject.FindObjectsOfType(typeof(DataHolder)))
        {
            if (GUI.Button(new Rect(5, 110 + i * 20, position.width - 10, 16), dataobj.gameObject.name))
            {
                Selection.activeGameObject = dataobj.gameObject;
            }
            i++;
        }
    }

    void Update()
    {
        Repaint();
    }
}
