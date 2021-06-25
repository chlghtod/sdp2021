using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

namespace GG181012
{


    public class ObjectPool : MonoBehaviour
    {
        // ����
        // https://funfunhanblog.tistory.com/49
        // https://glikmakesworld.tistory.com/13

        // ������Ʈ Ǯ ����Ʈ?
        // ����Ƽ�� Garbage Collector�� Compaction(����,����)�� ���� �ʴ´�. �޸� ���� ���Ҹ��� �����Ѵ�.  (�Ź� ��ü�� �����ϸ� ������ ������ ���⳪? �ƴϸ� ���� GC�� ���� �Ǵ��� �� �� ����?)
        // Instantiate() , Destroy() �� ���������� ����ϰ� �Ǹ� �޸��� ����ȭ�� �Ͼ�� �ȴ�.
        // �޸��� ����ȭ�� �Ͼ�ԵǸ� ���Ŀ� ���ο� �޸𸮸� �Ҵ� �� �� �Ҵ��� ������ �������� ������ ����� �ȴ�.
        // �׷� ������ �����ϱ� ���ؼ� Loading(������ ���� ����)���� ����� ������Ʈ�� �̸� �Ҵ� �޾� ���� ��Ȱ��ȭ�� ���·� �����Ѵ�.
        // ���� ����Ҷ��� ������Ʋ Ȱ��ȭ�ؼ� ����ϰ� ����� ���� ������Ʈ�� ��Ȱ��ȭ�� �÷��̿��� �����ش�.

        // ����?
        // 1. �޸��� ����ȭ�� ���� �� �� �ִ�.
        // 2. ������Ʈ�� ���� �� �� �����Ǿ� �� ���� �����ͷ� ���ؼ� ���� �߻� �� �� �ִµ�
        //    ���� �÷��� �� �ټ��� ������Ʈ�� �����ϰ� �Ǹ� �÷��̾�� �������� �����Ǵ� ��Ȳ�� ���� �� �� �ִ�.
        //    �׷��� ������ Loading���� �̸� ó���Ѵ�.

        // ����?
        // 1. �ε� �ð��� �������. (������ ���� �ε��� ��� ����. ���� �볳�� �ȵȴ�.)

        // �߰� ������ ���� �ؾ��� ��.
        // ���� ��Ȳ ���� ������Ʈ Ǯ ����Ʈ�� ���� �ʱ�ȭ ������Ѵ�.
        // ����� ������Ʈ Ǯ ����Ʈ�� ���� �Ǹ� �پ���� �ʴ´�.


        // ��ɸ� �����ϰ� ó���� MyCube Ŭ�������� ó���Ѵ�.
        //
        // Initialize();    �ʱ�ȭ �Լ�
        // MakeBullet();    ������Ʈ Ǯ ���� �Լ�
        // ReturnBullet();  ������Ʈ ��ȯ �Լ�
        // Shoot();         ������Ʈ Ȱ��ȭ �Լ�














        //��� ����Ʈ
        LinkedList<ReuseObject> listPool = new LinkedList<ReuseObject>();     // ������Ʈ Ǯ
        LinkedList<ReuseObject> listActive = new LinkedList<ReuseObject>();   // Ȱ��ȭ ���� ������Ʈ
        #region Lagacy Code (Not Use listDeActive)
        //LinkedList<Bullet> listDeActive = new LinkedList<Bullet>();     // ���� ������Ʈ(��Ȱ��ȭ)
        #endregion

        //������ ��
        [SerializeField] GameObject bulletOrigin;                                    // �߻��� ������Ʈ
        [SerializeField] float objectSpeed; // �߻� ������Ʈ �ӵ�
                                            //Transform parentObject;                                     // �θ� ������Ʈ�� ������ ������Ʈ
        [SerializeField] int makeBulletCount = 10;                  // ������Ʈ Ǯ�� ũ��




        private void Start()
        {
            Initialize();
        }

        public void Initialize() //������Ʈ Ǯ ����
        {
            // 1. �ʱ� ���� �Լ�
            // 2. start ���ο��� ���� �ȴ�.
            // 3. ����� ������Ʈ�� ���� ���� �غ�.
            // 4. ������Ʈ Ǯ�� �����Ѵ�.

            //parentObject = parentTransform;   // �θ� �� ������Ʈ
            //bulletOrigin = bulletObject;    // ������ ������Ʈ ����
            MakeBullet(makeBulletCount);    // ������Ʈ �����ؼ� Ǯ�� �־��� �Լ�
        }

        void MakeBullet(int CreateCount) // ������Ʈ�� �����ؼ� Ǯ�� �־��ش�.
        {
            // 1. ī��Ʈ ��ŭ ������Ʈ Ǯ ����Ʈ�� �����Ѵ�.
            // 2. ���� �� ������Ʈ�� ���� �� �θ� ������Ʈ�� �ڽ� ������Ʈ �����Ѵ�.
            // 3. ���� �� ������Ʈ�� ��Ȱ��ȭ ó�� �Ѵ�.
            // 4. ������Ʈ Ǯ ����Ʈ�� ���� �� ������Ʈ�� �߰��Ѵ�.

            for (int i = 0; i < CreateCount; i++)
            {
                var reuseObject = Instantiate(bulletOrigin).GetComponent<ReuseObject>();  // ������Ʈ ���� , ���� �� ������Ʈ ������ �ϱ� ���� ����
                reuseObject.transform.parent = transform;               // ���� �� ������Ʈ�� �θ� ����
                reuseObject.speed = objectSpeed;
                reuseObject.gameObject.SetActive(false);                             // ���� ������Ʈ�� ��Ȱ��ȭ �ؼ� �����ش�.
                listPool.AddLast(reuseObject);                                       // ���� �� ���� �� ������Ʈ�� Ǯ�� �߰����ش�.

            }
        }

