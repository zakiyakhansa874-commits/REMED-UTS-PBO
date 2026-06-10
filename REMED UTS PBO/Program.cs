using System;
using System.Collections.Generic;

// 4. ABSTRACTION
abstract class PesananTransportasi
{
    // 1. ENCAPSULATION 
    public string NamaPenumpang { get; set; }
    public string IdPesanan { get; set; }
    public string LokasiTujuan { get; set; }

    // Composition
    private List<RiwayatPerjalanan> daftarRiwayat = new List<RiwayatPerjalanan>();

    public PesananTransportasi(string namaPenumpang, string idPesanan, string lokasiTujuan)
    {
        NamaPenumpang = namaPenumpang;
        IdPesanan = idPesanan;
        LokasiTujuan = lokasiTujuan;
    }

    // Method umum
    public void TampilInfo()
    {
        Console.WriteLine("Nama: " + NamaPenumpang + " | ID: " + IdPesanan + " | Tujuan: " + LokasiTujuan);
    }

    // 3. POLYMORPHISM - method abstrak
    public abstract double HitungTarif(double jarakKm);

    // Composition methods
    public void TambahPerjalanan(string jenisLayanan, double jarakKm, string tanggalPesan)
    {
        daftarRiwayat.Add(new RiwayatPerjalanan(jenisLayanan, jarakKm, tanggalPesan));
    }

    public void CetakRiwayat()
    {
        for (int i = 0; i < daftarRiwayat.Count; i++)
        {
            Console.Write((i + 1) + ". ");
            daftarRiwayat[i].CetakRiwayat();
        }
    }
}

// 2. INHERITANCE
class LayananMotor : PesananTransportasi
{
    public double TarifPerKm { get; set; }

    public LayananMotor(string namaPenumpang, string idPesanan, string lokasiTujuan, double tarifPerKm)
        : base(namaPenumpang, idPesanan, lokasiTujuan)
    {
        TarifPerKm = tarifPerKm;
    }

    // 3. POLYMORPHISM - override
    public override double HitungTarif(double jarakKm)
    {
        return jarakKm * TarifPerKm;
    }
}

// 2. INHERITANCE
class LayananMobil : PesananTransportasi
{
    public double TarifPerKm { get; set; }
    public double BiayaTol { get; set; }

    public LayananMobil(string namaPenumpang, string idPesanan, string lokasiTujuan, double tarifPerKm, double biayaTol)
        : base(namaPenumpang, idPesanan, lokasiTujuan)
    {
        TarifPerKm = tarifPerKm;
        BiayaTol = biayaTol;
    }

    // 3. POLYMORPHISM - override
    public override double HitungTarif(double jarakKm)
    {
        return (jarakKm * TarifPerKm) + BiayaTol;
    }
}

// 5. COMPOSITION
class RiwayatPerjalanan
{
    public string JenisLayanan { get; set; }
    public double JarakKm { get; set; }
    public string TanggalPesan { get; set; }

    public RiwayatPerjalanan(string jenisLayanan, double jarakKm, string tanggalPesan)
    {
        JenisLayanan = jenisLayanan;
        JarakKm = jarakKm;
        TanggalPesan = tanggalPesan;
    }

    public void CetakRiwayat()
    {
        Console.WriteLine(JenisLayanan + " | " + JarakKm + " km | " + TanggalPesan);
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        LayananMobil pesanan1 = new LayananMobil("Budi", "TRX01", "Stasiun", 5000, 15000);
        double jarakKm = 10;

        pesanan1.TambahPerjalanan("Mobil", jarakKm, "10-10-2025");
        pesanan1.TampilInfo();
        Console.WriteLine("Total: Rp " + pesanan1.HitungTarif(jarakKm));
        pesanan1.CetakRiwayat();

        Console.WriteLine();

        LayananMotor pesanan2 = new LayananMotor("Ani", "TRX02", "Kampus", 3000);
        double jarakMotor = 8;

        pesanan2.TambahPerjalanan("Motor", jarakMotor, "11-10-2025");
        pesanan2.TampilInfo();
        Console.WriteLine("Total: Rp " + pesanan2.HitungTarif(jarakMotor));
        pesanan2.CetakRiwayat();

        Console.ReadKey();
    }
}