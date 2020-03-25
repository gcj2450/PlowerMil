using UnityEngine;

public class SpawnPrefabOnKeyDown : MonoBehaviour
{
    public GameObject m_Prefab;
    public GameObject m_Player;
    public KeyCode m_KeyCode;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(m_KeyCode) && m_Prefab != null)
            Instantiate(m_Prefab, new Vector3(m_Player.transform.position.x, m_Player.transform.position.y -1.5f, m_Player.transform.position.z), transform.rotation);
    }
}
