using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float tocDoXe = 100f; //toc do di chuyen cua chiec xe
    [SerializeField]
    private float lucReXe = 100f;
    [SerializeField]
    private float lucPhanh = 50f;
    [SerializeField]
    private GameObject hieuUngPhanh;
    private float dauVaoRe; //luu gia tri queo trai queo phai
    private float dauVaoDiChuyen; //de luu tru dau vao la 1 hay -1 de biet nguoi dung dang tien hay lui
    private Rigidbody rb; //su dung cac thanh phan vat ly

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        dauVaoDiChuyen = Input.GetAxis("Vertical"); //Di chuyen theo chieu doc
        dauVaoRe = Input.GetAxis("Horizontal");
        DiChuyenXe();
        ReXe();

        if (Input.GetKey(KeyCode.H) && dauVaoDiChuyen > 0)
        {
            PhanhXe();
        }
    }

    public void DiChuyenXe()
    {
        rb.AddRelativeForce(Vector3.forward * dauVaoDiChuyen * tocDoXe);
        hieuUngPhanh.SetActive(false);
    }

    public void ReXe()
    {
        Quaternion re = Quaternion.Euler(Vector3.up * dauVaoRe * lucReXe * Time.deltaTime);
        rb.MoveRotation(rb.rotation * re);
    }

    public void PhanhXe()
    {
        if (rb.velocity.z != 0) //kiem tra van toc khac ko
        {
            rb.AddRelativeForce(-Vector3.forward * lucPhanh);
            hieuUngPhanh.SetActive(true);
        }
    }
}
