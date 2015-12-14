using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSSetting
{
   public class Manager
    {
       public Settings GetLicence()
       {           
           Settings objConfig = new Settings();
           try
           {
               String url = "http://eservice.estudy-portal.com/applicence/validate.php";
               System.Net.WebClient client = new System.Net.WebClient();
               NameValueCollection postData = new NameValueCollection();
               postData.Add("AppLicationNo", AppManager.ApplicationNo );
               postData.Add("localTime", DateTime.Now.ToString ());               
               byte[] data = client.UploadValues(url, "POST", postData);
               string html = System.Text.Encoding.UTF8.GetString(data);

               XMLUtility objXML = new XMLUtility();
               objConfig = (Settings)objXML.CreateObject(html, objConfig);
           }
           catch (Exception ex)
           {

           }
           return objConfig;
       }
      
    }
}
