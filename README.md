# Proje ve Çalışan Yönetim Sistemi

[![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.7.2-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0%2B-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)](https://learn.microsoft.com/dotnet/desktop/winforms/)

C# Windows Forms ve MySQL kullanılarak geliştirilmiş; çalışan, proje ve kullanıcı yönetimini tek bir merkezde toplayan masaüstü yönetim uygulamasıdır. Proje, tüm veritabanı işlemlerini **MySQL Saklı Yordamları (Stored Procedures)** ve parametrik sorgular üzerinden yürüterek yüksek veri güvenliği ve SQL Injection koruması sağlar.

---

## Mimari Yapı

Uygulama, sorumlulukların ayrıldığı katmanlı bir yaklaşımla tasarlanmıştır:

```mermaid
flowchart TD
    subgraph UI ["Sunum Katmani (Windows Forms UI)"]
        F1["Ana Menü / Kontrol Paneli (Form1)"]
        F2["Çalışan Yönetim Formu (CalisanFormu)"]
        F3["Proje Tanımlama Formu (ProjeEklemeFormu)"]
        F4["Kullanıcı Kayıt Formu (YeniKullaniciEkle)"]
    end

    subgraph DAL ["Veri Erişim Katmanı (DAL)"]
        DBC["Veritabanı Yöneticisi (DbConnectorManager)<br/>App.config Bağlantı Yönetimi"]
    end

    subgraph DB_LAYER ["Veritabanı Katmanı (MySQL Database)"]
        DB[("MySQL Database: databaseproje")]
        SP["Saklı Yordamlar (Stored Procedures)<br/>• CalisanlariListele • CalisanEkle<br/>• CalisanSil • CalisanGuncelle<br/>• ProjeleriListele • ProjeEkle"]
    end

    F1 --> F2
    F1 --> F3
    F1 --> F4
    F2 --> DBC
    F3 --> DBC
    F4 --> DBC
    DBC --> SP
    SP <--> DB
```

---

## Temel Özellikler

- **Çalışan Yönetimi (CRUD):**
  - Firma personelini unvan ve pozisyon bilgileriyle sisteme kaydetme.
  - Var olan çalışanların pozisyon ve ad-soyad bilgilerini güncelleme.
  - Yanlışlıkla silinmeleri önleyen kullanıcı onaylı (DialogResult) silme mekanizması.
  - Verileri dinamik olarak `DataGridView` üzerinde anlık listeleme.
- **Proje Takip ve Planlama:**
  - Proje adı, başlangıç ve bitiş tarihlerini belirleyerek yeni proje oluşturma.
  - Başlangıç ve bitiş tarihleri için mantıksal doğrulama (başlangıç tarihi bitiş tarihinden sonra olamaz).
  - Projeleri yöneticileriyle birlikte listeleme.
- **Kullanıcı Kayıt & Doğrulama:**
  - Regex tabanlı e-posta format doğrulaması (`IsValidEmail`).
  - Parola ve parola tekrarı eşleşme kontrolü.
  - Veritabanı düzeyinde tekil kullanıcı adı ve e-posta kontrolü.
- **Güvenli Veri Erişimi:**
  - `DbConnectorManager` üzerinden merkezi bağlantı yönetimi.
  - Hassas veritabanı şifrelerinin kod içerisinden temizlenip `App.config` dosyasında yapılandırılması.
  - Parametrik saklı yordam (Stored Procedure) kullanımı ile tam SQL Injection koruması.

---

## Proje Dizin Yapısı

```text
├── database/
│   └── schema.sql              # Tablolar, ilişkiler, saklı yordamlar ve seed veriler
├── ProjeYonetimSistemi/
│   ├── CalisanFormu.cs         # Personel yönetim arayüzü ve CRUD olayları
│   ├── ProjeEklemeFormu.cs     # Proje oluşturma ve listeleme arayüzü
│   ├── YeniKullaniciEkle.cs    # Kullanıcı kayıt ve doğrulama arayüzü
│   ├── Form1.cs                # Ana gösterge paneli ve form navigasyonu
│   ├── DbConnectorManager.cs   # MySQL ADO.NET veri erişim yöneticisi
│   ├── App.config              # Veritabanı bağlantı dizesi konfigürasyonu
│   ├── packages.config         # NuGet paket bağımlılıkları (MySql.Data vb.)
│   └── ProjeYonetimSistemi.csproj
├── ProjeYonetimSistemi.sln     # Visual Studio çözüm dosyası
├── .gitignore                  # Visual Studio ve geçici derleme dosyaları filtreleri
└── README.md
```

---

## Kurulum ve Çalıştırma

### 1. Gereksinimler
- **Visual Studio 2019 / 2022** (.NET masaüstü geliştirme iş yükü yüklü olmalıdır)
- **.NET Framework 4.7.2** veya üzeri
- **MySQL Server 8.x** veya **MariaDB** (veya XAMPP / WampServer)

### 2. Veritabanının Kurulması
1. MySQL Workbench veya phpMyAdmin arayüzünü açın.
2. Proje dizinindeki [`database/schema.sql`](database/schema.sql) dosyasını çalıştırın:
   ```sql
   source /dosya/yolu/database/schema.sql;
   ```
   *Bu komut `databaseproje` veritabanını, gerekli tabloları, saklı yordamları ve başlangıç örnek verilerini otomatik olarak oluşturacaktır.*

### 3. Bağlantı Ayarlarının Yapılması
`ProjeYonetimSistemi/App.config` dosyasını açarak kendi yerel MySQL sunucu kullanıcı adı ve şifrenizi girin:
```xml
<connectionStrings>
    <add name="DefaultConnection" 
         connectionString="Server=localhost;Database=databaseproje;Uid=root;Pwd=SIFRENIZ;" 
         providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

### 4. Projeyi Derleme ve Çalıştırma
1. `ProjeYonetimSistemi.sln` çözüm dosyasını Visual Studio ile açın.
2. NuGet paketlerinin geri yüklenmesi için projeye sağ tıklayıp **Restore NuGet Packages** seçeneğini kullanın.
3. **F5** veya **Start** tuşuna basarak projeyi başlatın.
