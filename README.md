** Türkçe / English **
# OrganizationAgencyWebApp

Çeşitli organizasyonlara (fuarlar, açılışlar, törenler, etkinlikler) promotor & host / hostes hizmeti veren organizasyon ajanslarının kullanımı için yazılmış bir uygulamadır.

Organizasyon ve çalışan bilgilerinin kayıtlarının tutulması, organizasyonlarda hangi modellerin çalıştığının takibinin yapılması, organizasyonun muhasebe kayıtlarının tutulması gibi amaçlar için oluşturulmuştur. Aynı zamanda firmanın tanıtımını yapabileceği bir web sitesi de hazırlanmıştır.

## Teknoloji
* .Net Core 3.1.0
* EntityFrameworkCore 5.0.4

## Kullanım

Uygulamayı download kısmından bilgisayarınıza direkt olarak indirebilirsiniz.
Uygulama Code First Data-Access yönetimi ile hazırlanmıştır. Connection string : "DefaultConnection": "server=.;database=OrganizationAgencyDB;trusted_connection=true;MultipleActiveResultSets=true;", şeklindedir. 

#### Roller
* Admin - Kullanıcı ve rol tanımlayabilir. Organiasyon ve modellerin detaylarını görüntüleyebilir. Organizasyon ve modele göre satış raporlarını görebilir.
* Organization - Organizasyon ve modelleri sisteme tanımla ve CRUD işlemlerini yapabilme yetkisi vardır. Organizasyonlara model atamasını yapar. 
* Report - Muhasebe satış rapolarını görüntüler.
* Model - Kendisine ait profil sayfasına erişebilir ve temel bilgilerini güncelleyebilir.
* Member - İnternet sitesi üzerinden kayıt olan kullanıcılara verilen yetki tipidir. Tanıtım sitesindeki modeller kısmına erişebilmek için üye olmak gerekmektedir.

## 
Uygulamayı kullanabilmek için öncelikle role ve user'ların tanımlanması gerekiyor. Uygulamayı çalıştırdıktan sonra url'e /Admin/Role ekleyip bu sayfaya gidin.
https://localhost:xxxxx/Admin/Role
Aşağıdaki rolleri oluşturun.
![image](https://user-images.githubusercontent.com/71972947/114285297-d8cf4e00-9a5e-11eb-9968-369211c8d0a3.png)
Şimdi admin, organization ve report rolleri için user oluşturabilirsiniz. Şuan sistemde kayıtlı herhangi bir modelimiz olmadığı için model rolüne sahip bir user ekleyemeyiz. Organizasyon rolüne sahip kullanıcı sisteme model ekledikten sonra admin bu model için aynı e-mail adresini kullanarak bir user oluşturabilir. Modelin isim ve soyismi yanlış yazılsa bile uygulama user oluşturken düzeltecektir.




