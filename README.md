# 🛡️ Hibrit Finansal Zekâ ve Portföy Ekosistemi

Bu platform, sadece harcamaları kaydeden standart bir uygulama değil; harcama alışkanlıklarınızı bir "parmak izi" gibi öğrenen, anomalileri tespit eden ve toplam varlığınızı (hisse, kripto, nakit) kurumsal seviyede yöneten yapay zekâ destekli bir finansal komuta merkezidir.

## 🚀 Öne Çıkan Özellikler

### 🧠 1. Yapay Zekâ ve Analitik (Python FastAPI)

* **Anomali Dedektörü:** Harcama paternlerinizden sapan (alışılmadık saat, yüksek tutar, farklı lokasyon) işlemleri anında işaretler.
* **Abonelik Takibi:** Unutulan veya pasif kalan abonelikleri tespit ederek gereksiz harcamaların önüne geçer.
* **Kişisel Enflasyon Analizi:** Satın alınan temel ürünlerin fiyat değişimini takip ederek kullanıcıya özel enflasyon oranını hesaplar.
* **Tahminleme Motoru:** Regresyon modelleri ile ay sonu bakiye ve tasarruf projeksiyonu sunar.

### 🏛️ 2. Kurumsal Varlık Yönetimi (.NET 9 & MSSQL)

* **Hibrit Portföy:** Hisse senedi, kripto para ve döviz varlıklarını canlı verilerle takip eder. 
* **Veri Bütünlüğü:** MSSQL üzerinde kurgulanan tetikleyiciler (Triggers) ve saklı yordamlar (Stored Procedures) ile hatasız bakiye yönetimi sağlar.
* **Raporlama:** Harcama ve varlık değişimlerini analiz ederek profesyonel PDF raporlarına dönüştürür.

### 🔒 3. Güvenlik ve Gizlilik

* **Gizlilik Odaklı Altyapı:** Tüm finansal veriler veritabanında "AES-256" şifreleme standartlarıyla korunur.
* **Esnek Veri Girişi:** Manuel giriş seçeneklerinin yanı sıra, mobil cihazlarda yerel (offline) çalışan OCR (Fiş okuma) desteği sunulur.
* **Güvenli Entegrasyon (OAuth2):** Dış servis ve banka bağlantıları, şifre paylaşımı gerektirmeksizin yalnızca kullanıcı onayıyla, güvenli token'lar üzerinden gerçekleştirilir.

---

## 🛠️ Teknoloji Yığını (Tech Stack)

| Katman | Teknoloji | Açıklama |
| --- | --- | --- |
| **Backend** | **.NET 9 (C#)** | Yüksek performanslı merkezi API yönetimi. |
| **Zekâ Motoru** | **Python (FastAPI)** | Makine öğrenmesi (ML) modelleri ve veri işleme servisi. |
| **Veritabanı** | **MSSQL** | İlişkisel veri, Stored Procedure ve ACID uyumluluğu. |
| **Frontend** | **React & Tailwind** | Modern, hızlı ve duyarlı (responsive) kontrol paneli. |
| **Mobile** | **React Native** | Fiş tarama (OCR) ve anlık bildirim altyapısı. |
| **Analiz** | **Scikit-learn / Pandas** | Anomali tespiti ve gelişmiş finansal analizler. |

---

## 🗺️ Geliştirme Yol Haritası (Roadmap)

### Faz 1: Temel İskelet ve Veritabanı (Tamamlandı)

* [x] Proje mimarisinin kurulması ve katmanların oluşturulması.
* [x] MSSQL veritabanı şemasının Entity'lere göre tasarlanması ve oluşturulması.

### Faz 2: Backend Geliştirmeleri ve API (Mevcut Durum)

* [ ] Temel CRUD işlemlerinin API üzerinden dışa açılması.
* [ ] Kimlik doğrulama (Authentication) ve yetkilendirme (Authorization) altyapısının kurulması.

### Faz 3: Yapay Zekâ ve Analitik Entegrasyonu

* [ ] Python FastAPI servisinin ayağa kaldırılması.
* [ ] Anomali tespit algoritmalarının veri tabanıyla haberleşmesi.
