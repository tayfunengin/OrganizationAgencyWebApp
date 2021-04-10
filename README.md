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
* Organization - Organizasyon ve modelleri sisteme tanımlama ve CRUD işlemlerini yapabilme yetkisi vardır. Organizasyonlara model atamasını yapar. 
* Report - Muhasebe satış rapolarını görüntüler.
* Model - Kendisine ait profil sayfasına erişebilir ve temel bilgilerini güncelleyebilir.
* Member - İnternet sitesi üzerinden kayıt olan kullanıcılara verilen yetki tipidir. Tanıtım sitesindeki modeller kısmına erişebilmek için üye olmak gerekmektedir.

## 
Uygulamayı kullanabilmek için öncelikle role ve user'ların tanımlanması gerekiyor. Uygulamayı çalıştırdıktan sonra url'e /Admin/Role ekleyip bu sayfaya gidin.
https://localhost:xxxxx/Admin/Role
Aşağıdaki rolleri oluşturun.
![image](https://user-images.githubusercontent.com/71972947/114285297-d8cf4e00-9a5e-11eb-9968-369211c8d0a3.png)
Şimdi admin, organization ve report rolleri için user oluşturabilirsiniz. Şuan sistemde kayıtlı herhangi bir modelimiz olmadığı için model rolüne sahip bir user ekleyemeyiz. Organizasyon rolüne sahip kullanıcı sisteme model ekledikten sonra admin bu model için aynı e-mail adresini kullanarak bir user oluşturabilir. Modelin isim ve soyismi yanlış yazılsa bile uygulama user oluşturken düzeltecektir.

Ana sayfadaki login kısmından giriş yapıldığında kullanıcı sahip olduğu role göre ilgili admin paneline yönlendirilir. Home butonu ile ana sayfaya geri dönülebilir. Yetki tipinize göre admin paneline geri dönüş yapabileceğiniz button ve logout butonu sağ üstte çıkar.

Öncelikle organizasyon yetkisine sahip kullanıcı ile giriş yapın. Model list kısmından uygulamaya modelleri tanımayabilirsiniz. 
Modeller 3 farklı kategoriye ayrılmaktadır. Modellere her organizasyon için ayrı, günlük ödeme yapılmaktadır. Günlük ücretler aşağıdaki gibidir:
* One - Günlük ücreti 200 TL
* Two - Günlük ücreti 400 TL
* Three - Organizasyon için alınan ücretin %20'si o organizasyonda çalışan kategori 3 çalışanları arasında paylaştırılır.
 
Model ekledikten sonra details butonuna tıkladığınızda modelin tüm detaylarına, bugüne kadar katıldığı tüm organizasyon bilgilerine ulaşılabilir. Photo Gallery kısmından yeni fotoğraflar eklenebilir. Modelin galerisine eklenen fotoğraflar tanıtım sayfasında modeller kısmında da siteye üye olan kullanıcılara gösterilir.

![image](https://user-images.githubusercontent.com/71972947/114286132-bdffd800-9a64-11eb-87f9-db20df9f5fb4.png)

Organization List kısmından gerçekleşecek olan orgnizasyonları sisteme ekleyebilirsiniz. Organizasyon statüleri 3 tanedir:
* Pending - Heünüz başlamamış olanlar
* Active - Başlamış ama henüz tamamlanmamış olanlar
* Completed - Tamamlanmış organizasyonlar

Assign Model butonuna tıkladığınızda sadece organizasyonun gerçekleşeceği tarihlerde uygun olan modeller listelenir. Organization List kısmında organizasyon ismine tıkladığınızda detaylarına ulaşabilir, atanan modelleri geri alabilirsiniz.

![image](https://user-images.githubusercontent.com/71972947/114286736-17b6d100-9a6a-11eb-85b9-bcba914db479.png)

Şimdi ise report rolüne sahip kullanıcı ile giriş yapıp muhasebe satış rapolarını görüntüleyebilirsiniz.

Istanbul'daki organizasyonlar şehiriçi, diğer şehirdeki organziasyonlar şehirdışı olarak kabul edilmiştir.
Şehiriçi organizasyonlarda modellere günlük 40 TL yemek ücreti ödenir.
Şehirdışı organizasyonlarda modellere 80TL (2 öğün) yemek ücreti ve günlük 150TL konaklama ücreti ödenir.
Muhsabese yetkilisi organizyon listesinde See Repor butonuna tıkladığında o organizasyon için hangi modele ne kadar ödeme yapması gerektiğini, yapılan masrafları ve kazanılan geliri görebilir.
![image](https://user-images.githubusercontent.com/71972947/114286723-fce45c80-9a69-11eb-9a51-ccd5008b7c21.png)

Aynı şekilde model bazlı da rapor alınabilir.
![image](https://user-images.githubusercontent.com/71972947/114286754-45037f00-9a6a-11eb-90e6-74e33909ac0f.png)

Not: Uygulama kullanılmaya başlanıldığında sadece tamamlanan organizasyonlar rapor kısmında gösterilebilir.

Sisteme eklenen modeller için de admin user'lar oluşturabilir. Model rolüne sahip kullanıcılar giriş yağtığında kendi bilgilerinin olduğu admin panaline yönlendirilirler.
Sitenin register kısmından üye oluduğunda member rölü atanır. Bu kullanıcı tanıtım sitesi üzerinden modellere erişim yetkisi kazanır.



