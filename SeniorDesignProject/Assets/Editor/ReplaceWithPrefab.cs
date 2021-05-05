using UnityEngine;
using UnityEditor;

public class ReplaceWithPrefab : EditorWindow
{
    [SerializeField] private GameObject prefab;
    [MenuItem("Tools/Replace With Prefab")]

    static void CreateReplaceWithPrefab()
    {
        EditorWindow.GetWindow<ReplaceWithPrefab>();
    }

    private void OnGUI()
    {
        prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);

        if (GUILayout.Button("Replace"))
        {
            if (!PrefabUtility.IsPartOfAnyPrefab(prefab))
            {
                Debug.LogError("Not a valid prefab");
                return;
            }

            var selection = Selection.gameObjects;

            for (var i = 0; i < selection.Length; i++)
            {
                var selected = selection[i];

                GameObject newObject;

                newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

                Undo.RegisterCreatedObjectUndo(newObject, "Replace With Prefabs");

                /*Component[] allComponents;
                allComponents = selected.GetComponents(typeof(Component));

                for(int j = 0; j < allComponents.Length; j++)
                {
                    var c = allComponents[j];
                    newObject.AddComponent(c.GetType());
                }*/

                newObject.transform.parent = selected.transform.parent;
                newObject.transform.localPosition = selected.transform.localPosition;
                newObject.transform.localRotation = selected.transform.localRotation;
                newObject.transform.localScale = selected.transform.localScale;
                newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());

                /*newObject.GetComponent<Rigidbody2D>().gravityScale = selected.GetComponent<Rigidbody2D>().gravityScale;
                newObject.GetComponent<Rigidbody2D>().freezeRotation = selected.GetComponent<Rigidbody2D>().freezeRotation;
                
                newObject.GetComponent<CircleCollider2D>().radius = selected.GetComponent<CircleCollider2D>().radius;
                newObject.GetComponent<CircleCollider2D>().offset = selected.GetComponent<CircleCollider2D>().offset;
                newObject.GetComponent<CircleCollider2D>().isTrigger = selected.GetComponent<CircleCollider2D>().isTrigger;*/

                /*newObject.GetComponent<BoxCollider2D>().offset = selected.GetComponent<BoxCollider2D>().offset;
                newObject.GetComponent<BoxCollider2D>().size = selected.GetComponent<BoxCollider2D>().size;
                newObject.GetComponent<BoxCollider2D>().isTrigger = selected.GetComponent<BoxCollider2D>().isTrigger;*/

                //newObject.GetComponent<Animator>().runtimeAnimatorController = selected.GetComponent<Animator>().runtimeAnimatorController;

                //newObject.GetComponent<Flip>().player = selected.GetComponent<Flip>().player;

                //newObject.GetComponent<EnemyAI>().enemyTarget = selected.GetComponent<EnemyAI>().enemyTarget;

                newObject.name = selected.name;

                //newObject.layer = LayerMask.NameToLayer("Enemy");
                //newObject.layer = selected.layer;
                //newObject.tag = selected.tag;

                Undo.DestroyObjectImmediate(selected);
            }
        }

        GUI.enabled = false;
        EditorGUILayout.LabelField("Selection count: " + Selection.objects.Length);
    }
}