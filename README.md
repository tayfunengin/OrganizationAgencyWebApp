** Türkçe / English **
# OrganizationAgencyWebApp

Çeşitli organizasyonlara (fuarlar, açılışlar, törenler, etkinlikler) promotor & host / hostes hizmeti veren organizasyon ajanslarının kullanımı için yazılmış bir uygulamadır.

Organizasyon ve çalışan bilgilerinin kayıtlarının tutulması, organizasyonlarda hangi modellerin çalıştığının takibinin yapılması, organizasyonun muhasebe kayıtlarının tutulması gibi amaçlar için oluşturulmuştur. Aynı zamanda firmanın tanıtımını yapabileceği bir web sitesi de hazırlanmıştır.

## Teknoloji
* .Net Core 3.1.0
* EntityFrameworkCore 5.0.4

## Kullanım

Uygulama Code First Data-Access yönetimi ile hazırlanmıştır. Connection string : "DefaultConnection": "server=.;database=OrganizationAgencyDB;trusted_connection=true;MultipleActiveResultSets=true;", şeklindedir. 

#### Roller
* Admin - Kullanıcı ve rol tanımlayabilir. Organiasyon ve modellerin detaylarını görüntüleyebilir. Organizasyon ve modele göre satış raporlarını görebilir.
* Organization - Organizasyon ve modelleri sisteme tanımla ve CRUD işlemlerini yapabilme yetkisi vardır. Organizasyonlara model atamasını yapar. 
* Report - Muhasebe satış rapolarını görüntüler.
* Model - Kendisine ait profil sayfasına erişebilir ve temel bilgilerini güncelleyebilir.
* Member - İnternet sitesi üzerinden kayıt olan kullanıcılara verilen yetki tipidir. Tanıtım sitesindeki modeller kısmına erişebilmek için üye olmak gerekmektedir.

## 
Uygulamayı kullanabilmek için öncelikle user ve rolleri tanımlamak gerekmektedir. Bunun uygulamayı çalıştırdıktan sonra url'e /Admin/Role ekleyip bu sayfaya gidin.
https://localhost:xxxxx/Admin/Role

    ![image](https://user-images.githubusercontent.com/71972947/114285144-76298280-9a5d-11eb-838d-104cb2d2683c.png)

