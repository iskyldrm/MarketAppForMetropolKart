
# MARKETAPP

### Projenin Amacı
**Market ürün takibi ve ürünler ile ilgili gerekli CRUD işlemleri gerçekleştirmektir.<br/><br/>

**Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?** <br/><br/>
--Projemde Katmanlı mimari tasarım deseni kullanılmıştır. Solid prensiplere dosya katmanı ve veri tabanına ulaşımda uyulmuştur.

**Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?** <br/><br/>
--Geliştirilenen projenin REST çağrıları için WEB API ve bu çağrıalrın karşılanması için RAZOR PAGES kullanılmuştır. <br/>
--.NET Core çatısı altından geliştirdiğim projemde Microsoft.Entityframeworkcore teknolojisi kullanılmıtır. <br/>
--CodeFirst yaklaşımı ile geliştirilen entity katmanında migration kullanılmış. Bu çalışma için  Microsoft.Entityframeworkcore.Tools ile migration providerları kullanılmıştır. <br/> --Database providerları için  Microsoft.Entityframeworkcore.SqlServer kullanılmıştır. <br/> -- Web App katmanından gelen ınputlar ve gidecek veriler için mapping işlemi için Automapper ve automapper.extensions.Microsof.DependencyInjection teknolojileri kullanılmıştır. <br/><br/> 
**Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?**<br/><br/>
--Projemde IDENTITY SERVER teknolojisini kullanmak istiyordum.<br/>
--Resim işlemlerini kullanmak istiyordum. Bir CDN servisi eklemek isterdim.<br/>
--Caching yapmak isterdim. <br/>
--BLL katmanını genişletmek ve iş kurallarını mümkün olduğunca tamamlamak isterdim.<br/><br/>
**Eklemek istediğiniz bir yorumunuz var mı?**
<br/><br/>



*** API VE APP PROJESİ aynı solution içinde yapıldığı için proje multistart ile başlatılmalıdır. <br/>
*** Farklı solutiona gerek kalmadı.

--Image sınıfı eklenmiş yalnız çalıştırılmasında sıkıntı çıkabileceği için aynı zamanda 
zaman problemi nedeni sebebi ile geliştirilmemiştir.

--Database scripti MarketAppForMetropolKart/MarketApp.WebApp/wwwroot/Scripts klasörüne eklenmiştir.

--MarketApp adında database oluşturularak çalıştırılması yeterli olacaktır.(localdb)\mssqllocaldb server name

--DAL katmanı Context sınıfında kullanılan connection string kontrol edilebilir.

--Scriptte sorun çıkması durumunda package manager consoldan update-database yapılabilir.

--Update-database yapılırsa kategori vergi ve tedarikçiler baştan eklenmelidir.

--Zaman problemi yüzünden SOLİD prensiplere mümkün olduğu kadar uyulmuştur.

## Proje Görselleri <br/>
**Ürün Ekleme**
![resim1](https://github.com/iskyldrm/MarketAppForMetropolKart/blob/master/MarketApp.WebApp/wwwroot/img/%C3%9Cr%C3%BCn%20ekleme.png?raw=true)
**Ürün Güncelleme**
![resim2](https://github.com/iskyldrm/MarketAppForMetropolKart/blob/master/MarketApp.WebApp/wwwroot/img/%C3%9Cr%C3%BCn%20g%C3%BCncelleme.png?raw=true)
**Ürün Listeleme Arama**
![resim3](https://github.com/iskyldrm/MarketAppForMetropolKart/blob/master/MarketApp.WebApp/wwwroot/img/%C3%9Cr%C3%BCn%20listleme%20ve%20Arama.png?raw=true)
**Ürün Silme**
![resim4](https://github.com/iskyldrm/MarketAppForMetropolKart/blob/master/MarketApp.WebApp/wwwroot/img/%C3%9Cr%C3%BCn%20silme.png?raw=true)

