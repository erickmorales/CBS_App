using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsAppSendMessage.Models.Request;

namespace WindowsFormsAppSendMessage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtToNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44322/api/Mensaje";

            if (TxtToNumber.Text=="" || TxtMessage.Text=="")
            {
                MessageBox.Show("Empty field. Please check to continue. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

            

            MessageRequest oMessage = new MessageRequest();
            oMessage.Date = DateTime.Today;
            oMessage.ToNumber = TxtToNumber.Text;
            oMessage.Message1 = TxtMessage.Text;

            string resultado = Send<MessageRequest>(url, oMessage, "POST");
            leerMensajes();
            TxtToNumber.Clear();
            TxtMessage.Clear();
            }




        }

        private async void Form1_Load(object sender, EventArgs e )
        {
            
            leerMensajes();


        }
        private async void leerMensajes()
        {
            string respuesta = await GetHttp();
            List<Models.Request.MessageRequest> lst =
                JsonConvert.DeserializeObject<List<Models.Request.MessageRequest>>(respuesta);
            dataGridView1.DataSource = lst;
            bindingSource1.DataSource = lst;
        }


        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44322/api/Mensaje");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }



        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";

            try
            {
               

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //Any issue this is the time to wait

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
               
            }
            catch (Exception e)
            {

                result = e.Message;

            }

            return result;
        }

        private void TxtToNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <=47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                    {
                MessageBox.Show("Please only put numbers", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >=123 && e.KeyChar <=255))
            {
                MessageBox.Show("Please only put letters", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
