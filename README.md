# SDTur - Tur Şirketi Otomasyon Sistemi

SDTur, turizm firmaları için geliştirilmiş, modern ve çok katmanlı bir otomasyon sistemidir. Turların, biletlerin, operasyonların, finansal işlemlerin ve raporlamanın merkezi olarak yönetilmesini sağlar. Proje, .NET 9 tabanlıdır ve hem RESTful API hem de MVC tabanlı web arayüzü içerir.

### ⚠️ Önemli Not
Bu proje geliştirme aşamasındadır. Kurulum ve kullanım sırasında karşılaşabileceğiniz sorunlar için [Issues](https://github.com/SametDulger/SD_Tur/issues) sayfasını kontrol edebilir veya yeni issue açabilirsiniz.


## 🏗️ Proje Yapısı

```
SDTur.sln
│
├── SDTur.Core/           # Temel varlıklar (Entities) ve arayüzler (Interfaces)
├── SDTur.Infrastructure/ # Entity Framework Core, DbContext, Repository, UnitOfWork, Migrations
├── SDTur.Application/    # DTO'lar, Servisler, Mapping, İş kuralları
├── SDTur.API/            # RESTful Web API (Swagger/OpenAPI desteğiyle)
└── SDTur.Web/            # MVC Web arayüzü (Razor Views, Controller, wwwroot)
```

## 📋 Katmanlar ve Görevleri

### SDTur.Core
- Tüm domain varlıkları (32 entity)
- Repository arayüzleri
- BaseEntity sınıfı (ortak özellikler)

### SDTur.Infrastructure
- Entity Framework Core konfigürasyonu
- DbContext ve migration'lar
- Repository implementasyonları (32 repository)
- UnitOfWork pattern

### SDTur.Application
- DTO'lar (Data Transfer Objects) - 50+ DTO
- İş servisleri ve arayüzleri (32 servis)
- AutoMapper profilleri
- İş kuralları

### SDTur.API
- RESTful Web API (32 controller)
- Swagger/OpenAPI dökümantasyonu
- CORS desteği
- Tüm CRUD operasyonları

### SDTur.Web
- MVC web arayüzü (32 controller)
- Razor Views
- API ile HTTP client haberleşmesi
- Responsive tasarım

## 🚀 Temel Özellikler

### Tur Yönetimi
- Tur oluşturma, düzenleme, silme
- Tur programları ve servis programları
- Bilet yönetimi ve satış işlemleri
- Tur operasyonları takibi

### İşletme Yönetimi
- Şube yönetimi
- Çalışan yönetimi
- Bölge ve otel yönetimi
- Otobüs ve otobüs atama işlemleri

### Finansal İşlemler
- Tur gelirleri ve giderleri
- Hesap işlemleri
- Döviz kurları
- Fatura yönetimi
- Komisyon hesaplamaları

### Raporlama
- Tur raporları
- Finansal raporlar
- Müşteri dağılım raporları
- Sistem logları

### Sistem Yönetimi
- Kullanıcı yönetimi
- Uyruk ve para birimi yönetimi
- Pas şirketi ve anlaşma yönetimi

## 🛠️ Teknolojiler

- **Backend**: .NET 9, ASP.NET Core MVC, Entity Framework Core 9.0.7
- **Frontend**: Bootstrap, jQuery, FontAwesome 5.15.4
- **API**: Swagger/OpenAPI 9.0.3, RESTful
- **Veritabanı**: SQL Server
- **Mapping**: AutoMapper 12.0.1
- **Mimari**: Clean Architecture, Repository Pattern, Unit of Work, CORS

## 📦 Kurulum


### Gereksinimler
- .NET 9 SDK
- SQL Server (Express veya üstü)
- Visual Studio 2022+ veya JetBrains Rider

### Adımlar

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/SametDulger/SD_Tur.git
   cd SD_Tur
   ```

2. **Veritabanını oluşturun**
   ```bash
   dotnet ef database update --project SDTur.Infrastructure
   ```

3. **Bağlantı ayarlarını güncelleyin**
   `SDTur.API/appsettings.json` dosyasındaki `DefaultConnection` string'ini kendi SQL Server instance'ınıza göre ayarlayın.

4. **Uygulamaları çalıştırın**
   ```bash
   # API'yi çalıştırın
   dotnet run --project SDTur.API
   
   # Web uygulamasını çalıştırın (yeni terminal)
   dotnet run --project SDTur.Web
   ```

5. **Erişim**
   - API: https://localhost:7275 (Swagger UI: https://localhost:7275/swagger)
   - Web: https://localhost:7290

## 🔧 Konfigürasyon

### API Ayarları
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=SDTurDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

### Web Ayarları
```json
{
  "ApiBaseUrl": "http://localhost:5018/"
}
```

## 📊 Veritabanı Şeması

Sistem 32 tablo içerir:
- **Tur İşlemleri**: Tours, TourSchedules, ServiceSchedules, Tickets, TourOperations
- **İşletme**: Branches, Employees, Regions, Hotels, Buses, BusAssignments
- **Finans**: Accounts, AccountTransactions, TourExpenses, TourIncomes, Cash, Invoices, InvoiceDetails
- **Raporlama**: Reports, TourReports, FinancialReports, SystemLogs, CommissionCalculations, CustomerDistributions
- **Sistem**: Users, Nationalities, Currencies, ExchangeRates, PassCompanies, PassAgreements

## 🔐 Güvenlik

- Soft delete (kayıtlar fiziksel olarak silinmez)
- CORS politikaları (AllowAll)
- Input validation
- SQL injection koruması (EF Core)
- HTTP Client ile API haberleşmesi

## 📱 Arayüz Özellikleri

- Modern ve responsive tasarım
- Dashboard odaklı ana sayfa
- Dropdown menüler ile kolay navigasyon
- CRUD işlemleri için tam form desteği
- Bootstrap ile mobil uyumlu
- FontAwesome 5.15.4 ikonları

## 🚀 Geliştirme

### Yeni Migration Oluşturma
```bash
dotnet ef migrations add MigrationName --project SDTur.Infrastructure
```

### Projeyi Derleme
```bash
dotnet build
```

### Test Çalıştırma
```bash
dotnet test
```

### ⚠️ Geliştirici Notları
- Proje henüz test coverage'a sahip değildir
- Yeni özellik eklerken mevcut CRUD yapısını takip edin
- API endpoint'leri için Swagger dokümantasyonunu güncelleyin
- Veritabanı değişikliklerinde migration oluşturun

## 📝 API Dökümantasyonu

API'yi çalıştırdıktan sonra Swagger UI'a erişerek tüm endpoint'leri görebilir ve test edebilirsiniz:
- https://localhost:7275/swagger

## 🤝 Katkıda Bulunma

1. Fork'layın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

## ⚠️ Geliştirme Durumu

### Mevcut Durum
- ✅ Temel CRUD işlemleri tamamlandı
- ✅ API ve Web arayüzü çalışır durumda
- ✅ Veritabanı şeması oluşturuldu
- 🔄 Bazı özellikler geliştirme aşamasında
- ⚠️ Test coverage eksik
- ⚠️ Dokümantasyon güncelleniyor

### Bilinen Sorunlar
- Bazı form validasyonları eksik olabilir
- Hata yönetimi geliştirilmeli
- Performance optimizasyonları yapılmalı
- Güvenlik testleri tamamlanmalı

### Katkıda Bulunma
Bu proje aktif geliştirme aşamasındadır. Katkıda bulunmak istiyorsanız:
1. Mevcut [Issues](https://github.com/SametDulger/SD_Tur/issues) sayfasını kontrol edin
2. Yeni özellik önerileri için issue açın
3. Bug report'ları için detaylı açıklama yapın
4. Pull request gönderirken test sonuçlarını ekleyin

