using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timbuocnhay : MonoBehaviour
{
    public InputField Xvitridau, Yvitridau, Xvitricuoi, Yvitricuoi;
    private int xgoc, ygoc, xcuoi, ycuoi;
    private Rigidbody2D quanmabody;
    private Vector2[] Nhay = new Vector2[8];
    private Vector2[] Nhaylan1 = new Vector2[8];
    private Vector2[] Nhaylan2 = new Vector2[8 * 8];
    private Vector2[] Nhaylan3 = new Vector2[8 * 8 * 8];
    private Vector2[] Nhaylan4 = new Vector2[8 * 8 * 8 * 8];
    private Vector2[] Nhaylan5 = new Vector2[8 * 8 * 8 * 8 * 8];
    private Vector2[] Nhaylan6 = new Vector2[8 * 8 * 8 * 8 * 8 * 8];
    public GameObject nutdo;
    public Vector2 Vitrigoc;
    public Vector2 Vitricuoi;
    public int solannhay;
    private int j, k, l, m, n, b, c, d, e, f, kk, ll, mm, nn;
    private Vector2[] Odaqua = new Vector2[8*8];
    private Vector2[] Vitrima = new Vector2[7];
    public float xNhay1, yNhay1, xNhay2, yNhay2, xNhay3, yNhay3, xNhay4, yNhay4, xNhay5, yNhay5, xNhay6, yNhay6;
    bool nhaysonglan1;

    public void Timlan1()
    {
        quanmabody = GetComponent<Rigidbody2D>();
        Vitrigoc.x = xgoc;
        Vitrigoc.y = ygoc;
        Vitricuoi.x = xcuoi;
        Vitricuoi.y = ycuoi;
        nhaysonglan1 = false;
        j = k = l = m = n = b = c = d = e = f = kk = ll = mm = nn = 0;
        Nhay[0] = new Vector2(1f, 2f);
        Nhay[1] = new Vector2(2f, 1f);
        Nhay[2] = new Vector2(2f, -1f);
        Nhay[3] = new Vector2(1f, -2f);
        Nhay[4] = new Vector2(-1f, -2f);
        Nhay[5] = new Vector2(-2f, -1f);
        Nhay[6] = new Vector2(-2f, 1f);
        Nhay[7] = new Vector2(-1f, 2f);
        Nhaylan1[0] = Vitrigoc + Nhay[0];
        Nhaylan1[1] = Vitrigoc + Nhay[1];
        Nhaylan1[2] = Vitrigoc + Nhay[2];
        Nhaylan1[3] = Vitrigoc + Nhay[3];
        Nhaylan1[4] = Vitrigoc + Nhay[4];
        Nhaylan1[5] = Vitrigoc + Nhay[5];
        Nhaylan1[6] = Vitrigoc + Nhay[6];
        Nhaylan1[7] = Vitrigoc + Nhay[7];
        for (int ii = 0; ii < 64; ii++)
        {
           Odaqua[ii] = Vitrigoc;
           Vitrima[6] = new Vector2(Vitrigoc.x - 4, Vitrigoc.y - 4);
        }
        for (int i = 0; i < 8; i++)
        {
            
            if (Nhaylan1[i].x < 0 || Nhaylan1[i].y < 0 || Nhaylan1[i].x>7 || Nhaylan1[i].y > 7)
            {
               Nhaylan1[i] = Vitrigoc;
                continue;
            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan1[i] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan1[i];
                }
            }
            if (Nhaylan1[i] == Vitricuoi)
            {
                solannhay = 1;
                Debug.Log("Nhay lan 1 ok..................");
                xNhay1 = Nhaylan1[i].x;
                yNhay1 = Nhaylan1[i].y;
                nhaysonglan1 = true;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[i].x - 4), (Nhaylan1[i].y - 4));
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                StartCoroutine(Quanmacho());
                break;
            }
        }
        if (nhaysonglan1 == false)
        {

            Timbuocnhayquanma();
        }


    }
    void Timbuocnhayquanma()
    {
        for (int i = 0; i < 8*8*8*8*8*8; i++)
        {
            timkiem:
          
            Nhaylan2[k] = Nhaylan1[j] + Nhay[b];
            
            if (Nhaylan2[k].x < 0 || Nhaylan2[k].y < 0 || Nhaylan2[k].x > 7 || Nhaylan2[k].y > 7 )
            {
                Chaylan2();
                Chaylan3();
                Chaylan4();
                Chaylan5();
                continue;
            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan2[k] == Odaqua[ii])
                {
                    Chaylan2();
                    Chaylan3();
                    Chaylan4();
                    Chaylan5();
                    goto timkiem;
                }
                if (Nhaylan2[k] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan2[k];
                }
            }
            if (Nhaylan2[k] == Vitricuoi)
            {
                solannhay = 2;
                Debug.Log("Nhay lan 2 ok..................");
                xNhay1 = Nhaylan1[j].x;
                yNhay1 = Nhaylan1[j].y;
                xNhay2 = Nhaylan2[k].x;
                yNhay2 = Nhaylan2[k].y;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[j].x - 4), (Nhaylan1[j].y - 4));
                Vitrima[1] = quanmabody.position = new Vector2((Nhaylan2[k].x - 4), (Nhaylan2[k].y - 4));
                Vitrima[2] = Vitrima[3] = Vitrima[4] = Vitrima[5] = Vitrima[1];
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                Instantiate(nutdo, Vitrima[1], transform.rotation);
                StartCoroutine(Quanmacho());
                break;
            }

            Nhaylan3[l] = Nhaylan2[kk] + Nhay[c];
            
            if (Nhaylan3[l].x < 0 || Nhaylan3[l].y < 0 || Nhaylan3[l].x > 7 || Nhaylan3[l].y > 7 )
            {
                Chaylan2();
                Chaylan3();
                Chaylan4();
                Chaylan5();
                continue;
            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan3[l] == Odaqua[ii])
                {
                    Chaylan2();
                    Chaylan3();
                    Chaylan4();
                    Chaylan5();
                    goto timkiem;

                }
                if (Nhaylan3[l] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan3[l];
                }
            }
            if (Nhaylan3[l] == Vitricuoi)
            {
                solannhay = 3;
                Debug.Log("Nhay lan 3 ok..................");
                xNhay1 = Nhaylan1[j].x;
                yNhay1 = Nhaylan1[j].y;
                xNhay2 = Nhaylan2[k].x;
                yNhay2 = Nhaylan2[k].y;
                xNhay3 = Nhaylan3[l].x;
                yNhay3 = Nhaylan3[l].y;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[j].x - 4), (Nhaylan1[j].y - 4));
                Vitrima[1] = quanmabody.position = new Vector2((Nhaylan2[k].x - 4), (Nhaylan2[k].y - 4));
                Vitrima[2] = quanmabody.position = new Vector2((Nhaylan3[l].x - 4), (Nhaylan3[l].y - 4));
                Vitrima[3] = Vitrima[4] = Vitrima[5] = Vitrima[2];
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                Instantiate(nutdo, Vitrima[1], transform.rotation);
                Instantiate(nutdo, Vitrima[2], transform.rotation);

                StartCoroutine(Quanmacho());
                break;
            }
            Nhaylan4[m] = Nhaylan3[ll] + Nhay[d];
          
            if (Nhaylan4[m].x < 0 || Nhaylan4[m].y < 0 || Nhaylan4[m].x > 7 || Nhaylan4[m].y > 7 )
            {
                Chaylan2();
                Chaylan3();
                Chaylan4();
                Chaylan5();
                continue;
            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan4[m] == Odaqua[ii])
                {
                    Chaylan2();
                    Chaylan3();
                    Chaylan4();
                    Chaylan5();
                    goto timkiem;
                }
                if (Nhaylan4[m] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan4[m];
                }
            }
            if (Nhaylan4[m] == Vitricuoi)
            {
                //solannhay = 4;
                Debug.Log("Nhay lan 4 ok..................");
                xNhay1 = Nhaylan1[j].x;
                yNhay1 = Nhaylan1[j].y;
                xNhay2 = Nhaylan2[k].x;
                yNhay2 = Nhaylan2[k].y;
                xNhay3 = Nhaylan3[l].x;
                yNhay3 = Nhaylan3[l].y;
                xNhay4 = Nhaylan4[m].x;
                yNhay4 = Nhaylan4[m].y;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[j].x - 4), (Nhaylan1[j].y - 4));
                Vitrima[1] = quanmabody.position = new Vector2((Nhaylan2[k].x - 4), (Nhaylan2[k].y - 4));
                Vitrima[2] = quanmabody.position = new Vector2((Nhaylan3[l].x - 4), (Nhaylan3[l].y - 4));
                Vitrima[3] = quanmabody.position = new Vector2((Nhaylan4[m].x - 4), (Nhaylan4[m].y - 4));
                Vitrima[4] = Vitrima[5] = Vitrima[3];
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                Instantiate(nutdo, Vitrima[1], transform.rotation);
                Instantiate(nutdo, Vitrima[2], transform.rotation);
                Instantiate(nutdo, Vitrima[3], transform.rotation);


                StartCoroutine(Quanmacho());
                break;
            }
            Nhaylan5[n] = Nhaylan4[mm] + Nhay[e];
         
            if (Nhaylan5[n].x < 0 || Nhaylan5[n].y < 0 || Nhaylan5[n].x > 7 || Nhaylan5[n].y > 7 )
            {
                Chaylan2();
                Chaylan3();
                Chaylan4();
                Chaylan5();
                continue;
            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan5[n] == Odaqua[ii])
                {
                    Chaylan2();
                    Chaylan3();
                    Chaylan4();
                    Chaylan5();
                    goto timkiem;
                }
                if (Nhaylan5[n] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan5[n];
                }
            }
            if (Nhaylan5[n] == Vitricuoi)
            {
                solannhay = 5;
                Debug.Log("Nhay lan 5 ok..................");
                xNhay1 = Nhaylan1[j].x;
                yNhay1 = Nhaylan1[j].y;
                xNhay2 = Nhaylan2[k].x;
                yNhay2 = Nhaylan2[k].y;
                xNhay3 = Nhaylan3[l].x;
                yNhay3 = Nhaylan3[l].y;
                xNhay4 = Nhaylan4[m].x;
                yNhay4 = Nhaylan4[m].y;
                xNhay5 = Nhaylan5[n].x;
                yNhay5 = Nhaylan5[n].y;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[j].x - 4), (Nhaylan1[j].y - 4));
                Vitrima[1] = quanmabody.position = new Vector2((Nhaylan2[k].x - 4), (Nhaylan2[k].y - 4));
                Vitrima[2] = quanmabody.position = new Vector2((Nhaylan3[l].x - 4), (Nhaylan3[l].y - 4));
                Vitrima[3] = quanmabody.position = new Vector2((Nhaylan4[m].x - 4), (Nhaylan4[m].y - 4));
                Vitrima[4] = quanmabody.position = new Vector2((Nhaylan5[n].x - 4), (Nhaylan5[n].y - 4));
                Vitrima[5] = Vitrima[4];
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                Instantiate(nutdo, Vitrima[1], transform.rotation);
                Instantiate(nutdo, Vitrima[2], transform.rotation);
                Instantiate(nutdo, Vitrima[3], transform.rotation);
                Instantiate(nutdo, Vitrima[4], transform.rotation);


                StartCoroutine(Quanmacho());
                break;
            }
            Nhaylan6[i] = Nhaylan5[nn] + Nhay[f];
            

            if (Nhaylan6[i].x < 0 || Nhaylan6[i].y < 0 || Nhaylan6[i].x > 7 || Nhaylan6[i].y > 7 )
            {
                Chaylan2();
                Chaylan3();
                Chaylan4();
                Chaylan5();
                goto timkiem;

            }
            for (int ii = 0; ii < 64; ii++)
            {
                if (Nhaylan6[i] == Odaqua[ii])
                {
                    Chaylan2();
                    Chaylan3();
                    Chaylan4();
                    Chaylan5();
                    goto timkiem;
                }
                if (Nhaylan6[i] != Odaqua[ii])
                {
                    Odaqua[ii] = Nhaylan6[i];
                }
            }
            if (Nhaylan6[i] == Vitricuoi)
            {
                solannhay = 6;
                Debug.Log("Nhay lan 6 ok..................");
                xNhay1 = Nhaylan1[j].x;
                yNhay1 = Nhaylan1[j].y;
                xNhay2 = Nhaylan2[k].x;
                yNhay2 = Nhaylan2[k].y;
                xNhay3 = Nhaylan3[l].x;
                yNhay3 = Nhaylan3[l].y;
                xNhay4 = Nhaylan4[m].x;
                yNhay4 = Nhaylan4[m].y;
                xNhay5 = Nhaylan5[n].x;
                yNhay5 = Nhaylan5[n].y;
                xNhay6 = Nhaylan6[i].x;
                yNhay6 = Nhaylan6[i].y;
                Vitrima[0] = quanmabody.position = new Vector2((Nhaylan1[j].x - 4), (Nhaylan1[j].y - 4));
                Vitrima[1] = quanmabody.position = new Vector2((Nhaylan2[k].x - 4), (Nhaylan2[k].y - 4));
                Vitrima[2] = quanmabody.position = new Vector2((Nhaylan3[l].x - 4), (Nhaylan3[l].y - 4));
                Vitrima[3] = quanmabody.position = new Vector2((Nhaylan4[m].x - 4), (Nhaylan4[m].y - 4));
                Vitrima[4] = quanmabody.position = new Vector2((Nhaylan5[n].x - 4), (Nhaylan5[n].y - 4));
                Vitrima[5] = quanmabody.position = new Vector2((Nhaylan6[i].x - 4), (Nhaylan6[i].y - 4));
                Instantiate(nutdo, Vitrima[6], transform.rotation);
                Instantiate(nutdo, Vitrima[0], transform.rotation);
                Instantiate(nutdo, Vitrima[1], transform.rotation);
                Instantiate(nutdo, Vitrima[2], transform.rotation);
                Instantiate(nutdo, Vitrima[3], transform.rotation);
                Instantiate(nutdo, Vitrima[4], transform.rotation);
                Instantiate(nutdo, Vitrima[5], transform.rotation);

                StartCoroutine(Quanmacho());
                break;
            }
            Chaylan2();
            Chaylan3();
            Chaylan4();
            Chaylan5();
        }
    }
    void Chaylan2()
    {
        b = b + 1;
        k = k + 1;
        if (b == 8)
        {
            j = j + 1;
            b = 0;
        }
        if (j == 8)
        {
            j = 0;
        }
        if (k == 8 * 8)
        {
            k = 0;
        }

    }
    void Chaylan3()
    {
        c = c + 1;
        l = l + 1;
        if (c == 8)
        {
            kk = kk + 1;
            c = 0;
        }
        if (kk == 8 * 8)
        {
            kk = 0;
        }
        if (l == 8 * 8 * 8)
        {
            l = 0;
        }

    }
    void Chaylan4()
    {
        d = d + 1;
        m = m + 1;

        if (d == 8)
        {
            ll = ll + 1;
            d = 0;
        }
        if (ll == 8 * 8 * 8)
        {
            ll = 0;
        }
        if (m == 8 * 8 * 8 * 8)
        {
            m = 0;
        }

    }
    void Chaylan5()
    {
        e = e + 1;
        n = n + 1;
        if (e == 8)
        {
            mm = mm + 1;
            e = 0;
        }
        if (mm == 8 * 8 * 8 * 8)
        {
            mm = 0;
        }
        if (n == 8 * 8 * 8 * 8 * 8)
        {
            n = 0;
        }

    }
    void Chaylan6()
    {
        f = f + 1;
        if (f == 8)
        {
            nn = nn + 1;
            f = 0;
        }
        if (nn == 8 * 8 * 8 * 8 * 8)
        {
            nn = 0;
        }
    }
    IEnumerator Quanmacho()
    {
        yield return new WaitForSeconds(0);
        while(true)
        {
            //yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[6];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[0];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[1];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[2];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[3];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[4];
            yield return new WaitForSeconds(3);
            quanmabody.position = Vitrima[5];
            yield return new WaitForSeconds(30);


        }
    }
    public void Stopall()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void Nhapgiatri()
    {
        xgoc = int.Parse(Xvitridau.text);
        ygoc = int.Parse(Yvitridau.text);
        xcuoi = int.Parse(Xvitricuoi.text);
        ycuoi = int.Parse(Yvitricuoi.text);
    }

}
