# TODEB .Net Bootcamp Bitirme Projesi
Apartment Management System 

 ## Proje Hakkında

Bir sitede yönetici tarafından ortak kullanım elektrik, su, doğalgaz faturaları ve aidatlar sistem üzerinden site sakinlerine aylık olarak giriliyor. Site sakinlerine kendilerine gelen faturaları görebiliyor, bu faturaları kredi kartı ile ödeyebiliyor ve yöneticiye mesaj gönderebiliyor. Yönetici, fatura, daire, site sakini, gelen mesajları, daire/konut bilgilerini, kişi bilgilerini, araç bilgilerini ekleyebilir, görebilir, düzenleyebilir ve silebilir.

- Site yöneticisi register olmalıdır, register işlemi şifre oluşturur kendisine mail ile gelen password bilgisi ile sisteme giriş yapmalıdır.
- Sisteme giriş için authentication servisi bulunmaktadır.
- Site yöneticisi, kullanıcı bilgilerini girer, otomatik şifre oluşturulur ve kullanıcı mail adresine gönderilir.
- Site yöneticisi, kullanıcları dairelere atar.
- Site yöneticisi, ay bazlı olarak fatura bilgilerini girer.
- Site yöneticisi, ay bazlı olarak aidat bilgilerini girer.

## Register işlemi
Register için girilen bilgiler önce Fluent Validation kullanılarak yazılan kod ile validasyon edilir, şifre oluşturulur, Hangfire kullanılarak (Hangfire MsSql veritabanını kullanmaktadır) oluşturulan şifre dışardan alınan mail adresine gönderilir. Oluşan şifre hashlenir ve kullanıcı izinleriyle beraber bütün kullanıcı bilgileri database'e kaydedilir. Ayrıca kullanıcı izinleri, her metod çağırma durumunda sürekli MsSql database'i kullanılmaması için Redis servisi kullanarak cachelenmiştir.

## Login işlemi
Login işlemi için önce şifre doğrulama işlemi yapılır. Login için ayrıca authentication servisi vardır. Token oluşturulur ve authorize işlemi yapılır.

## Mesaj Servisi
Site sakini admin'e mesaj gönderebilir, dışarıdan alınan mesaj bilgileri önce Fluent Validation kullanılarak validasyon yapılır. Admin gelen mesajları okuyabilir, silebilir .

## Ödeme Servisi
Fatura ödeme ve aidat ödeme diye 2 ayrı servis bulunmaktadır. Metod kullanıldıktan sonra ödemesi yapılan fatura ve aidat ödendi olarak database'de güncellenir ve ilgili dairenin alacak/borç durumu güncellenerek database'e kaydedilir.

## Araç, Kredi Kartı, Daire, Site Sakini, Fatura ve Aidat Servisleri
Araç, kredi kartı, daire, site sakini, ilgili fatura ve aidatlara ait ekleme, çıkarma, düzenleme ve çağırma metodları bulunmaktadır. Buna ek olarak kredi kartı bilgileri MongoDb database'inde tutulmaktadır. 

## Test
Kullanıcı kayıt işlemi için xUnit ve Fluent Assertions kullanılarak integration test yazıldı.

## Genel
Uygulama .Net 5 kullanılarak yazılmıştır. 
Uygulama katmanlı mimari kullanılarak yazılmıştır
 
  ## ERD Diyagramı

![ApartmentManagementSystem_ERD](/ApartmentManagementSystem_ERD.PNG)


## Swagger
- Register olma
![Register](images/Register.PNG)

- Login olma
![Login](images/Login.PNG)

- Authorize
![Authorize](images/Authorize.PNG)