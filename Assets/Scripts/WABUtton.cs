using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WABUtton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenWA()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=+6281312977132&text=Terima%20kasih%20telah%20menghubungi%20kami.%0A%0AMohon%20hapus%20pesan%20ini%20jika%20Anda%20tidak%20mengalami%20kendala%20selama%20proses%20bermain%20games.%0A%0ANamun%20Jika%20Anda%20mengalami%20kendala,%20laporkan%20dengan%20mengisi%20form%20berikut%20Klik:%20https://forms.gle/wxSVV7pvDdg9VxSt5%0A%0ALaporan%20wajib%20kami%20terima%20maksimal%203%20jam%20setelah%20anda%20mengalami%20kendala.%0A%0AKami%20tidak%20menerima%20komunikasi%20via%20whatsapp%20ini%20dan%20juga%20media%20lainnya%20selain%20link%20aduan%20di%20atas.%0A%0ATerima%20kasih");
    }
}
