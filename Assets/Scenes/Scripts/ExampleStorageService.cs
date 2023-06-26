using System;
using UnityEngine;

namespace Scenes.Scripts
{
    public class ExampleStorageService : MonoBehaviour
    {
        private const string KEY = "example";
        private IStorageService storageService;

        private void Start()
        {
            storageService = new JsonToFileStorageService();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExampleStorageItem item = new ExampleStorageItem();
                item.Name = "GRKGMRGKGRKMGKOMRG";
                storageService.Save(KEY,item);
                
                Debug.Log("Save");
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                storageService.Load<ExampleStorageItem>(KEY, item =>
                {
                    Debug.Log($"name is {item.Name} ");
                });
            }
        }
    }
}

public class ExampleStorageItem
{
    public string Name { get; set; }
}