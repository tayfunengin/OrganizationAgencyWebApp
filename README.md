** Türkçe / English **
# OrganizationAgencyWebApp

Çeşitli organizasyonlara (fuarlar, açılışlar, törenler, etkinlikler) promotor & host / hostes hizmeti veren organizasyon ajanslarının kullanımı için yazılmış bir uygulamadır.

Organizasyon ve çalışan bilgilerinin kayıtlarının tutulması, organizasyonlara atanabilecek modellerin belirlenebilmesi / atanması ve takibinin yapılması, organizasyonun muhasebe kayıtlarının tutulması gibi amaçlar için oluşturulmuştur. Aynı zamanda firmanın tanıtımını yapabileceği bir web sitesi de hazırlanmıştır.

## Teknoloji
* .Net Core 3.1.0
* EntityFrameworkCore 5.0.4

## Kullanım

Uygulamayı download kısmından bilgisayarınıza direkt olarak indirebilirsiniz.
Uygulama Code First Data-Access yönetimi ile hazırlanmıştır. Connection string : "DefaultConnection": "server=.;database=OrganizationAgencyDB;trusted_connection=true;MultipleActiveResultSets=true;", şeklindedir. 
Uygulama açıldığında package manager console' a add-migration ve sonrasında update-database komutları yazılarak veritabanı oluşturulur.

#### Roller
* Admin - Kullanıcı ve rol tanımlayabilir. Organizasyon ve modellerin detaylarını görüntüleyebilir. Organizasyon ve modele bazlı oluşturulan raporları görebilir.
* Organization - Organizasyon ve modelleri sisteme tanımlama ve CRUD işlemlerini yapabilme yetkisi vardır. Organizasyonlara model atamasını yapar. 
* Report - Muhasebe rapolarını görüntüler.
* Model - Kendisine ait profil sayfasına erişebilir ve temel bilgilerini güncelleyebilir.
* Member - İnternet sitesi üzerinden kayıt olan kullanıcılara verilen yetki tipidir. Tanıtım sitesindeki modeller kısmına erişebilmek için üye olmak gerekmektedir.