        public void ReturnBullet() // ���� �� ������Ʈ �߿� ���� ������Ʈ�� �ӽ� ����Ʈ�� �־��ִ� �Լ�
        {
            // 1. Ȱ��ȭ �� ����Ʈ���� �׾��ٰ� �Ǵ� �Ǵ� ������Ʈ�� ã�´�.
            // 2. Ȱ��ȭ ����Ʈ���� �����Ѵ�.
            // 3. ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
            // 4. ������Ʈ���� ���Ǵ� ���� �ʱ�ȭ�Ѵ�. (������Ʈ �ʱ�ȭ)

            foreach (var reuseObject in listActive) // Ȱ��ȭ �� ������Ʈ �� ���� �Ǵ��� �� �͵��� ��Ȱ��ȭ ����Ʈ�� �־��ش�.
            {
                if (reuseObject.isDie) // �Ѿ��� �׾��°�?
                {
                    listPool.AddLast(reuseObject);           // ������Ʈ Ǯ ����Ʈ�� �߰����ش�.
                                                             //listDeActive.AddLast(bullet);     // ��Ȱ��ȭ ����Ʈ�� �߰����ش�.
                    listActive.Remove(reuseObject);          // Ȱ��ȭ ����Ʈ������ �����Ѵ�.
                    reuseObject.gameObject.SetActive(false); // ������Ʈ�� ��Ȱ��ȭ ���ش�.
                    reuseObject.isDie = false;               // ������Ʈ�� ���� ���θ� �ٽ� false�� �ٲ��ش�.
                    break;
                }
            }

            #region Legacy Code (Not Use listDeActive)
            //foreach(var bullet in listDeActive)
            //{
            //    listPool.AddLast(bullet); // ��Ȱ��ȭ ����Ʈ���� ������Ʈ Ǯ ����Ʈ�� �߰����ش�.
            //    bullet.gameObject.SetActive(false); //��Ȱ��ȭ ���ش�.
            //    bullet.isDie = false; // ��Ȱ��ȭ �� ������Ʈ�� ���� ���θ� �ٽ� false �� �ٲ��ش�.
            //}
            //listDeActive.Clear(); // �ӽ� ����Ʈ���� Ǯ ����Ʈ�� �� �Ű���ٸ� ����Ʈ�� ����ش�.
            #endregion
        }

        public void EnableObject(Vector3 direction) // źȯ(������Ʈ)�߻� , Ȱ��ȭ �Լ�
        {
            // 1. ������Ʈ Ǯ ����Ʈ�� ī��Ʈ�� �˻��Ѵ�.
            // 2. ������Ʈ Ǯ ����Ʈ�� ��� ���� ��� ������Ʈ Ǯ ����Ʈ�� �߰� �����Ѵ�.
            // 3. Ȱ��ȭ �� ������Ʈ�� ������Ʈ Ǯ ����Ʈ���� �޾ƿ´�.
            // 4. �޾ƿ� ������Ʈ�� ������Ʈ Ǯ ����Ʈ���� �����Ѵ�.
            // 5. �޾ƿ� ������Ʈ�� ���� �������ְ� Ȱ��ȭ �Ѵ�.
            // 6. Ȱ��ȭ �� ������Ʈ�� Ȱ��ȭ ����Ʈ�� �߰��Ѵ�.

            if (listPool.Count == 0)
            {
                //���� ������� ���� �� �Ѿ��� ���� ��Ȱ��ȭ ó�� ���Ŀ� Ǯ�� ���ƿ��� ���� ����.
                MakeBullet(makeBulletCount);    // ������Ʈ Ǯ�� ī��Ʈ�� 0�� ���, ������Ʈ �߰� �����Ѵ�.
            }

            var reuseObject = listPool.First.Value;  // �߻� �� ������Ʈ�� Ǯ ����Ʈ���� �޾ƿ´�.
            listPool.RemoveFirst();             // �޾ƿ� ������Ʈ�� Ǯ���� �����Ѵ�.
            reuseObject.SetBullet(this.gameObject, direction, objectSpeed);  // �߻� �� ������Ʈ�� ���� ���� ���ش�.
            reuseObject.gameObject.SetActive(true);  // �߻� �� ������Ʈ Ȱ��ȭ
            listActive.AddLast(reuseObject);         // �߻��� ������Ʈ�� Ȱ��ȭ���� ������Ʈ ����Ʈ�� �߰����ش�.
        }

        #region Incomplete code (Pool Clear)
        //public void ClearPoolList() // ������Ʈ Ǯ ����Ʈ�� �ʱ�ȭ ���ش�.
        //{
        //    if(listPool.Count!=0)
        //    {
        //        foreach (var bullet in listPool)
        //        {
        //            Debug.Log(bullet.name + "����");
        //            Destroy(bullet);    // �ݺ��� ��ȸ, ��� ������Ʈ ����.
        //        }
        //        listPool.Clear();       // ����Ʈ ����
        //    }
        //}
        #endregion
    }
}