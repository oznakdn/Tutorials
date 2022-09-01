<h1>Angular</h1>
<h2>Kurulması Gerekenler</h2>
<a href="https://nodejs.org/en/download/" target="_blank"><img src="https://miro.medium.com/max/1400/1*y5YLuOKO5XM7MOzve6XsDQ.png" width="217"></a>
<a href="https://angular.io/cli" target="_blank"><img src="https://blog.logrocket.com/wp-content/uploads/2019/05/6-useful-features-angular-cli.png" width="150"></a>

<h3>Angular UI Material</h3>
<p>ng add @angular/material</p>
<a href="https://material.angular.io/guide/getting-started" target="_blank"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQrA-Ox47QKOubah8dE2qEIhXldwx01VDr-v94yqlKQZE1tV3Yhr1jZLn6fbUp0HzZyrbQ&usqp=CAU" width="100"></a>

<h3>Bootstrap</h3>
 <p>npm install --save bootstrap</p>
<span><a href="https://material.angular.io/guide/getting-started](https://getbootstrap.com/docs/5.2/getting-started/introduction/#cdn-links" target="_blank"><img src="https://muhammetkara.net/wp-content/uploads/2019/07/bs4-bootstrap.jpg" width="120"></a></span>
<ul>
 <li>Projenin angular.json dosyasındaki styles kısmına  "./node_modules/bootstrap/dist/css/bootstrap.css" eklenecek</li>
 <li>Projenin angular.json dosyasındaki scripts kısmına "./node_modules/bootstrap/dist/js/bootstrap.js" eklenecek</li>
 </ul>



## Angular CLI Komutları ##
<table>
<thead>
  <tr>
    <th>Komut</th>
    <th>Görev</th> 
  </tr>
</thead>
 <tbody>
   <tr>
     <td>ng --version</td>
     <td>Angular versiyonunu gösterir</td>
   </tr>
   <tr>
     <td>ng help</td>
     <td>Angular komutlarını listeler</td>
   </tr>
   <tr>
     <td>ng new [ProjectName]</td>
     <td>Angular projesi oluşturur</td>
   </tr>
   <tr>
     <td>ng serve</td>
     <td>Projeyi derler</td>
   </tr>
  <tr>
     <td>ng serve --open</td>
     <td>Projeyi derler ve local sunucuda calistirir</td>
   </tr>
  <tr>
     <td>ng serve --port [portNumber]</td>
     <td>Projenin calisacagi portu degistirir</td>
   </tr>
   <tr>
     <td>ng g c </td>
     <td>Yeni bir component oluşturur</td>
   </tr>
    <tr>
     <td>ng g m </td>
     <td>Yeni bir module oluşturur</td>
   </tr>
   <tr>
     <td>
       ng g m content <br>
       ng g c content/content-list
     </td>
     <td>
       Content adında bir module oluşturur <br>
       Content module içerisinde content-list adında component oluşturur 
     </td>
   </tr>
    <tr>
     <td>ng g d </td>
     <td>Yeni bir directive oluşturur</td>
   </tr>
    <tr>
     <td>ng g d directives/DirectiveName --skip-tests</td>
     <td>Test için spec.ts dosyası oluşturmadan yeni bir directive oluşturur</td>
   </tr>
    <tr>
     <td>ng g s </td>
     <td>Yeni bir service oluşturur</td>
   </tr>
  <tr>
     <td>ng g cl </td>
     <td>Yeni bir class oluşturur</td>
   </tr>
   <tr>
     <td>ng g p </td>
     <td>Yeni bir pipe oluşturur</td>
   </tr>
  </tbody>
</table>
