using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraSetting : MonoBehaviour
{
    //���徵ͷ���ɫ�ĳ�ʼ����
    public float m_distanceAway = 4.5f;
    //��ͷ��ʼ�߶�
    public float m_distanceUp = 1.5f;
    //��ͷ�ı�ʱ��ƽ����
    private float m_smooth = 5f;
    //��Ҷ���
    public Transform m_player;



    //�Լ�
    private Transform m_transsform;

    private float maxSuo = 100.0f;//��ͷ���ŷ�Χ
    private float minSuo = 2.0f;

    private float maxSD = 20.0f;
    private float minSD = 1f;
    //��ֱ����ƫ��
    private float offset=0f;

    //������ת������
    public float m_sensitivityY = 0.1f;

    //������ת��������
    public float m_minimumY = -45f;
    public float m_maximumY = 45f;

    



    void Start()
    {
        m_transsform = this.transform;//�����Լ�
       // m_player = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {

       

        Zoom();//����
        CameraSet();//�������
        //����һ������
        RaycastHit hit;
        if (Physics.Linecast(m_player.position + Vector3.up, m_transsform.position, out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                //���������ײ�Ĳ����������ô��ȡ��������ײ�㵽��ҵľ���
                float currentDistance = Vector3.Distance(hit.point, m_player.position);
                //���������ײ��С���������������ľ��룬��˵����ɫ������ж�����Ϊ�˱��⴩ǽ���Ͱ��������
                if (currentDistance < m_distanceAway)
                {
                    m_transsform.position = hit.point;
                }
            }
        }
       




    }
    /// <summary>
    /// �������
    /// </summary>
    void CameraSet()
    {

        offset += Input.GetAxis("Mouse Y") * m_sensitivityY;
        offset = Mathf.Clamp(offset, m_minimumY, m_maximumY);


        //ȡ�������ת�ĽǶ�
        float m_wangtedRotationAngel = m_player.transform.eulerAngles.y;

        //��ȡ����ƶ��ĸ߶�
        float m_wangtedHeight = m_player.transform.position.y + m_distanceUp;
        //��������ǰ�Ƕ�
        float m_currentRotationAngle = m_transsform.eulerAngles.y;

        
        //��ȡ�����ǰ�ĸ߶�
        float m_currentHeight = m_transsform.position.y;
        //��һ��ʱ���ڽ���ǰ�Ƕȸ���Ϊ��ɫ��ԵĽǶ�
        m_currentRotationAngle = Mathf.LerpAngle(m_currentRotationAngle, m_wangtedRotationAngel, m_smooth * Time.deltaTime);

        //���ĵ�ǰ�߶�
        m_currentHeight = Mathf.Lerp(m_currentHeight, m_wangtedHeight, m_smooth * Time.deltaTime);
        //����һ��Y����ת��ҵ�ǰ�Ƕ���ô��Ķ���
        Quaternion m_currentRotation = Quaternion.Euler(0, m_currentRotationAngle, 0);
        
        //��ҵ�λ��
        Vector3 m_position = m_player.transform.position;
        //���λ�ò����������
        m_position -= m_currentRotation * Vector3.forward * m_distanceAway;
        //�����Ӧ������ĸ߶ȼӽ�Ӧ����������꣬������������λ��
        m_position = new Vector3(m_position.x, m_currentHeight, m_position.z);
        m_transsform.position = Vector3.Lerp(m_transsform.position, m_position, Time.time);
        

        //����ע�ӵ㣬ע�ӵ��ܴ�ֱƫ��Ӱ��
        Vector3 player1 = m_player.transform.position; 

        player1= new Vector3(player1.x, player1.y+ offset, player1.z);

        //ע��ע�ӵ�
        m_transsform.LookAt(player1);

    }

    /// <summary>
    /// ������������
    /// </summary>
    void Zoom()
    {
        //ʵ�ֻ����϶�
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= maxSuo)//���ŵķ�Χ
            {
                Camera.main.fieldOfView += 2;
            }
            if (Camera.main.orthographicSize <= maxSD)
            {
                Camera.main.orthographicSize += 0.5f;
            }
        }

        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView >= minSuo)
            {
                Camera.main.fieldOfView -= 2;
            }
            if (Camera.main.orthographicSize >= minSD)
            {
                Camera.main.orthographicSize -= 0.5f;
            }
        }
    }
}