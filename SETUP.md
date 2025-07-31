# SDTur Kurulum Rehberi

## 📋 Gereksinimler

- **.NET 9 SDK** ([İndir](https://dotnet.microsoft.com/download/dotnet/9.0))
- **SQL Server** (Express 2022 veya üstü) ([İndir](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))

## 🚀 Kurulum Adımları

### 1. Projeyi İndirin
```bash
git clone https://github.com/SametDulger/SD_Tur.git
cd SD_Tur
```

### 2. Veritabanı Oluşturun
```bash
dotnet ef database update --project SDTur.Infrastructure
```

### 3. Bağlantı Ayarları

**API** (`SDTur.API/appsettings.json`):
```bash
# Örnek dosyayı kopyalayın
cp SDTur.API/appsettings.example.json SDTur.API/appsettings.json
```

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SDTurDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
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
  "ApiBaseUrl": "https://localhost:7275/"
}
```

### 4. Uygulamaları Çalıştırın

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
- API: https://localhost:7275
- Web: https://localhost:7290
- Swagger: https://localhost:7275/swagger

## 🔍 Sorun Giderme

**Veritabanı Bağlantı Hatası:**
- SQL Server servisinin çalıştığından emin olun
- Bağlantı string'ini kontrol edin

**Port Çakışması:**
- `launchSettings.json` dosyasında port numaralarını değiştirin

**Migration Hatası:**
- `appsettings.json` dosyasında connection string'i kontrol edin 