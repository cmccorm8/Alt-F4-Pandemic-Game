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

            for (var i = selection.Length - 1; i >= 0; --i)
            {
                var selected = selection[i];
                //var prefabType = PrefabUtility.GetPrefabType(prefab);
                GameObject newObject;

                /*if (prefabType == PrefabType.Prefab)
                {
                    newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                }
                else
                {
                    //newObject = Instantiate(prefab);
                    newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                    newObject.name = prefab.name;
                }*/


                //newObject = selected;
                newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);



                if (newObject == null)
                {
                    Debug.LogError("Error instantiating prefab");
                    break;
                }

                Undo.RegisterCreatedObjectUndo(newObject, "Replace With Prefabs");


                //var allComponents : Component[];

                Component[] allComponents;
                allComponents = selected.GetComponents(typeof(Component));

                for(int j = 0; j < allComponents.Length; j++)
                {
                    var c = allComponents[j];
                    newObject.AddComponent(c.GetType());
                }

                newObject.transform.parent = selected.transform.parent;
                newObject.transform.localPosition = selected.transform.localPosition;
                newObject.transform.localRotation = selected.transform.localRotation;
                newObject.transform.localScale = selected.transform.localScale;
                newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());

                newObject.GetComponent<Rigidbody2D>().gravityScale = selected.GetComponent<Rigidbody2D>().gravityScale;
                newObject.GetComponent<Rigidbody2D>().freezeRotation = selected.GetComponent<Rigidbody2D>().freezeRotation;
                
                newObject.GetComponent<CircleCollider2D>().radius = selected.GetComponent<CircleCollider2D>().radius;
                newObject.GetComponent<CircleCollider2D>().offset = selected.GetComponent<CircleCollider2D>().offset;
                newObject.GetComponent<CircleCollider2D>().isTrigger = selected.GetComponent<CircleCollider2D>().isTrigger;

                newObject.GetComponent<Animator>().runtimeAnimatorController = selected.GetComponent<Animator>().runtimeAnimatorController;

                newObject.GetComponent<Flip>().enemyTransform = newObject.GetComponent<Transform>();
                newObject.GetComponent<Flip>().player = selected.GetComponent<Flip>().player;
                newObject.GetComponent<Flip>().enemyRigidbody = newObject.GetComponent<Rigidbody2D>();

                newObject.GetComponent<EnemyAI>().enemyTarget = selected.GetComponent<EnemyAI>().enemyTarget;
                newObject.GetComponent<EnemyAI>().enemyMvmtSpeed = selected.GetComponent<EnemyAI>().enemyMvmtSpeed;

                //newObject.

                //newObject.rigidbody2d.constraints = selected.rigidbody2d.constraints;

                newObject.name = selected.name;

                Undo.DestroyObjectImmediate(selected);
            }
        }

        GUI.enabled = false;
        EditorGUILayout.LabelField("Selection count: " + Selection.objects.Length);
    }
}