## 
Uygulamayı kullanabilmek için öncelikle role ve user'ların tanımlanması gerekiyor. Uygulamayı çalıştırdıktan sonra url'e /Admin/Role ekleyip bu sayfaya gidin.
https://localhost:xxxxx/Admin/Role
Aşağıdaki rolleri oluşturun.
![image](https://user-images.githubusercontent.com/71972947/114285297-d8cf4e00-9a5e-11eb-9968-369211c8d0a3.png)
Şimdi admin, organization ve report rolleri için user oluşturabilirsiniz. Şuan sistemde kayıtlı herhangi bir modelimiz olmadığı için model rolüne sahip bir user ekleyemeyiz. Organizasyon rolüne sahip kullanıcı sisteme model ekledikten sonra admin bu model için aynı e-mail adresini kullanarak bir user oluşturabilir. Modelin isim ve soyismi yanlış yazılsa bile uygulama user oluşturken düzeltecektir.
Artık areas/admin/user ve role controllerın üzerindeki [Authorize(Roles = "Admin")] kısımını yorum satırından çıkarabilirsiniz.

Ana sayfadaki login kısmından giriş yapıldığında kullanıcı sahip olduğu role göre ilgili admin paneline yönlendirilir. Home butonu ile ana sayfaya geri dönülebilir. Yetki tipinize göre admin paneline geri dönüş yapabileceğiniz button ve logout butonu sağ üstte çıkar.

Öncelikle organizasyon yetkisine sahip kullanıcı ile giriş yapın. Model list kısmından uygulamaya modelleri tanımlayabilirsiniz. 
Modeller 3 farklı kategoriye ayrılmaktadır. Modellere her organizasyon için ayrı, günlük ödeme yapılmaktadır. Günlük ücretler aşağıdaki gibidir:
* One - Günlük ücreti 200 TL
* Two - Günlük ücreti 400 TL
* Three - Organizasyon için alınan ücretin %20'si o organizasyonda çalışan kategori 3 çalışanları arasında paylaştırılır.
 
Model ekledikten sonra details butonuna tıkladığınızda modelin tüm detaylarına, bugüne kadar katıldığı tüm organizasyon bilgilerine ulaşılabilir. Photo Gallery kısmından yeni fotoğraflar eklenebilir. Modelin galerisine eklenen fotoğraflar tanıtım sayfasında modeller kısmında da siteye üye olan kullanıcılara gösterilir.

![image](https://user-images.githubusercontent.com/71972947/114290034-265eb180-9a85-11eb-9547-51f301a2cf49.png)

Organization List kısmından gerçekleşecek olan organizasyonları sisteme ekleyebilirsiniz. Organizasyon statüleri 3 tanedir:
* Pending - Henüz başlamamış olanlar
* Active - Başlamış ama henüz tamamlanmamış olanlar
* Completed - Tamamlanmış organizasyonlar

Assign Model butonuna tıkladığınızda sadece organizasyonun gerçekleşeceği tarihlerde uygun olan modeller listelenir. Organization List kısmında organizasyon ismine tıkladığınızda detaylarına ulaşabilir, atanan modelleri geri alabilirsiniz.

![image](https://user-images.githubusercontent.com/71972947/114286736-17b6d100-9a6a-11eb-85b9-bcba914db479.png)

Şimdi ise report rolüne sahip kullanıcı ile giriş yapıp muhasebe satış rapolarını görüntüleyebilirsiniz.

Istanbul'daki organizasyonlar şehiriçi, diğer şehirdeki organziasyonlar şehirdışı olarak kabul edilmiştir.
Şehiriçi organizasyonlarda modellere günlük 40 TL yemek ücreti ödenir.
Şehirdışı organizasyonlarda modellere 80TL (2 öğün) yemek ücreti ve günlük 150TL konaklama ücreti ödenir.
Muhsabese yetkilisi organizyon listesinde See Report butonuna tıkladığında o organizasyon için hangi modele ne kadar ödeme yapması gerektiğini, yapılan masrafları ve kazanılan geliri görebilir.
![image](https://user-images.githubusercontent.com/71972947/114286723-fce45c80-9a69-11eb-9a51-ccd5008b7c21.png)

Aynı şekilde model bazlı da rapor alınabilir.
![image](https://user-images.githubusercontent.com/71972947/114286754-45037f00-9a6a-11eb-90e6-74e33909ac0f.png)

Not: Uygulama kullanılmaya başlandığında sadece tamamlanan organizasyonlar rapor kısmında gösterilebilir.

Sisteme eklenen modeller için de admin, user'lar oluşturabilir. Model rolüne sahip kullanıcılar giriş yaptığında kendi bilgilerinin olduğu admin panaline yönlendirilirler.
Sitenin register kısmından üye olunduğunda member rölü atanır. Bu kullanıcı tanıtım sitesi üzerinden modellere erişim yetkisi kazanır.

## Contact

Bana engin.tayfun@gmail.com üzerinden ulaşabilirsiniz.

Teşekkürler.

------- **English**

# OrganizationAgencyWebApp

It is an application developped for the use of organization agencies that provide promoter & host / hostess services to various organizations such as fairs, openings, events etc.

This application keeps records of organizations and models, allows to identify the models that can be assigned to an organization, generates reports for accounting purpose.
Also it includes a website where company can be advertised.

## Technology

* Net Core 3.1.0
* EntityFrameworkCore 5.0.4

## Usage

You can download the application directly to your computer from the download section.
The application has been developped with Code First Data-Access method. Connection string: "DefaultConnection": "server = .; database = OrganizationAgencyDB; trusted_connection = true; MultipleActiveResultSets = true;".
When the application is launched, the database is created by writing add-migration and then update-database commands to the package manager console.

#### Roles
* Admin – Creates user and roles, can monitor details of organization & models also the reports generated based on model or organization.
* Organization – Creates the organization & model and perform CRUD transactions. Can assign the models to organizations.
* Report – Has access to the organization & model reports.
* Model – Has access to their profile page where they can update personal information.
* Member – The role type that is granted to the users registered via internet page. Member role is required to access to Models page in the internet page.

## 
Roles and user must be defined in order to use the application. After running the app, please add /Admin/Role to url and go to this page. https://localhost:xxxxx/Admin/Role

Create below roles:
![image](https://user-images.githubusercontent.com/71972947/114285297-d8cf4e00-9a5e-11eb-9968-369211c8d0a3.png)

You can now create users for admin, organization and report roles. Since we do not have any models registered in the system yet, we cannot add a user having model role. After the user with the organization role adds a model to the system, admin can create a user for this model using the same e-mail address. Even if the model's name and surname are spelled incorrectly, the application will correct it when creating the user.
Now you can uncomment [Authorize (Roles = "Admin")] section above areas / admin / user and role controller.

When logged in from the login section on the home page, the user is directed to the relevant admin panel according to the role having. You can return to the home page with the Home button. The button that can direct you to the admin panel according to your authorization type and logout button appear at the right top.

First, log in with the user who has the organization authority. You can create models from the model list section. Models are divided into 3 different categories. Models are paid daily, separately for each organization. Wages are as follows:
* One - wage 200 TL
* Two - wage 400 TL
* Three - 20% of the fee charged for the organization is shared among the category 3 employees working in that organization.

When you click on the details button after adding a model, you can access all the details of the model and organizations information that they have participated in. New photos can be added from Photo Gallery button. The photos added to the model's gallery are shown to the users who have member role on models page of the website.

![image](https://user-images.githubusercontent.com/71972947/114290034-265eb180-9a85-11eb-9547-51f301a2cf49.png)


You can add the organizations from the organization list section to the system. There are 3 organizational statuses:
* Pending - Those that haven't started yet
* Active - Started but not yet completed
* Completed - Completed organizations

When you click the Assign Model button, only the models that are available for the dates of the organization are listed. When you click on the organization name in the organization list section, you can access to details and remove any assigned model.

![image](https://user-images.githubusercontent.com/71972947/114286736-17b6d100-9a6a-11eb-85b9-bcba914db479.png)

Now you can log in with the user who has the report role and check the accounting sales reports.

Organizations that take place in Istanbul are considered as “InCity” and organizations in other cities  as “OutOfCity”
For “InCity” organizations, models are paid 40 TL per day for meals.
For “OutOfCity” organizations, models are paid 80 TL (2 meals) meal fee and 150 TL daily accommodation fee.
When clicked on the See Report button on the organization list, there can be seen how much must be paid to each model in the organization and total expenses & revenue. 

![image](https://user-images.githubusercontent.com/71972947/114286723-fce45c80-9a69-11eb-9a51-ccd5008b7c21.png)

Model-based reports can be also generated.

![image](https://user-images.githubusercontent.com/71972947/114286754-45037f00-9a6a-11eb-90e6-74e33909ac0f.png)

Note: When the application is in use, only completed organizations can be shown in the report section.

Admin can also create users for models added to the system. When users with model roles log in, they are directed to the their profile page where they can update their information.

When registered via register form on the website, member role is granted directly. This user is granted to access to models page on the website.

## Contact

You can reach me via engin.tayfun@gmail.com.

Thank you.
