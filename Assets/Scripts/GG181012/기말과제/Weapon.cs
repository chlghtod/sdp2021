using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

namespace GG181012
{
    //��� ����

    public class Weapon : MonoBehaviour
    {
        public ObjectPool objectPool;               // ������Ʈ Ǯ ����Ʈ ���� �Լ�
        public GameObject myBullet;                 // ������Ʈ Ǯ�� �߰��� ������Ʈ, �����Ϳ��� �߰��Ѵ�.

        public float bulletSpeed = 10.0f;           // �߻� ������Ʈ ���ǵ�
        public float bulletLifeTime = 1.0f;         // �߻� ������Ʈ �Ѱ� ���� �ð�

        #region Incomplete code (Pool Clear)
        //float currentTime;
        //public float initializationTime = 10.0f;    //������Ʈ Ǯ ����Ʈ �ʱ�ȭ �ð�
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            objectPool = this.GetComponent<ObjectPool>();
            //objectPool.Initialize(this.gameObject.transform, myBullet);     // ������Ʈ Ǯ ����Ʈ �ʱ�ȭ
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))     // �����̽� Ŭ���� 
            {
                //objectPool.Shoot();                 // ������Ʈ Ȱ��ȭ �Լ� ȣ��
            }

            #region Incomplete code (Pool Clear)
            //currentTime += Time.deltaTime;          // �ʱ�ȭ �ð��� ����.
            //Debug.Log(currentTime + "��");
            //if(currentTime> initializationTime)     // �ʱ�ȭ �ð� ���� ��
            //{
            //    ammunition.ClearPoolList();         // ������Ʈ Ǯ ����Ʈ �ʱ�ȭ.
            //    currentTime = 0;
            //    Debug.Log("������Ʈ Ǯ ����Ʈ �ʱ�ȭ");
            //}
            #endregion
        }
    }
}

