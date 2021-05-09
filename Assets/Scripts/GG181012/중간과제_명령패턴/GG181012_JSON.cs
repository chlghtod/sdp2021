using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG181012_JSON : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public GG181012_Command command;
        public GG181012_ButtonManager buttonManager;
    }

    List<Data> datas;


    // Start is called before the first frame update
    void Start()
    {
        datas = new List<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
