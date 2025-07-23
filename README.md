# CsharpBootCampPostgreSQL
<img width="907" height="387" alt="image" src="https://github.com/user-attachments/assets/eccab6f9-14de-4bc4-a86e-b33733ed7b25" />

Bu dosya, CsharpBootCampPostgreSQL projesinde PostgreSQL veritabanı ile çalışan bir Windows Forms arayüzü sağlar. FrmEmployee formu, çalışan (employee) kayıtlarını listeleme ve yeni çalışan ekleme işlemlerini gerçekleştirir.

## Temel Özellikler

- Çalışanları listeleme (`EmployeeList`)
- Departmanları listeleme (`DepartmentList`)
- Yeni çalışan ekleme (form üzerinden)
- PostgreSQL bağlantısı için Npgsql kütüphanesi kullanılır

## Kullanım

1. Form açıldığında çalışan ve departman listeleri yüklenir.
2. "Ekle" butonuna basarak yeni çalışan ekleyebilirsiniz.
3. "Listele" butonu ile çalışanları güncel olarak görebilirsiniz.

## Gereksinimler

- .NET Framework 4.7.2
- Npgsql (PostgreSQL için .NET veri sağlayıcısı)
- PostgreSQL veritabanı (CustomerDb)
