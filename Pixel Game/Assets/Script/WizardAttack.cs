using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    private GameObject Player;
    public float atk_time,count=0;
    private void Start()
    {
        Player = CharactorChangeCam.main;
    }
    private void FixedUpdate()
    {
        count += Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && count>=atk_time)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(PlayerWizard.PlayerDamage);
            count = 0;
        }
    }
}
