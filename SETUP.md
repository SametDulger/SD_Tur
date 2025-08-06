# SDTur Kurulum Rehberi

## 📋 Gereksinimler

- **.NET 9 SDK** ([İndir](https://dotnet.microsoft.com/download/dotnet/9.0))
- **SQL Server** (Express 2022 veya üstü) ([İndir](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
- **Entity Framework Core Tools** (Global olarak yükleyin):
  ```bash
  dotnet tool install --global dotnet-ef
  ```

## 🚀 Kurulum Adımları

### 1. Projeyi İndirin
```bash
git clone https://github.com/SametDulger/SD_Tur.git
cd SD_Tur
```

### 2. Bağlantı Ayarları

**API** (`SDTur.API/appsettings.json`):
```bash
# Örnek dosyayı kopyalayın
cp SDTur.API/appsettings.example.json SDTur.API/appsettings.json
```

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\SQLEXPRESS;Database=SDTurDB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true",
    "Redis": "localhost:6379"
  },
  "JwtSettings": {
    "SecretKey": "SDTur-Super-Secret-Key-2024-With-At-Least-32-Characters-Long",
    "Issuer": "SDTur",
    "Audience": "SDTurUsers",
    "ExpirationInMinutes": 480
  },
  "CorsSettings": {
    "AllowedOrigins": [
      "https://localhost:7276",
      "http://localhost:5018"
    ]
  },
  "IpRateLimit": {
    "EnableEndpointRateLimiting": true,
    "GeneralRules": [
      {"Endpoint": "*", "Period": "1s", "Limit": 10},
      {"Endpoint": "*", "Period": "1m", "Limit": 100}
    ]
  },
  "Serilog": {
    "MinimumLevel": {"Default": "Information"},
    "WriteTo": [
      {"Name": "Console"},
      {"Name": "File", "Args": {"path": "Logs/log-.txt"}}
    ]
  }
}
```

**Web** (`SDTur.Web/appsettings.json`):
```bash
# Örnek dosyayı kopyalayın
cp SDTur.Web/appsettings.example.json SDTur.Web/appsettings.json
```

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7001",
    "Timeout": 30,
    "RetryCount": 3,
    "RetryDelay": 1000
  },
  "SessionSettings": {
    "IdleTimeout": 480,
    "CookieName": "SDTur.Session"
  },
  "SecuritySettings": {
    "RequireHttps": true,
    "HstsMaxAge": 365
  },
  "Serilog": {
    "MinimumLevel": {"Default": "Information"},
    "WriteTo": [
      {"Name": "Console"},
      {"Name": "File", "Args": {"path": "Logs/web-log-.txt"}}
    ]
  }
}
```

### 3. Veritabanı Migration ve Seed Data

**İlk Kurulum:**
```bash
# Migration oluştur
dotnet ef migrations add InitialCreate --project SDTur.Infrastructure --startup-project SDTur.API

# Veritabanını oluştur ve migration'ları uygula
dotnet ef database update --project SDTur.Infrastructure --startup-project SDTur.API
```

**Mevcut Projeyi Güncelleme:**
```bash
# Yeni migration oluştur
dotnet ef migrations add UpdateModel --project SDTur.Infrastructure --startup-project SDTur.API

# Veritabanını güncelle
dotnet ef database update --project SDTur.Infrastructure --startup-project SDTur.API
```

**Migration'ları Sıfırlama:**
```bash
# Tüm migration'ları kaldır
dotnet ef migrations remove --project SDTur.Infrastructure --startup-project SDTur.API

# Veritabanını sıfırla
dotnet ef database update 0 --project SDTur.Infrastructure --startup-project SDTur.API

# Yeni migration oluştur
dotnet ef migrations add InitialCreate --project SDTur.Infrastructure --startup-project SDTur.API

# Veritabanını güncelle
dotnet ef database update --project SDTur.Infrastructure --startup-project SDTur.API
```

### 4. Test Çalıştırma
```bash
# Tüm testleri çalıştır
dotnet test

# Belirli bir test projesini çalıştır
dotnet test SDTur.Tests
```

### 5. Uygulamaları Çalıştırın

**API:**
```bash
cd SDTur.API
dotnet run
```

**Web:**
```bash
cd SDTur.Web
dotnet run
```

**Erişim:**
- API: https://localhost:7001
- Web: https://localhost:7276
- Swagger: https://localhost:7001/swagger

**Varsayılan Kullanıcılar:**
- **Admin:** admin / Admin123!
- **Manager:** manager / Manager123!
- **Sales:** sales / Sales123!

## 🔍 Sorun Giderme

**Veritabanı Bağlantı Hatası:**
- SQL Server servisinin çalıştığından emin olun
- Bağlantı string'ini kontrol edin
- `TrustServerCertificate=true` ekleyin

**Migration Hatası:**
- `appsettings.json` dosyasında connection string'i kontrol edin
- Migration'ları sıfırlayın

**Build Hatası:**
- Tüm projeleri temizleyin: `dotnet clean`
- NuGet paketlerini geri yükleyin: `dotnet restore`
- Projeyi yeniden build edin: `dotnet build`

**Test Hatası:**
- Test ortamı ayarlarını kontrol edin
- Test veritabanı bağlantısını kontrol edin 