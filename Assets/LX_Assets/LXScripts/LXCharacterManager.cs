using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LXCharacterManager : MonoBehaviour
{
    public static LXCharacterManager Instance;

    [System.Serializable]
    public class CharacterData
    {
        public string id;
        public GameObject iconObject;  // 新字段
        public GameObject prefab;
    }

    public List<CharacterData> characters;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetCharacterIconObject(string id)
    {
        return characters.Find(c => c.id == id)?.iconObject;
    }

    public GameObject GetCharacterPrefab(string id)
    {
        CharacterData data = characters.Find(c => c.id == id);
        if (data != null)
        {
            return Resources.Load<GameObject>("Characters/" + data.prefab.name); // 确保 Resources/Characters 中有这个 prefab
        }
        return null;
    }
}
