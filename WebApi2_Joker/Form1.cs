using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace WebApi2_Joker
{
    public partial class Form1 : Form
    {
        private string URI = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void GetAllJoker()
        {
            URI = txtURI.Text;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JokerJsonString = await response.Content.ReadAsStringAsync();

                        gdvDados.DataSource = JsonConvert.DeserializeObject<List<Books>>(JokerJsonString).ToList();
                    }
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnObter_Click(object sender, EventArgs e)
        {
            GetAllJoker();
        }
    }
}