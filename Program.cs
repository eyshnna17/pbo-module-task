using System;
using System.Collections.Generic;

// ============================================================
//  TUGAS PBO - Perpustakaan Digital
//  Nama Project : PerpustakaanDigital
// ============================================================

// ─────────────────────────────────────────
//  Kelas Dasar: Item
// ─────────────────────────────────────────
class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual string Deskripsi()
    {
        return $"[Item] Judul: {Judul}, Tahun: {Tahun}";
    }

    public void InfoItem()
    {
        Console.WriteLine("==============================");
        Console.WriteLine(Deskripsi());
        Console.WriteLine("==============================");
    }
}

// ─────────────────────────────────────────
//  Kelas Buku (mewarisi Item)
// ─────────────────────────────────────────
class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"  >> Penulis buku '{Judul}' adalah: {Penulis}");
    }

    public override string Deskripsi()
    {
        return $"[Buku] Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}";
    }
}

// ─────────────────────────────────────────
//  Kelas Majalah (mewarisi Item)
// ─────────────────────────────────────────
class Majalah : Item
{
    public string Edisi { get; set; }

    public Majalah(string judul, int tahun, string edisi) : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"  >> Edisi majalah '{Judul}': {Edisi}");
    }

    public override string Deskripsi()
    {
        return $"[Majalah] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

// ─────────────────────────────────────────
//  Kelas Novel (mewarisi Buku)
// ─────────────────────────────────────────
class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void BacaSinopsis()
    {
        Console.WriteLine($"  >> [Novel] Membaca sinopsis '{Judul}'...");
        Console.WriteLine($"     Sebuah novel karya {Penulis} yang diterbitkan tahun {Tahun}.");
    }

    public override string Deskripsi()
    {
        return $"[Novel] Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}";
    }
}

// ─────────────────────────────────────────
//  Kelas Komik (mewarisi Buku)
// ─────────────────────────────────────────
class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"  >> [Komik] Menampilkan ilustrasi '{Judul}'...");
        Console.WriteLine($"     Komik bergambar karya {Penulis}, terbit {Tahun}.");
    }

    public override string Deskripsi()
    {
        return $"[Komik] Judul: {Judul}, Tahun: {Tahun}, Ilustrator/Penulis: {Penulis}";
    }
}

// ─────────────────────────────────────────
//  Kelas MajalahAnak (mewarisi Majalah)
// ─────────────────────────────────────────
class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, string edisi) : base(judul, tahun, edisi) { }

    public void KategoriAnak()
    {
        Console.WriteLine($"  >> [MajalahAnak] '{Judul}' edisi {Edisi} - Kategori: Bacaan Anak Usia 5-12 Tahun");
    }

    public override string Deskripsi()
    {
        return $"[MajalahAnak] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

// ─────────────────────────────────────────
//  Kelas MajalahTeknologi (mewarisi Majalah)
// ─────────────────────────────────────────
class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, string edisi) : base(judul, tahun, edisi) { }

    public void TopikTeknologi()
    {
        Console.WriteLine($"  >> [MajalahTeknologi] '{Judul}' edisi {Edisi} - Topik: AI, Cloud Computing, Cybersecurity");
    }

    public override string Deskripsi()
    {
        return $"[MajalahTeknologi] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

// ─────────────────────────────────────────
//  Kelas Perpustakaan
// ─────────────────────────────────────────
class Perpustakaan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
        Console.WriteLine($"  Item '{item.Judul}' berhasil ditambahkan.");
    }

    public void DaftarItem()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine("     DAFTAR KOLEKSI PERPUSTAKAAN");
        Console.WriteLine("==========================================");

        if (koleksi.Count == 0)
        {
            Console.WriteLine("  (Koleksi kosong)");
            return;
        }

        for (int i = 0; i < koleksi.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {koleksi[i].Deskripsi()}");
        }
        Console.WriteLine($"\n  Total koleksi: {koleksi.Count} item");
    }

    public List<Item> GetKoleksi() => koleksi;
}

// ─────────────────────────────────────────
//  Program Utama
// ─────────────────────────────────────────
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("   SISTEM PERPUSTAKAAN DIGITAL - PBO");
        Console.WriteLine("==========================================\n");

        // a. Buat objek Perpustakaan
        Console.WriteLine(">>> a. Membuat objek Perpustakaan...");
        Perpustakaan perpus = new Perpustakaan();

        // b. Buat beberapa objek item
        Console.WriteLine("\n>>> b. Membuat objek-objek Item...");
        Novel novel1 = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
        Novel novel2 = new Novel("Bumi Manusia", 1980, "Pramoedya Ananta Toer");
        Komik komik1 = new Komik("Naruto Vol.1", 1999, "Masashi Kishimoto");
        Buku buku1 = new Buku("Pemrograman C#", 2022, "Doni Kusuma");
        Majalah maj1 = new Majalah("National Geographic", 2023, "Januari 2023");
        MajalahAnak majA = new MajalahAnak("Bobo", 2024, "Maret 2024");
        MajalahTeknologi majT = new MajalahTeknologi("InfoKomputer", 2024, "April 2024");

        // c. Tambahkan ke perpustakaan
        Console.WriteLine("\n>>> c. Menambahkan item ke Perpustakaan...");
        perpus.TambahItem(novel1);
        perpus.TambahItem(novel2);
        perpus.TambahItem(komik1);
        perpus.TambahItem(buku1);
        perpus.TambahItem(maj1);
        perpus.TambahItem(majA);
        perpus.TambahItem(majT);

        // d. Tampilkan semua data
        Console.WriteLine("\n>>> d. Menampilkan semua data...");
        perpus.DaftarItem();

        // e. Demonstrasi Polymorphism
        Console.WriteLine("\n\n>>> e. DEMONSTRASI POLYMORPHISM");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("  Memanggil Deskripsi() via referensi tipe Item:\n");

        foreach (Item item in perpus.GetKoleksi())
        {
            Console.WriteLine($"  -> {item.Deskripsi()}");
        }

        Console.WriteLine("\n  Polymorphism via InfoItem() (referensi Item -> objek Novel):");
        Item refItem = novel1;
        refItem.InfoItem();

        // f. Panggil method khusus
        Console.WriteLine("\n>>> f. MEMANGGIL METHOD KHUSUS TIAP KELAS");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine("\n[Novel - BacaSinopsis()]");
        novel1.BacaSinopsis();
        novel2.BacaSinopsis();

        Console.WriteLine("\n[Komik - TampilkanIlustrasi()]");
        komik1.TampilkanIlustrasi();

        Console.WriteLine("\n[Buku - CekPenulis()]");
        buku1.CekPenulis();

        Console.WriteLine("\n[Majalah - InfoEdisi()]");
        maj1.InfoEdisi();

        Console.WriteLine("\n[MajalahAnak - KategoriAnak()]");
        majA.KategoriAnak();

        Console.WriteLine("\n[MajalahTeknologi - TopikTeknologi()]");
        majT.TopikTeknologi();

        
    }
}