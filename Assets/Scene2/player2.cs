using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    Animator anim;
    Vector3 find;
    GameObject scanobject;
    public gamemanager2 manager;
    public Scene_Change2 scene_change;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        h = (scene_change.action || manager.isAction) ? 0 : Input.GetAxisRaw("Horizontal");
        v = (scene_change.action || manager.isAction) ? 0 : Input.GetAxisRaw("Vertical");

        bool hdown = (scene_change.action || manager.isAction) ? false : Input.GetButtonDown("Horizontal");
        bool hup = (scene_change.action || manager.isAction) ? false : Input.GetButtonUp("Horizontal");
        bool vdown = (scene_change.action || manager.isAction) ? false : Input.GetButtonDown("Vertical");
        bool vup = (scene_change.action || manager.isAction) ? false : Input.GetButtonUp("Vertical");

        if (hdown || vup)
            isHorizonMove = true;
        else if (vdown || hup)
            isHorizonMove = false;
        else if (hup || vup)
            isHorizonMove = h != 0;

        if (anim.GetInteger("horizontal") != h)
        {
            anim.SetBool("ischange", true);
            anim.SetInteger("horizontal", (int)h);
        }
        else if (anim.GetInteger("vertical") != v)
        {
            anim.SetBool("ischange", true);
            anim.SetInteger("vertical", (int)v);
        }
        else
            anim.SetBool("ischange", false);

        if (hdown && h == 1)
            find = Vector3.right;
        else if (hdown && h == -1)
            find = Vector3.left;
        else if (vdown && v == 1)
            find = Vector3.up;
        else if (vdown && v == -1)
            find = Vector3.down;

        if (Input.GetButtonDown("Jump") && scanobject != null)
        {
            if (scanobject.tag == "Scene_NPC")
            {
                scene_change.Scene_manage(1);
            }
            else
            {
                manager.Action(scanobject);
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direc = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = direc * speed;
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, find, 0.7f, LayerMask.GetMask("object"));

        if (rayHit.collider != null)
        {
            scanobject = rayHit.collider.gameObject;
        }
        else
            scanobject = null;
    }
}
